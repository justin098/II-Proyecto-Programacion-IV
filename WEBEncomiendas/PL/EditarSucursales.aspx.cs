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
    public partial class MantSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Form.Attributes.Add("autocomplete", "off");
                CargarSucursales();
            }
        }


        private void CargarSucursales()
        {
            Cls_Sucursales_BLL objBLL = new Cls_Sucursales_BLL();
            Cls_Sucursales_DAL objDAL = new Cls_Sucursales_DAL();

            gdvSucursal.DataSource = null;
            gdvSucursal.DataBind();

            objBLL.Listar(ref objDAL);
            string prueba = txtBuscar.Value;
            if (objDAL.sError == string.Empty)
            {
                gdvSucursal.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    gdvSucursal.DataSource = objDAL.DtTabla;
                }
                else
                {
                    DataTable dt = objDAL.DtTabla;

                    EnumerableRowCollection<DataRow> query = from dtSucursales in dt.AsEnumerable()
                                                             where dtSucursales.Field<string>("Nombre").ToLower().Contains(txtBuscar.Value.ToLower())
                                                             select dtSucursales;

                    DataView view = query.AsDataView();

                    gdvSucursal.DataSource = view;

                }


                gdvSucursal.DataBind();

                if (gdvSucursal.Rows.Count > 0)
                {
                    gdvSucursal.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvSucursal.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblMensaje.Text = objDAL.sError;
            }
        }



        protected void gdvSucursales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvSucursal.PageIndex = e.NewPageIndex;
            CargarSucursales();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarSucursales();
            updpnlGrid.Update();
        }

        protected void gdvSucursal_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvSucursal.Rows[index];
                String idSucursal = gdvSucursal.Rows[index].Cells[2].Text;
                lblHeader.InnerText = "Editar Sucursal";
                updpnlModalHeader.Update();
                txtIdSucursal.Value = idSucursal;
                txtNombreSucursal.Value = Server.HtmlDecode(gdvSucursal.Rows[index].Cells[3].Text);
                cmbProvincias.Value = Server.HtmlDecode(gdvSucursal.Rows[index].Cells[4].Text);
                txtCanton.Value = Server.HtmlDecode(gdvSucursal.Rows[index].Cells[5].Text);
                txtDistrito.Value = Server.HtmlDecode(gdvSucursal.Rows[index].Cells[6].Text);
                txtDireccion.Value = Server.HtmlDecode(gdvSucursal.Rows[index].Cells[7].Text);
                CheckBox cbox = (CheckBox)row.Cells[8].Controls[0];
                chkActivo.Checked = cbox.Checked;

                updpnlGrid.Update();
                lblIdSucursal.Visible = true;
                txtIdSucursal.Visible = true;
                updpnlModal.Update();

            }
            else if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdvSucursal.Rows[index];
                String idSucursal = gdvSucursal.Rows[index].Cells[2].Text;
                lblMensaje.Visible = false;
                Cls_Sucursales_BLL objBLL = new Cls_Sucursales_BLL();
                Cls_Sucursales_DAL objDAL = new Cls_Sucursales_DAL();

                objDAL.SId_Sucursal = Convert.ToInt32(idSucursal.Trim());
                objBLL.Eliminar(ref objDAL);


                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    CargarSucursales();
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
                lblHeader.InnerText = "Agregar Sucursal";
                lblIdSucursal.Visible = false;
                txtIdSucursal.Visible = false;
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
                Cls_Sucursales_BLL objBLL = new Cls_Sucursales_BLL();
                Cls_Sucursales_DAL objDAL = new Cls_Sucursales_DAL();

                objDAL.SNombre = txtNombreSucursal.Value.ToString().Trim();
                objDAL.SActivo = chkActivo.Checked;
                objDAL.SProvincia = cmbProvincias.Value.ToString().Trim();
                objDAL.SCanton = txtCanton.Value.ToString().Trim();
                objDAL.SDistrito = txtDistrito.Value.ToString().Trim();
                objDAL.SDireccionExacta = txtDireccion.Value.ToString().Trim();
                if (txtIdSucursal.Visible == false)
                {
                    objDAL.CAccion = 'I';
                    objBLL.Insertar(ref objDAL);
                }
                else
                {
                    objDAL.SId_Sucursal = Convert.ToInt32(txtIdSucursal.Value.ToString().Trim());
                    objDAL.CAccion = 'U';
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
                    CargarSucursales();
                    if (objDAL.CAccion == 'U')
                        lblMensaje.Text = "Registro editado correctamente";
                    else
                        lblMensaje.Text = "Registro ingresado correctamente";

                    lblMensaje.Visible = true;

                    lblMensaje.ForeColor = System.Drawing.Color.Green;
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