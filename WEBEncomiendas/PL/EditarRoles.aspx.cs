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
    public partial class EditarRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Form.Attributes.Add("autocomplete", "off");
                CargarRoles();
            }
        }

        private void CargarRoles()
        {
            Cls_Roles_BLL objBLL = new Cls_Roles_BLL();
            Cls_Roles_DAL objDAL = new Cls_Roles_DAL();

            gdvRoles.DataSource = null;
            gdvRoles.DataBind();

            objBLL.Listar(ref objDAL);
            if (objDAL.sError == string.Empty)
            {
                gdvRoles.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    gdvRoles.DataSource = objDAL.dtTabla;
                }
                else
                {
                    DataTable dt = objDAL.dtTabla;

                    EnumerableRowCollection<DataRow> query = from dtRoles in dt.AsEnumerable()
                                                             where dtRoles.Field<string>("Rol").ToLower().Replace(" ", "").Contains(txtBuscar.Value.ToLower().Replace(" ", ""))
                                                             select dtRoles;

                    DataView view = query.AsDataView();

                    gdvRoles.DataSource = view;

                }

                gdvRoles.DataBind();

                if (gdvRoles.Rows.Count > 0)
                {
                    gdvRoles.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvRoles.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblMensaje.Text = objDAL.sError;
            }
        }

        protected void gdvRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvRoles.PageIndex = e.NewPageIndex;
            CargarRoles();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarRoles();
            updpnlGrid.Update();
        }

        protected void gdvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvRoles.Rows[index];
                String idRol = gdvRoles.Rows[index].Cells[2].Text;
                lblHeader.InnerText = "Editar Rol";
                updpnlModalHeader.Update();

                txtIdRol.Value = idRol;
                txtRol.Value = Server.HtmlDecode(gdvRoles.Rows[index].Cells[3].Text);
                txtDescripcion.Value = Server.HtmlDecode(gdvRoles.Rows[index].Cells[4].Text);
                CargarCombos();
                updpnlGrid.Update();
                lblIdRol.Visible = true;
                txtIdRol.Visible = true;
                updpnlModal.Update();
            }
            else if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvRoles.Rows[index];
                String idRol = gdvRoles.Rows[index].Cells[2].Text;
                lblMensaje.Visible = false;
                Cls_Roles_BLL objBLL = new Cls_Roles_BLL();
                Cls_Roles_DAL objDAL = new Cls_Roles_DAL();

                objDAL.iId_Rol = Convert.ToInt32(idRol.Trim());
                objBLL.Eliminar(ref objDAL);


                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    CargarRoles();
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Registro eliminado correctamente";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    updpnlGrid.Update();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                lblHeader.InnerText = "Agregar Rol";
                lblIdRol.Visible = false;
                txtIdRol.Visible = false;
                LimpiarCampos();
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
                Cls_Roles_BLL objBLL = new Cls_Roles_BLL();
                Cls_Roles_DAL objDAL = new Cls_Roles_DAL();

                objDAL.sRol = txtRol.Value.ToString().Trim();
                objDAL.sDescripcion = txtDescripcion.Value.ToString().Trim();
                if (txtIdRol.Visible == false)
                {
                    objDAL.cAccion = 'I';
                    objBLL.Insertar(ref objDAL);
                }
                else
                {
                    objDAL.iId_Rol = Convert.ToInt32(txtIdRol.Value.ToString().Trim());
                    objDAL.cAccion = 'U';
                    objBLL.Editar(ref objDAL);
                }

                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (objDAL.cAccion == 'U')
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Registro editado correctamente');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Registro agregado correctamente');", true);
                    }

                    CargarRoles();

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

        public void CargarCombos()
        {

        }

        private void LimpiarCampos()
        {
            txtIdRol.Value = string.Empty;
            txtRol.Value = string.Empty;
            txtDescripcion.Value = string.Empty;
            CargarCombos();
            updpnlModal.Update();
        }
    }
}