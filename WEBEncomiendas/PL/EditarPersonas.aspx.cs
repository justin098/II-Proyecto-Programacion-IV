using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Cat_Man;
using DAL.Cat_Man;
using System.Data;

namespace PL
{
    public partial class EditarPersonas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // preguntar por session de login y redireccionar al inicio

                if (Session["Action"] != null)
                {
                    if (Convert.ToChar(Session["Action"].ToString()) == 'U')
                    {
                        if (Session["Cedula"] != null)
                        {
                            CargarPersona();
                        }
                        else
                            Response.Redirect("Personas.aspx");
                    }
                }
                else
                    Response.Redirect("Personas.aspx");
            }
        }

        private void CargarPersona()
        {
            Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
            Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

            objBLL.Listar(ref objDAL);

            if (objDAL.sError == string.Empty)
            {

                DataTable dt = objDAL.dtTablaPersonas;

                EnumerableRowCollection<DataRow> query = from dtPersonas in dt.AsEnumerable()
                                                         where dtPersonas.Field<string>("Cedula").ToLower().Contains(Session["Cedula"].ToString().ToLower())
                                                         select dtPersonas;

                DataView view = query.AsDataView();

                if (view.Count > 0)
                {
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
                    cmbProvincia.Value = view[0]["Provincia"].ToString();
                    txtCanton.Value = view[0]["Canton"].ToString();
                    txtDistrito.Value = view[0]["Distrito"].ToString();
                    txtDireccionExacta.Value = view[0]["Direccion_Exacta"].ToString();
                }
                else
                {
                    Response.Redirect("Personas.aspx");
                }
            }
            else
            {
                lblMensaje.Text = objDAL.sError;
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void bntAceptar_Click(object sender, EventArgs e)
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

            objDAL.sProvincia = cmbProvincia.Value;
            objDAL.sCanton = txtCanton.Value;
            objDAL.sDistrito = txtDistrito.Value;
            objDAL.sDireccionExacta = txtDireccionExacta.Value;

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
                Session["Action"] = objDAL.cAccion;
                Session["Cedula"] = objDAL.sCedula;
                CargarPersona();
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personas.aspx");
        }
    }
}