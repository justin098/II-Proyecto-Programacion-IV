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
    public partial class RolesporUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                DAL.Cat_Man.Cls_Membership_DAL objDAL = new DAL.Cat_Man.Cls_Membership_DAL();
                BLL.Cat_Man.Cls_Membership_BLL objBLL = new BLL.Cat_Man.Cls_Membership_BLL();
                objDAL.sUserLogin = Session["UserLogin"].ToString();
                objDAL.sPrivilegio = "Administrar_Roles";
                if (objBLL.HasPrivilege(ref objDAL))
                {
                    if (!IsPostBack)
                    {
                        this.Form.Attributes.Add("autocomplete", "off");
                        CargarUsuarios();
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

        private void CargarUsuarios()
        {
            Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
            Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

            gdvUsuarios.DataSource = null;
            gdvUsuarios.DataBind();

            objBLL.Listar(ref objDAL);
            if (objDAL.sError == string.Empty)
            {
                gdvUsuarios.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    gdvUsuarios.DataSource = objDAL.dtTablaPersonas;
                }
                else
                {
                    DataTable dt = objDAL.dtTablaPersonas;

                    EnumerableRowCollection<DataRow> query = from dtUsuarios in dt.AsEnumerable()
                                                             where dtUsuarios.Field<string>("Nombre").ToLower().Contains(txtBuscar.Value.ToLower())
                                                             select dtUsuarios;

                    DataView view = query.AsDataView();

                    gdvUsuarios.DataSource = view;

                }


                gdvUsuarios.DataBind();

                if (gdvUsuarios.Rows.Count > 0)
                {
                    gdvUsuarios.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvUsuarios.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblMensaje.Text = objDAL.sError;
            }
        }

        protected void gdvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvUsuarios.PageIndex = e.NewPageIndex;
            CargarUsuarios();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
            updpnlGrid.Update();
        }

        protected void gdvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Roles")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvUsuarios.Rows[index];
                String sCedula = gdvUsuarios.Rows[index].Cells[1].Text;
                lblHeader.InnerText = "Agregar Roles";
                updpnlModalHeader.Update();
                txtCedula.Value = sCedula;
                txtUsuario.Value = Server.HtmlDecode(gdvUsuarios.Rows[index].Cells[2].Text);
                CargarCombos();
                CargarRoles(sCedula);
                updpnlGrid.Update();
                updpnlModal.Update();
            }
        }

        public void CargarCombos()
        {
            Cls_Roles_BLL objBLL = new Cls_Roles_BLL();
            Cls_Roles_DAL objDAL = new Cls_Roles_DAL();

            objBLL.Listar(ref objDAL);

            if (objDAL.sError == string.Empty)
            {
                cmbRoles.DataSource = null;
                cmbRoles.DataSource = objDAL.dtTabla;

                cmbRoles.DataTextField = "Rol";
                cmbRoles.DataValueField = "Id_Rol";
                cmbRoles.DataBind();
                cmbRoles.SelectedIndex = 0;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Se presento un problema a la hora de cargar el combo de roles');", true);
            }
        }

        private void CargarRoles(string sCedula)
        {
            Cls_Roles_Personas_BLL objBLL = new Cls_Roles_Personas_BLL();
            Cls_Roles_Personas_DAL objDAL = new Cls_Roles_Personas_DAL();
            objDAL.sFiltro = sCedula;

            gdvRoles.DataSource = null;
            gdvRoles.DataBind();

            objBLL.Filtrar(ref objDAL);
            if (objDAL.sError == string.Empty)
            {
                gdvRoles.SelectedIndex = -1;
                gdvRoles.DataSource = objDAL.dtTabla;
                gdvRoles.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Se presento un problema a la hora de cargar el los roles');", true);
            }
        }

        protected void gdvRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvRoles.PageIndex = e.NewPageIndex;
            CargarRoles(txtCedula.Value.ToString().Trim());
        }

        protected void gdvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvRoles.Rows[index];
                String idRolPersona = gdvRoles.Rows[index].Cells[1].Text;

                Cls_Roles_Personas_BLL objBLL = new Cls_Roles_Personas_BLL();
                Cls_Roles_Personas_DAL objDAL = new Cls_Roles_Personas_DAL();

                objDAL.iRolPersona = Convert.ToInt32(idRolPersona.Trim());
                objBLL.Eliminar(ref objDAL);

                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Se presento un problema a la hora de eliminar el registro');", true);
                }
                else
                {
                    CargarRoles(txtCedula.Value.ToString().Trim());
                }
            }
        }

        protected void btnAgregarRol_Click(object sender, EventArgs e)
        {
            Cls_Roles_Personas_BLL objBLL = new Cls_Roles_Personas_BLL();
            Cls_Roles_Personas_DAL objDAL = new Cls_Roles_Personas_DAL();

            bool existRecord = false;

            for (int i = 0; i < gdvRoles.Rows.Count; i++)
            {
                String Rol = gdvRoles.Rows[i].Cells[2].Text;

                if (cmbRoles.SelectedItem.Text == Rol)
                {
                    existRecord = true;
                    break;
                }
            }

            if (!existRecord)
            {
                objDAL.sCedula = txtCedula.Value.ToString().Trim();
                objDAL.iRol = Convert.ToInt16(cmbRoles.SelectedValue.ToString().Trim());

                objBLL.Insertar(ref objDAL);

                CargarRoles(objDAL.sCedula);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('El rol ya existe para el usuario');", true);
            }
        }
    }
}