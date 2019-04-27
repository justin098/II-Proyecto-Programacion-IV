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
    public partial class Tarjetas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                if (!IsPostBack)
                {
                    this.Form.Attributes.Add("autocomplete", "off");
                    CargarTarjetas();
                }
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        private void CargarTarjetas()
        {
            Cls_Tarjetas_BLL objBLL = new Cls_Tarjetas_BLL();
            Cls_Tarjetas_DAL objDAL = new Cls_Tarjetas_DAL();

            objDAL.SPersona = Session["UserLogin"].ToString(); 

            objBLL.Filtrar(ref objDAL);

            gdvTarjetas.DataSource = null;
            gdvTarjetas.DataBind();

            objBLL.Filtrar(ref objDAL);
            if (objDAL.SError == string.Empty)
            {
                gdvTarjetas.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    gdvTarjetas.DataSource = objDAL.DtTablaTarjetas;
                }
                else
                {
                    DataTable dt = objDAL.DtTablaTarjetas;

                    EnumerableRowCollection<DataRow> query = from dtUsuarios in dt.AsEnumerable()
                                                             where dtUsuarios.Field<string>("Numero_tarjeta").ToLower().Contains(txtBuscar.Value.ToLower())
                                                             select dtUsuarios;

                    DataView view = query.AsDataView();

                    gdvTarjetas.DataSource = view;

                }


                gdvTarjetas.DataBind();

                if (gdvTarjetas.Rows.Count > 0)
                {
                    gdvTarjetas.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvTarjetas.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblMensaje.Text = objDAL.SError;
            }
        }

        protected void gdvTarjetas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvTarjetas.PageIndex = e.NewPageIndex;
            CargarTarjetas();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarTarjetas();
            updpnlGrid.Update();
        }

        protected void gdvTarjetas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvTarjetas.Rows[index];
                String sNumerotarjeta = gdvTarjetas.Rows[index].Cells[2].Text;
                lblMensaje.Visible = false;

                lblHeader.InnerText = "Editar Tarjeta";
                updpnlModalHeader.Update();
                txtNumeroTarjeta.Value = gdvTarjetas.Rows[index].Cells[2].Text;
                dttFechaVencimiento.Value = gdvTarjetas.Rows[index].Cells[3].Text;
                txtCodigoSeguridad.Value = gdvTarjetas.Rows[index].Cells[4].Text;
                Session["Action"] = 'U';
                txtNumeroTarjeta.Disabled = true;
                updpnlGrid.Update();
                updpnlModal.Update();
            }
            else if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvTarjetas.Rows[index];
                String sNumerotarjeta = gdvTarjetas.Rows[index].Cells[2].Text;
                lblMensaje.Visible = false;

                Cls_Tarjetas_BLL objBLL = new Cls_Tarjetas_BLL();
                Cls_Tarjetas_DAL objDAL = new Cls_Tarjetas_DAL();

                objDAL.SPersona = Session["UserLogin"].ToString();
                objDAL.SNumerotarjeta = sNumerotarjeta;

                objBLL.Eliminar(ref objDAL);

                if (!string.IsNullOrEmpty(objDAL.SError))
                {
                    lblMensaje.Text = objDAL.SError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    CargarTarjetas();
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Registro eliminado correctamente";
                    lblMensaje.ForeColor = System.Drawing.Color.White;
                    updpnlGrid.Update();
                }

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                lblHeader.InnerText = "Agregar Tarjeta";
                Session["Action"] = 'I';
                LimpiarCampos();
                dttFechaVencimiento.Value = DateTime.Now.ToString("yyyy-MM-dd");
                txtNumeroTarjeta.Disabled = false;
                updpnlModalHeader.Update();
                updpnlModal.Update();
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message.ToString();
            }
        }

        private void LimpiarCampos()
        {
            txtNumeroTarjeta.Value = string.Empty;
            dttFechaVencimiento.Value = string.Empty;
            txtCodigoSeguridad.Value = string.Empty;
            updpnlModal.Update();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Visible = false;
                Cls_Tarjetas_BLL objBLL = new Cls_Tarjetas_BLL();
                Cls_Tarjetas_DAL objDAL = new Cls_Tarjetas_DAL();

                objDAL.SPersona = Session["UserLogin"].ToString();
                objDAL.SNumerotarjeta = txtNumeroTarjeta.Value;
                objDAL.SFechaVencimiento = dttFechaVencimiento.Value;
                objDAL.ScodigoSeguridad = txtCodigoSeguridad.Value;

                if (Convert.ToChar(Session["Action"].ToString()) == 'U')
                    objBLL.Editar(ref objDAL);
                else
                    objBLL.Insertar(ref objDAL);

                if (!string.IsNullOrEmpty(objDAL.SError))
                {
                    lblMensaje.Text = objDAL.SError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    if (Convert.ToChar(Session["Action"].ToString()) == 'U')
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Registro editado correctamente');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Registro guardado correctamente');", true);
                    }
                    CargarTarjetas();

                }
                updpnlGrid.Update();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message.ToString();
            }
        }
    }
}