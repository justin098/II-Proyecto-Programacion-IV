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
    public partial class EditarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Form.Attributes.Add("autocomplete", "off");
                CargarUsuarios();
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

            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvUsuarios.Rows[index];
                String sCedula = gdvUsuarios.Rows[index].Cells[2].Text;

                Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
                Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

                objBLL.Listar(ref objDAL);

                if (objDAL.sError == string.Empty)
                {

                    DataTable dt = objDAL.dtTablaPersonas;

                    EnumerableRowCollection<DataRow> query = from dtPersonas in dt.AsEnumerable()
                                                             where dtPersonas.Field<string>("Cedula").ToLower().Contains(sCedula.ToLower())
                                                             select dtPersonas;

                    DataView view = query.AsDataView();

                    if (view.Count > 0)
                    {
                        lblHeader.InnerText = "Editar Usuario";
                        updpnlModalHeader.Update();
                        txtCedula.Value = view[0]["Cedula"].ToString();
                        txtNombre.Value = view[0]["Nombre"].ToString();
                        txtPrimerApellido.Value = view[0]["Primer_Apellido"].ToString();
                        txtSegundoApellido.Value = view[0]["Segundo_Apellido"].ToString();
                        txtEmail.Value = view[0]["Email"].ToString();
                        txtTelefono1.Value = view[0]["Telefono1"].ToString();
                        txtTelefono2.Value = view[0]["Telefono2"].ToString();
                        txtUsuario.Value = view[0]["Usuario"].ToString();
                        txtContrasenia.Value = view[0]["Contrasena"].ToString();
                        chkSuperUsuario.Checked = Convert.ToBoolean(view[0]["Super_Usuario"].ToString());
                        chkActivo.Checked = Convert.ToBoolean(view[0]["Activo"].ToString());
                        cmbProvincias.Value = view[0]["Provincia"].ToString();
                        txtCanton.Value = view[0]["Canton"].ToString();
                        txtDistrito.Value = view[0]["Distrito"].ToString();
                        txtDireccion.Value = view[0]["Direccion_Exacta"].ToString();
                        txtCedula.Disabled = true;
                        Session["Action"] = 'U';
                        updpnlGrid.Update();
                        updpnlModal.Update();
                    }
                }
            }
            else if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvUsuarios.Rows[index];
                String sCedula = gdvUsuarios.Rows[index].Cells[2].Text;
                lblMensaje.Visible = false;

                Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
                Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

                objDAL.sFiltro = sCedula;
                objBLL.Eliminar(ref objDAL);

                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    CargarUsuarios();
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
                lblHeader.InnerText = "Agregar Usuario";
                Session["Action"] = 'I';
                txtCedula.Value = string.Empty;
                txtNombre.Value = string.Empty;
                txtPrimerApellido.Value = string.Empty;
                txtSegundoApellido.Value = string.Empty;
                txtEmail.Value = string.Empty;
                txtTelefono1.Value = string.Empty;
                txtTelefono2.Value = string.Empty;
                txtUsuario.Value = string.Empty;
                txtContrasenia.Value = string.Empty;
                chkSuperUsuario.Checked = false;
                chkActivo.Checked = false;
                cmbProvincias.Value = string.Empty;
                txtCanton.Value = string.Empty;
                txtDistrito.Value = string.Empty;
                txtDireccion.Value = string.Empty;
                txtCedula.Disabled = false;
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
                Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
                Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

                objDAL.sCedula = txtCedula.Value;
                objDAL.sNombre = txtNombre.Value;
                objDAL.sPrimerApellido = txtPrimerApellido.Value;
                objDAL.sSegundoApellido = txtSegundoApellido.Value;
                objDAL.sEmail = txtEmail.Value;
                objDAL.sTelefono1 = txtTelefono1.Value;
                objDAL.sTelefono2 = txtTelefono2.Value;
                objDAL.sUsuario = txtUsuario.Value;
                objDAL.sContrasenia = txtContrasenia.Value;
                if (chkSuperUsuario.Checked)
                    objDAL.sSuperUsuario = "true";
                else
                    objDAL.sSuperUsuario = "false";

                if (chkActivo.Checked)
                    objDAL.sActivo = "true";
                else
                    objDAL.sActivo = "false";

                objDAL.sProvincia = cmbProvincias.Value;
                objDAL.sCanton = txtCanton.Value;
                objDAL.sDistrito = txtDistrito.Value;
                objDAL.sDireccionExacta = txtDireccion.Value;

                if (Convert.ToChar(Session["Action"].ToString()) == 'U')
                    objBLL.Editar(ref objDAL);
                else
                    objBLL.Insertar(ref objDAL);

                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (Convert.ToChar(Session["Action"].ToString()) == 'U')
                        lblMensaje.Text = "Registro editado correctamente";
                    else
                        lblMensaje.Text = "Registro ingresado correctamente";
                    CargarUsuarios();

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