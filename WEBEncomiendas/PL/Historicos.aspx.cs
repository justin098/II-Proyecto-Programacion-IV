using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL.Cat_Man;
using DAL.Cat_Man;

namespace PL
{
    public partial class Historicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cls_Membership_DAL objMember = new Cls_Membership_DAL();
            if (Session["UserLogin"] != null)
            {
                objMember.sUserLogin = Session["UserLogin"].ToString();
                Usuario = objMember.sUserLogin;
                if (!IsPostBack)
                {
                    this.Form.Attributes.Add("autocomplete", "off");
                    CargarPedidosUsuario();
                }
            }
        }
        private string Usuario;
        private void CargarPedidosUsuario()
        {
            Cls_Paquetes_BLL objBLL = new Cls_Paquetes_BLL();
            Cls_Paquetes_DAL objDAL = new Cls_Paquetes_DAL();

            gdvPaquetes.DataSource = null;
            gdvPaquetes.DataBind();

            objBLL.Listar(ref objDAL);
            string prueba = txtBuscar.Value;
            if (objDAL.SError == string.Empty)
            {
                gdvPaquetes.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    DataTable dt = objDAL.DtTablaPaquetes;

                    EnumerableRowCollection<DataRow> query = from dtTablaPaquetes in dt.AsEnumerable()
                                                             where dtTablaPaquetes.Field<string>("Usuario").ToLower().Replace(" ", "").Contains(Usuario.ToLower().Replace(" ", ""))
                                                             select dtTablaPaquetes;

                    DataView view = query.AsDataView();

                    gdvPaquetes.DataSource = view;
                }
                else
                {
                    DataTable dt = objDAL.DtTablaPaquetes;

                    EnumerableRowCollection<DataRow> query = from dtSucursales in dt.AsEnumerable()
                                                             where dtSucursales.Field<string>("DetallePaquete").ToLower().Replace(" ", "").Contains(txtBuscar.Value.ToLower().Replace(" ", ""))
                                                             select dtSucursales;

                    DataView view = query.AsDataView();

                    gdvPaquetes.DataSource = view;

                }


                gdvPaquetes.DataBind();

                if (gdvPaquetes.Rows.Count > 0)
                {
                    gdvPaquetes.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvPaquetes.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblMensaje.Text = objDAL.SError;
            }
        }

        protected void gdvPaquetes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvPaquetes.PageIndex = e.NewPageIndex;
            CargarPedidosUsuario();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarPedidosUsuario();
            updpnlGrid.Update();
        }

    }
}