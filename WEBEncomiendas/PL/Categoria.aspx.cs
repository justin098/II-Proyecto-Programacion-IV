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
    public partial class Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                DAL.Cat_Man.Cls_Membership_DAL objDAL = new DAL.Cat_Man.Cls_Membership_DAL();
                BLL.Cat_Man.Cls_Membership_BLL objBLL = new BLL.Cat_Man.Cls_Membership_BLL();
                objDAL.sUserLogin = Session["UserLogin"].ToString();
                objDAL.sPrivilegio = "Administrar_Categorias";
                if (objBLL.HasPrivilege(ref objDAL))
                {
                    if (!IsPostBack)
                    {
                        this.Form.Attributes.Add("autocomplete", "off");
                        CargarCategorias();
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
        private void CargarCategorias()
        {
            Cls_Categoria_BLL objBLL = new Cls_Categoria_BLL();
            Cls_Categoria_DAL objDAL = new Cls_Categoria_DAL();

            gdvCategorias.DataSource = null;
            gdvCategorias.DataBind();

            objBLL.Listar(ref objDAL);
            string prueba = txtBuscar.Value;
            if (objDAL.SError == string.Empty)
            {
                gdvCategorias.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    gdvCategorias.DataSource = objDAL.DtTablaCategoria;
                }
                else
                {
                    DataTable dt = objDAL.DtTablaCategoria;

                    //.REPLACE PARA LA BUSQUEDA ELIMINA LOS ESPACIO EN BLANCO
                    EnumerableRowCollection<DataRow> query = from dtcategoria in dt.AsEnumerable()
                                                             where dtcategoria.Field<string>("Nombre").ToLower().Replace
                                                             (" ", "").Contains(txtBuscar.Value.ToLower().Replace(" ", ""))
                                                             select dtcategoria;

                    DataView view = query.AsDataView();

                    gdvCategorias.DataSource = view;

                }


                gdvCategorias.DataBind();

                if (gdvCategorias.Rows.Count > 0)
                {
                    gdvCategorias.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvCategorias.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblMensaje.Text = objDAL.SError;
            }
        }

        protected void gdvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvCategorias.PageIndex = e.NewPageIndex;
            CargarCategorias();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarCategorias();
            updpnlGrid.Update();
        }
        protected void gdvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvCategorias.Rows[index];
                String idCategoria = gdvCategorias.Rows[index].Cells[2].Text;
                lblHeader.InnerText = "Editar Categoria";
                updpnlModalHeader.Update();
                txtIdCategoria.Value = idCategoria;
                txtNombreCategoria.Value = Server.HtmlDecode(gdvCategorias.Rows[index].Cells[3].Text);
                txtDescripcion.Value = Server.HtmlDecode(gdvCategorias.Rows[index].Cells[4].Text);



                updpnlGrid.Update();
                lblIdCategoria.Visible = true;
                txtIdCategoria.Visible = true;
                updpnlModal.Update();

            }
            else if (e.CommandName == "Borrar")
            {
                //este lo cambie por un error que me mandaba de que strin no se podra convertir a int32
                int index = System.Int32.Parse(Convert.ToString(e.CommandArgument));
                GridViewRow row = gdvCategorias.Rows[index];
                String idCategoria = gdvCategorias.Rows[index].Cells[2].Text;
                lblMensaje.Visible = false;
                Cls_Categoria_BLL objBLL = new Cls_Categoria_BLL();
                Cls_Categoria_DAL objDAL = new Cls_Categoria_DAL();
                //aqui se caia cuando hacia la conversion
                objDAL.SIdcategoria = System.Int32.Parse(Convert.ToString(idCategoria.Trim()));
                objBLL.Eliminar(ref objDAL);


                if (!string.IsNullOrEmpty(objDAL.SError))
                {
                    lblMensaje.Text = objDAL.SError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    CargarCategorias();
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
                lblHeader.InnerText = "Agregar Categoria";
                lblIdCategoria.Visible = false;
                txtIdCategoria.Visible = false;
                updpnlModalHeader.Update();
                updpnlModal.Update();
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message.ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Visible = false;
                Cls_Categoria_BLL objBLL = new Cls_Categoria_BLL();
                Cls_Categoria_DAL objDAL = new Cls_Categoria_DAL();

                objDAL.SNombre = txtNombreCategoria.Value.ToString().Trim();
                objDAL.SDescripcion = txtDescripcion.Value.ToString().Trim();

                if (txtIdCategoria.Visible == false)
                {
                    objDAL.CAccion = 'I';
                    objBLL.Insertar(ref objDAL);
                }
                else
                {
                    objDAL.SIdcategoria = Convert.ToInt32(txtIdCategoria.Value.ToString().Trim());
                    objDAL.CAccion = 'U';
                    objBLL.Editar(ref objDAL);
                }

                if (!string.IsNullOrEmpty(objDAL.SError))
                {
                    lblMensaje.Text = objDAL.SError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    CargarCategorias();
                    if (objDAL.CAccion == 'U')
                        lblMensaje.Text = "Registro editado correctamente";
                    else
                        lblMensaje.Text = "Registro ingresado correctamente";

                    lblMensaje.Visible = true;

                    lblMensaje.ForeColor = System.Drawing.Color.White;
                    updpnlGrid.Update();
                }


            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message.ToString();
            }
        }
    }
}