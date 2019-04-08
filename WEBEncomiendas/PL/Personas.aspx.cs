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
    public partial class Personas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        protected void bntBuscar_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
            CargarPersonas();
        }

        protected void gdvPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvPersonas.PageIndex = e.NewPageIndex;
            CargarPersonas();
        }

        protected void gdvPersonas_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            lblMensaje.Visible = false;
            gdvPersonas.SelectedIndex = e.NewEditIndex;

            if (gdvPersonas.SelectedIndex != -1)
            {
                Session["Action"] = 'U';
                Session["Cedula"] =  gdvPersonas.SelectedRow.Cells[2].Text;
                Response.Redirect("EditarPersonas.aspx");
            }
        }

        protected void gdvPersonas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            lblMensaje.Visible = false;
            Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
            Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

            objDAL.sFiltro = e.Keys[0].ToString();
            objBLL.Eliminar(ref objDAL);

            if (!string.IsNullOrEmpty(objDAL.sError))
            {
                lblMensaje.Text = objDAL.sError;
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                CargarPersonas();
                lblMensaje.Text = "Registro eliminado correctamente";
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session["Action"] = 'I';
            Response.Redirect("EditarPersonas.aspx");
        }
    }
}