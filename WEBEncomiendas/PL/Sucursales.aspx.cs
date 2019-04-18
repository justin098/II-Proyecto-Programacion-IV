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
    public partial class Sucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarSucursales();
        }

        private void CargarSucursales()
        {
            Cls_Sucursales_BLL objBLL = new Cls_Sucursales_BLL();
            Cls_Sucursales_DAL objDAL = new Cls_Sucursales_DAL();

            rptSucursales.DataSource = null;
            rptSucursales.DataBind();

            objBLL.Listar(ref objDAL);
            if (objDAL.sError == string.Empty)
            {

                DataTable dt = objDAL.DtTabla;

                EnumerableRowCollection<DataRow> query = from dtSucursales in dt.AsEnumerable()
                                                         where dtSucursales.Field<bool>("Activo").Equals(true)
                                                         select dtSucursales;

                DataView view = query.AsDataView();

                rptSucursales.DataSource = view;




                rptSucursales.DataBind();

                if (rptSucursales.Items.Count > 0)
                {
                    lblRtpMensaje.Visible = false;
                    lblRtpMensaje.Text = "";
                }
                else
                {
                    lblRtpMensaje.Visible = true;
                    lblRtpMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblRtpMensaje.Text = objDAL.sError;
            }
        }

    }
}