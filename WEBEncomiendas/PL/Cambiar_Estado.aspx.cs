using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Cat_Man;
using BLL.Cat_Man;
using System.Data;

namespace PL
{
    public partial class Cambiar_Estado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                DAL.Cat_Man.Cls_Membership_DAL objDAL = new DAL.Cat_Man.Cls_Membership_DAL();
                BLL.Cat_Man.Cls_Membership_BLL objBLL = new BLL.Cat_Man.Cls_Membership_BLL();
                objDAL.sUserLogin = Session["UserLogin"].ToString();
                objDAL.sPrivilegio = "Cambiar_Estado";
                if (objBLL.HasPrivilege(ref objDAL))
                {
                    if (!IsPostBack)
                    {
                        this.Form.Attributes.Add("autocomplete", "off");
                        CargarPedidosUsuario();
                        CargarEstados();
                    }
                }
                else
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        private static DataView paquetesLista;
        private void CargarEstados()
        {
            Cls_Estados_BLL objBLL = new Cls_Estados_BLL();
            Cls_Estados_DAL objDAL = new Cls_Estados_DAL();

            cmbEstados.DataSource = null;
            cmbEstados.DataBind();

            objBLL.Listar(ref objDAL);

            cmbEstados.DataTextField = "Descripcion";
            cmbEstados.DataValueField = "Id_Estado";

            cmbEstados.DataSource = objDAL.DtTablaEstado;
            cmbEstados.DataBind();
        }

        private void CargarPedidosUsuario()
        {
            Cls_Paquetes_BLL objBLL = new Cls_Paquetes_BLL();
            Cls_Paquetes_DAL objDAL = new Cls_Paquetes_DAL();

            gdvEstados.DataSource = null;
            gdvEstados.DataBind();

            objBLL.Listar(ref objDAL);
            string prueba = txtBuscar.Value;
            if (objDAL.SError == string.Empty)
            {
                gdvEstados.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    DataTable dt = objDAL.DtTablaPaquetes;

                    EnumerableRowCollection<DataRow> query = from dtEstados in dt.AsEnumerable()
                                                             where !dtEstados.Field<int>("Id_Estado").Equals(3)
                                                             select dtEstados;

                    DataView view = query.AsDataView();
                    paquetesLista = view;
                    gdvEstados.DataSource = view;
                    gdvEstados.Columns[0].Visible = true;
                }
                else
                {
                    DataTable dt = objDAL.DtTablaPaquetes;

                    EnumerableRowCollection<DataRow> query = from dtEstados in dt.AsEnumerable()
                                                             where dtEstados.Field<int>("Id_Paquete").ToString().ToLower().Replace(" ", "").Contains(txtBuscar.Value.ToLower().Replace(" ", ""))
                                                             select dtEstados;

                    DataView view = query.AsDataView();

                    foreach (DataRowView row in view)
                    {
                        if (row["Id_Estado"].ToString().Equals("3"))
                        {
                            gdvEstados.Columns[0].Visible = false;
                        }



                    }

                    gdvEstados.DataSource = view;

                }


                gdvEstados.DataBind();
                updpnlGrid.Update();
                if (gdvEstados.Rows.Count > 0)
                {
                    gdvEstados.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvEstados.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblMensaje.Text = objDAL.SError;
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Visible = false;
                Cls_Paquetes_BLL objBLL = new Cls_Paquetes_BLL();
                Cls_Paquetes_DAL objDAL = new Cls_Paquetes_DAL();

                objDAL.SIdPaquete = txtIdPaquete.Value.ToString().Trim();
                objDAL.SIdEstado = Convert.ToInt32(cmbEstados.SelectedValue.ToString().Trim());


                objDAL.CAccion = 'U';
                objBLL.Editar(ref objDAL);


                if (!string.IsNullOrEmpty(objDAL.SError))
                {
                    lblMensaje.Text = objDAL.SError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    CargarPedidosUsuario();
                    if (objDAL.CAccion == 'U')
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "Editado();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "Guardado();", true);
                    }

                    lblMensaje.ForeColor = System.Drawing.Color.Green;

                }
                updpnlGrid.Update();
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message.ToString();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPedidosUsuario();
            updpnlGrid.Update();
        }

        protected void gdvEstados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CambiarEstado")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                string nombre, id = "1";
                foreach (DataRowView rows in paquetesLista)
                {
                    nombre = rows["Estado"].ToString();
                    if (nombre.Equals(Server.HtmlDecode(gdvEstados.Rows[index].Cells[3].Text)))
                    {
                        id = rows["Id_Estado"].ToString();
                        break;
                    }
                }
                GridViewRow row = gdvEstados.Rows[index];
                string idPaquete = gdvEstados.Rows[index].Cells[1].Text;
                txtIdPaquete.Value = idPaquete;
                cmbEstados.SelectedValue = id;
                updpnlModal.Update();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "obtenerDatos();", true);
            }
        }

        protected void gdvEstados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvEstados.PageIndex = e.NewPageIndex;
            CargarPedidosUsuario();
        }


    }
}