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
    public partial class Solicitud_Paquete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cls_Membership_DAL objMember = new Cls_Membership_DAL();
            Cls_Membership_BLL objBLL = new Cls_Membership_BLL();
            if (Session["UserLogin"] != null)
            {
                objMember.sUserLogin = Session["UserLogin"].ToString();
                Usuario = objMember.sUserLogin;
                objMember.sPrivilegio = "Cambiar_Estado";
                if (objBLL.HasPrivilege(ref objMember))
                {
                    if (!IsPostBack)
                    {
                        this.Form.Attributes.Add("autocomplete", "off");
                        CargarCategorias();
                        CargarServicios();
                        CargarSucursales();
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

        private string Usuario;

        private void BusquedaCliente()
        {
            Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
            Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

            objBLL.Listar(ref objDAL);

            DataTable dt = objDAL.dtTablaPersonas;

            EnumerableRowCollection<DataRow> query = from dtTablaPersonas in dt.AsEnumerable()
                                                     where dtTablaPersonas.Field<string>("Cedula").Equals(txtCedula.Value.Trim())
                                                     select dtTablaPersonas;

            DataView view = query.AsDataView();

            if (view.Count == 0)
            {
                txtCliente.Value = "No se encuentra cliente con esa cédula";
                txtCliente.Visible = true;
                btnRegistrar.Enabled = false;
                btnRegistrar.Visible = false;
                divTarjetas.Style.Add("display", "none");
                updIngreso.Update();
            }
            else
            {
                foreach (DataRowView row in view)
                {
                    string nombre = row["Nombre"].ToString();
                    if (!Convert.ToBoolean(row["Activo"].ToString()))
                    {
                        txtCliente.Value = "El cliente se encuentra inactivo";
                        txtCliente.Visible = true;
                        updIngreso.Update();
                    }
                    else
                    {
                        txtCliente.Visible = false;
                        txtNombreCliente.Value = row["Nombre"].ToString() + " " + row["Primer_Apellido"].ToString() + " " + row["Segundo_Apellido"].ToString();
                        txtCedula.Disabled = true;
                        btnBuscar.Visible = false;
                        btnBuscar.Enabled = false;
                        btnLimpiar.Enabled = true;
                        btnLimpiar.Visible = true;
                        if (chkRecoger.Checked)
                        {
                            divEntrega.Style.Add("display", "block");
                            divSucursal.Style.Add("display", "none");
                        }
                        else
                        {
                            divEntrega.Style.Add("display", "none");
                            divSucursal.Style.Add("display", "block");
                        }
                        divTarjetas.Style.Add("display", "block");
                        CargarTarjetas(row["Usuario"].ToString());
                        updIngreso.Update();
                    }
                }
            }


        }

        private void CargarCategorias()
        {
            Cls_Categoria_BLL objBLL = new Cls_Categoria_BLL();
            Cls_Categoria_DAL objDAL = new Cls_Categoria_DAL();

            ddlCategoria.DataSource = null;
            ddlCategoria.DataBind();

            objBLL.Listar(ref objDAL);

            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "Id_Categoria";

            ddlCategoria.DataSource = objDAL.DtTablaCategoria;
            ddlCategoria.DataBind();
        }

        private void CargarTarjetas(string cliente)
        {
            Cls_Tarjetas_BLL objBLL = new Cls_Tarjetas_BLL();
            Cls_Tarjetas_DAL objDAL = new Cls_Tarjetas_DAL();

            objDAL.SPersona = cliente;

            ddlTarjetas.DataSource = null;
            ddlTarjetas.DataBind();

            objBLL.Filtrar(ref objDAL);

            ddlTarjetas.DataTextField = "Numero_tarjeta";
            ddlTarjetas.DataValueField = "Numero_tarjeta";

            ddlTarjetas.DataSource = objDAL.DtTablaTarjetas;
            ddlTarjetas.DataBind();

            if (ddlTarjetas.Items.Count > 0)
            {
                ddlTarjetas.Visible = true;
                lblTarjetas.Visible = false;
                lblTarjetas.InnerText = "";
                btnRegistrar.Visible = true;
                btnRegistrar.Enabled = true;
            }
            else
            {
                ddlTarjetas.Visible = false;
                lblTarjetas.Visible = true;
                lblTarjetas.InnerText = "No hay tarjetas que mostrar, por favor agregar desde la opción de mi cuenta";
                btnRegistrar.Visible = false;
                btnRegistrar.Enabled = false;
            }
        }

        private void CargarServicios()
        {
            Cls_Servicios_BLL objBLL = new Cls_Servicios_BLL();
            Cls_Servicios_DAL objDAL = new Cls_Servicios_DAL();

            ddlServicios.DataSource = null;
            ddlServicios.DataBind();

            objBLL.Listar(ref objDAL);

            ddlServicios.DataTextField = "Tipo_Servicio";
            ddlServicios.DataValueField = "Id_Servicio";

            ddlServicios.DataSource = objDAL.DtTablaServicios;
            ddlServicios.DataBind();
        }
        private void CargarSucursales()
        {

            Cls_Sucursales_BLL objBLL = new Cls_Sucursales_BLL();
            Cls_Sucursales_DAL objDAL = new Cls_Sucursales_DAL();

            ddlSucursales.DataSource = null;
            ddlSucursales.DataBind();

            objBLL.Listar(ref objDAL);

            DataTable dt = objDAL.DtTabla;

            EnumerableRowCollection<DataRow> query = from dtSucursales in dt.AsEnumerable()
                                                     where dtSucursales.Field<bool>("Activo").Equals(true)
                                                     select dtSucursales;

            DataView view = query.AsDataView();

            ddlSucursales.DataTextField = "Nombre";
            ddlSucursales.DataValueField = "Id_Sucursal";

            ddlSucursales.DataSource = view;




            ddlSucursales.DataBind();



        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Paquetes_BLL objBLL = new Cls_Paquetes_BLL();
                Cls_Paquetes_DAL objDAL = new Cls_Paquetes_DAL();

                objDAL.SDescripcion = txtDescripcion.Value.ToString().Trim();
                objDAL.SPeso = Convert.ToDouble(txtPeso.Value.ToString().Trim().Replace(".", ","));
                objDAL.SIdCategoria = Convert.ToInt32(ddlCategoria.SelectedValue);
                objDAL.SIdEstado = 1;
                objDAL.SIdSucursal = Convert.ToInt32(ddlSucursales.SelectedValue);
                objDAL.SIdServicio = Convert.ToInt32(ddlServicios.SelectedValue);
                objDAL.SPersona = Usuario;
                objDAL.SRetiroDomicilio = chkRecoger.Checked;
                objDAL.SEntregaDomicilio = chkEntrega.Checked;
                if (chkEntrega.Checked)
                {
                    objDAL.SDireccionEntrega = txtDireccion.Value.ToString().Trim();
                }
                else
                {
                    objDAL.SDireccionEntrega = "No aplica";
                }
                objDAL.SNumeroTarjeta = ddlTarjetas.SelectedValue.ToString().Trim();
                objDAL.SSubtotal = Convert.ToDouble(txtSubtotal.Value.ToString().Trim().Replace(".", ","));
                objDAL.SImpuesto = Convert.ToDouble(txtSubtotal.Value.ToString().Trim().Replace(".", ",")) * 0.13;
                objDAL.SEnvio = Convert.ToDouble(txtEnvio.Value.ToString().Trim().Replace(".", ","));
                objDAL.STotal = Convert.ToDouble(txtTotal.Value.ToString().Trim().Replace(".", ","));
                objDAL.SPagado = true;

                objDAL.CAccion = 'I';
                objBLL.Insertar(ref objDAL);


                if (!string.IsNullOrEmpty(objDAL.SError))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Se ha producido un error al guardar');", true);
                }
                else
                {
                    CargarSucursales();
                    if (objDAL.CAccion == 'U')
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Se ha guardado exitosamente');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Se ha editado exitosamente');", true);
                    }

                    LimpiarCampos();
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Se ha producido una excepcion' );", true);
                txtMensaje.Value = ex.Message.ToString();
                txtMensaje.Visible = true;
                updpnlBusqueda.Update();
            }
        }

        private void LimpiarCampos()
        {
            divTarjetas.Style.Add("display", "none");
            divEntrega.Style.Add("display", "none");
            txtCedula.Disabled = false;
            txtCedula.Value = string.Empty;
            txtNombreCliente.Value = string.Empty;
            btnBuscar.Visible = true;
            btnBuscar.Enabled = true;
            btnLimpiar.Enabled = false;
            btnLimpiar.Visible = false;
            btnRegistrar.Visible = false;
            btnRegistrar.Enabled = false;
            txtDescripcion.Value = string.Empty;
            ddlCategoria.SelectedIndex = 0;
            chkEntrega.Checked = false;
            chkRecoger.Checked = false;
            ddlServicios.SelectedIndex = 0;
            ddlSucursales.SelectedIndex = 0;
            txtPeso.Value = string.Empty;
            txtCalculo.Value = "0";
            txtEnvio.Value = "0";
            txtSubtotal.Value = "0";
            txtTotal.Value = "0";
            ddlTarjetas.SelectedIndex = 0;
            txtMensaje.Value = string.Empty;
            txtMensaje.Visible = false;
            updIngreso.Update();
            updpnlBusqueda.Update();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BusquedaCliente();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            divTarjetas.Style.Add("display", "none");
            txtCedula.Disabled = false;
            btnBuscar.Visible = true;
            btnBuscar.Enabled = true;
            btnLimpiar.Enabled = false;
            btnLimpiar.Visible = false;
            btnRegistrar.Visible = false;
            btnRegistrar.Enabled = false;
            txtNombreCliente.Value = string.Empty;
            txtCedula.Value = string.Empty;
            ddlTarjetas.DataSource = null;
            ddlTarjetas.DataBind();
            updpnlBusqueda.Update();
            updIngreso.Update();
        }
    }
}