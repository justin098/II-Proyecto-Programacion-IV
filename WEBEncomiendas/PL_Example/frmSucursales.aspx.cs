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
    public partial class frmSucursales : System.Web.UI.Page
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

            objBLL.Listar(ref objDAL);

            if (objDAL.sError == string.Empty)
            {
                gdvSucursales.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    gdvSucursales.DataSource = objDAL.DtTabla;
                }
                else
                {
                    DataTable dt = objDAL.DtTabla;

                    EnumerableRowCollection<DataRow> query = from dtSucursales in dt.AsEnumerable()
                                                             where dtSucursales.Field<string>("Nombre").ToLower().Contains(txtBuscar.Value.ToLower())
                                                             select dtSucursales;

                    DataView view = query.AsDataView();

                    gdvSucursales.DataSource = view;

                }

                gdvSucursales.DataBind();

                if (gdvSucursales.Rows.Count > 0)
                {
                    gdvSucursales.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvSucursales.Visible = false;
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
            gdvSucursales.PageIndex = e.NewPageIndex;
            CargarSucursales();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarSucursales();
        }
    }
}