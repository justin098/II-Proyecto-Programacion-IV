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
    public partial class frmPersonas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Form.Attributes.Add("autocomplete", "off");
                CargarPersonas();
            }
        }

        private void CargarPersonas()
        {
            Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
            Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

            objBLL.Listar(ref objDAL);

            if (objDAL.sError == string.Empty)
            {
                gdvPersonas.SelectedIndex = -1;
                if (txtBuscar.Value == string.Empty)
                {
                    gdvPersonas.DataSource = objDAL.dtTablaPersonas;
                }
                else
                {
                    DataTable dt = objDAL.dtTablaPersonas;

                    EnumerableRowCollection<DataRow> query = from dtPersonas in dt.AsEnumerable()
                                                             where dtPersonas.Field<string>("Nombre").ToLower().Contains(txtBuscar.Value.ToLower())
                                                             select dtPersonas;

                    DataView view = query.AsDataView();

                    gdvPersonas.DataSource = view;

                }

                gdvPersonas.DataBind();

                if (gdvPersonas.Rows.Count > 0)
                {
                    gdvPersonas.Visible = true;
                    lblMensaje.Visible = false;
                    lblMensaje.Text = "";
                }
                else
                {
                    gdvPersonas.Visible = false;
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No hay datos que mostrar";
                }
            }
            else
            {
                lblMensaje.Text = objDAL.sError;
            }
        }

        protected void gdvPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvPersonas.PageIndex = e.NewPageIndex;
            CargarPersonas();
        }

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            CargarPersonas();
        }
    }
}