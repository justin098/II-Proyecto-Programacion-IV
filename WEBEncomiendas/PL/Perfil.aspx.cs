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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                if (!IsPostBack)
                {
                    CargarUsuario();
                }
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        private void CargarUsuario()
        {
            Cls_Personas_BLL objBLL = new Cls_Personas_BLL();
            Cls_Personas_DAL objDAL = new Cls_Personas_DAL();

            objBLL.Listar(ref objDAL);

            if (objDAL.sError == string.Empty)
            {

                DataTable dt = objDAL.dtTablaPersonas;

                EnumerableRowCollection<DataRow> query = from dtPersonas in dt.AsEnumerable()
                                                         where dtPersonas.Field<string>("Usuario").ToLower().Contains(Session["UserLogin"].ToString().ToLower())
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
                    CargarCombos();
                    cmbProvincias.Text = view[0]["Provincia"].ToString();
                    SeleccionProvincia();
                    cmbCantones.Text = view[0]["Canton"].ToString();
                    SeleccionCanton();
                    cmbDistritos.Text = view[0]["Distrito"].ToString();
                    txtDireccion.Value = view[0]["Direccion_Exacta"].ToString();
                    txtCedula.Disabled = true;
                    chkSuperUsuario.Visible = false;
                    chkActivo.Visible = false;
                }
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

                objDAL.sProvincia = cmbProvincias.Text;
                objDAL.sCanton = cmbCantones.Text;
                objDAL.sDistrito = cmbDistritos.Text;
                objDAL.sDireccionExacta = txtDireccion.Value;

                objBLL.Editar(ref objDAL);

                if (!string.IsNullOrEmpty(objDAL.sError))
                {
                    lblMensaje.Text = objDAL.sError;
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "alert('Registro editado correctamente');", true);
                    CargarUsuario();

                }
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = ex.Message.ToString();
            }
        }

        protected void cmbProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleccionProvincia();
            SeleccionCanton();
        }

        protected void cmbCantones_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleccionCanton();
        }

        public void CargarCombos()
        {
            //Carga inicial
            cmbProvincias.Items.Clear();
            cmbProvincias.Items.Add("San Jose");
            cmbProvincias.Items.Add("Alajuela");
            cmbProvincias.Items.Add("Cartago");
            cmbProvincias.Items.Add("Heredia");
            cmbProvincias.Items.Add("Guanacaste");
            cmbProvincias.Items.Add("Puntarenas");
            cmbProvincias.Items.Add("Limon");
            SeleccionProvincia();
            SeleccionCanton();

        }

        private void SeleccionProvincia()
        {
            #region Cantones
            if (cmbProvincias.SelectedIndex == 0)
            {
                cmbCantones.Items.Clear();
                cmbCantones.Items.Add("Desamparados");
                cmbCantones.Items.Add("Acosta");
                cmbCantones.Items.Add("Alajuelita");
                cmbCantones.Items.Add("Aserrí");
                cmbCantones.Items.Add("Curridabat");
                cmbCantones.Items.Add("Dota");
                cmbCantones.Items.Add("Escazu");
                cmbCantones.Items.Add("Goicochea");
                cmbCantones.Items.Add("León Cortes Castro");
                cmbCantones.Items.Add("Montes de Oca");
                cmbCantones.Items.Add("Mora");
                cmbCantones.Items.Add("Moravia");
                cmbCantones.Items.Add("Perez Zeledon");
                cmbCantones.Items.Add("Puriscal");
                cmbCantones.Items.Add("San Jose");
                cmbCantones.Items.Add("Santa Ana");
                cmbCantones.Items.Add("Tarrazú");
                cmbCantones.Items.Add("Turrubares");
                cmbCantones.Items.Add("Vaszques de Coronado");
                cmbCantones.Items.Add("Tibás");
            }
            else if (cmbProvincias.SelectedIndex == 1)
            {
                cmbCantones.Items.Clear();
                cmbCantones.Items.Add("Alajuela");
                cmbCantones.Items.Add("Atenas");
                cmbCantones.Items.Add("Grecia");
                cmbCantones.Items.Add("Guatuso");
                cmbCantones.Items.Add("Los Chiles");
                cmbCantones.Items.Add("Naranjo");
                cmbCantones.Items.Add("Orotina");
                cmbCantones.Items.Add("Palmares");
                cmbCantones.Items.Add("Poás");
                cmbCantones.Items.Add("San Carlos");
                cmbCantones.Items.Add("San Ramón");
                cmbCantones.Items.Add("San Mateo");
                cmbCantones.Items.Add("Zarcero");
                cmbCantones.Items.Add("Valverde Vega");
                cmbCantones.Items.Add("Upala");
            }
            else if (cmbProvincias.SelectedIndex == 2)
            {
                cmbCantones.Items.Clear();
                cmbCantones.Items.Add("Cartago");
                cmbCantones.Items.Add("Paraíso");
                cmbCantones.Items.Add("La union");
                cmbCantones.Items.Add("Jimenez");
                cmbCantones.Items.Add("Turrialba");
                cmbCantones.Items.Add("Alvarado");
                cmbCantones.Items.Add("Oreamuno");
                cmbCantones.Items.Add("El Guarco");
            }
            else if (cmbProvincias.SelectedIndex == 6)
            {
                cmbCantones.Items.Clear();
                cmbCantones.Items.Add("Limon");
                cmbCantones.Items.Add("Pococi");
                cmbCantones.Items.Add("Siquirres");
                cmbCantones.Items.Add("Talamanca");
                cmbCantones.Items.Add("Matina");
                cmbCantones.Items.Add("Guacimo");
            }
            else if (cmbProvincias.SelectedIndex == 4)
            {
                cmbCantones.Items.Clear();
                cmbCantones.Items.Add("Liberia");
                cmbCantones.Items.Add("Nicoya");
                cmbCantones.Items.Add("Santa Cruz");
                cmbCantones.Items.Add("Bagaces");
                cmbCantones.Items.Add("Carillo");
                cmbCantones.Items.Add("Cañas");
                cmbCantones.Items.Add("Abangares");
                cmbCantones.Items.Add("Tilarán");
                cmbCantones.Items.Add("Nandayure");
                cmbCantones.Items.Add("La Cruz");
                cmbCantones.Items.Add("Hojancha");
            }
            else if (cmbProvincias.SelectedIndex == 3)
            {
                cmbCantones.Items.Clear();
                cmbCantones.Items.Add("Heredia");
                cmbCantones.Items.Add("Barva");
                cmbCantones.Items.Add("Santo Domingo");
                cmbCantones.Items.Add("Santa Bárbara");
                cmbCantones.Items.Add("San Rafael");
                cmbCantones.Items.Add("San Isidro");
                cmbCantones.Items.Add("Belén");
                cmbCantones.Items.Add("Flores");
                cmbCantones.Items.Add("San Pablo");
                cmbCantones.Items.Add("Sarapiquí");
            }
            else if (cmbProvincias.SelectedIndex == 5)
            {
                cmbCantones.Items.Clear();
                cmbCantones.Items.Add("Puntarenas");
                cmbCantones.Items.Add("Esparza");
                cmbCantones.Items.Add("Buenos Aires");
                cmbCantones.Items.Add("Montes de Oro");
                cmbCantones.Items.Add("Osa");
                cmbCantones.Items.Add("Quepos");
                cmbCantones.Items.Add("Golfito");
                cmbCantones.Items.Add("Coto Brus");
                cmbCantones.Items.Add("Parrita");
                cmbCantones.Items.Add("Corredores");
                cmbCantones.Items.Add("Garabito");
            }
            #endregion
            cmbDistritos.Items.Clear();
        }

        private void SeleccionCanton()
        {
            #region Distritos
            if (cmbProvincias.SelectedIndex == 0)
            {
                #region San José
                if (cmbCantones.SelectedIndex == 14)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Carmen");
                    cmbDistritos.Items.Add("Merced");
                    cmbDistritos.Items.Add("Hospital");
                    cmbDistritos.Items.Add("Catedral");
                    cmbDistritos.Items.Add("Zapote");
                    cmbDistritos.Items.Add("San Francisco de Dos Ríos");
                    cmbDistritos.Items.Add("Uruca");
                    cmbDistritos.Items.Add("Mata Redonda");
                    cmbDistritos.Items.Add("Pavas");
                    cmbDistritos.Items.Add("Hatillo");
                    cmbDistritos.Items.Add("San Sebastián");

                }
                else if (cmbCantones.SelectedIndex == 6)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Escazú");
                    cmbDistritos.Items.Add("San Antonio");
                    cmbDistritos.Items.Add("San Rafael");
                }
                else if (cmbCantones.SelectedIndex == 0)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Desamparados");
                    cmbDistritos.Items.Add("San Miguel");
                    cmbDistritos.Items.Add("San Juan de Dios");
                    cmbDistritos.Items.Add("San Rafael Arriba");
                    cmbDistritos.Items.Add("San Antonio");
                    cmbDistritos.Items.Add("Frailes");
                    cmbDistritos.Items.Add("Patarrá");
                    cmbDistritos.Items.Add("San Cristobal");
                    cmbDistritos.Items.Add("Rosario");
                    cmbDistritos.Items.Add("Damas");
                    cmbDistritos.Items.Add("San Rafael Abajo");
                    cmbDistritos.Items.Add("Gravilias");
                    cmbDistritos.Items.Add("Los Guido");
                }
                else if (cmbCantones.SelectedIndex == 13)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Santiago");
                    cmbDistritos.Items.Add("Mercedes Sur");
                    cmbDistritos.Items.Add("Barbacoas");
                    cmbDistritos.Items.Add("Grifo Alto");
                    cmbDistritos.Items.Add("San Rafael");
                    cmbDistritos.Items.Add("Candelarita");
                    cmbDistritos.Items.Add("Desamparaditos");
                    cmbDistritos.Items.Add("San Antonio");
                    cmbDistritos.Items.Add("Chires");
                }
                else if (cmbCantones.SelectedIndex == 16)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Marcos");
                    cmbDistritos.Items.Add("San Lorenzo");
                    cmbDistritos.Items.Add("San Carlos");
                }
                else if (cmbCantones.SelectedIndex == 3)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Aserrí");
                    cmbDistritos.Items.Add("Tarbaca");
                    cmbDistritos.Items.Add("Vuelta de Jorco");
                    cmbDistritos.Items.Add("San Gabriel");
                    cmbDistritos.Items.Add("Legua");
                    cmbDistritos.Items.Add("Monterrey");
                    cmbDistritos.Items.Add("Salitrillos");
                }
                else if (cmbCantones.SelectedIndex == 10)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Ciudad Colón");
                    cmbDistritos.Items.Add("Guayabo");
                    cmbDistritos.Items.Add("Tabarcia");
                    cmbDistritos.Items.Add("Piedras Negras");
                    cmbDistritos.Items.Add("Picagres");
                    cmbDistritos.Items.Add("Jaris");
                    cmbDistritos.Items.Add("Quitirrisí");
                }
                else if (cmbCantones.SelectedIndex == 7)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Guadalupe");
                    cmbDistritos.Items.Add("San Francisco");
                    cmbDistritos.Items.Add("Calle Blancos");
                    cmbDistritos.Items.Add("Mata de Plátano");
                    cmbDistritos.Items.Add("Ipís");
                    cmbDistritos.Items.Add("Rancho Redondo");
                    cmbDistritos.Items.Add("Purral");
                }
                else if (cmbCantones.SelectedIndex == 15)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Santa Ana");
                    cmbDistritos.Items.Add("Salitral");
                    cmbDistritos.Items.Add("Pozos");
                    cmbDistritos.Items.Add("Uruca");
                    cmbDistritos.Items.Add("Piedades");
                    cmbDistritos.Items.Add("Brasil");
                }
                else if (cmbCantones.SelectedIndex == 2)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Alajuelita");
                    cmbDistritos.Items.Add("San Josecito");
                    cmbDistritos.Items.Add("San Antonio");
                    cmbDistritos.Items.Add("Concepción");
                    cmbDistritos.Items.Add("San Felipe");
                }
                else if (cmbCantones.SelectedIndex == 18)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Isidro");
                    cmbDistritos.Items.Add("San Rafael");
                    cmbDistritos.Items.Add("Dulce Nombre de Jesús");
                    cmbDistritos.Items.Add("Patalillo");
                    cmbDistritos.Items.Add("Cascajal");
                }
                else if (cmbCantones.SelectedIndex == 1)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Ignacio");
                    cmbDistritos.Items.Add("Guaitil");
                    cmbDistritos.Items.Add("Palmichal");
                    cmbDistritos.Items.Add("Cangrejal");
                    cmbDistritos.Items.Add("Sabanillas");
                }
                else if (cmbCantones.SelectedIndex == 19)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Juan");
                    cmbDistritos.Items.Add("Cinco Esquinas");
                    cmbDistritos.Items.Add("Anselmo Llorente");
                    cmbDistritos.Items.Add("León XIII");
                    cmbDistritos.Items.Add("Colma");
                }
                else if (cmbCantones.SelectedIndex == 11)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Vicente");
                    cmbDistritos.Items.Add("San Jerónimo");
                    cmbDistritos.Items.Add("Trinidad");
                }
                else if (cmbCantones.SelectedIndex == 9)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Pedro");
                    cmbDistritos.Items.Add("Sabanilla");
                    cmbDistritos.Items.Add("Mercedes");
                    cmbDistritos.Items.Add("San Rafael");
                }
                else if (cmbCantones.SelectedIndex == 17)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Pablo");
                    cmbDistritos.Items.Add("San Pedro");
                    cmbDistritos.Items.Add("San Juan de Mata");
                    cmbDistritos.Items.Add("San Luis");
                    cmbDistritos.Items.Add("Carara");
                }
                else if (cmbCantones.SelectedIndex == 5)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Santa María");
                    cmbDistritos.Items.Add("Jardín");
                    cmbDistritos.Items.Add("Copey");
                }
                else if (cmbCantones.SelectedIndex == 4)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Curridabat");
                    cmbDistritos.Items.Add("Granadilla");
                    cmbDistritos.Items.Add("Sánchez");
                    cmbDistritos.Items.Add("Tirrases");
                }
                else if (cmbCantones.SelectedIndex == 12)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Isidro de El General");
                    cmbDistritos.Items.Add("El General");
                    cmbDistritos.Items.Add("Daniel Flores");
                    cmbDistritos.Items.Add("Rivas");
                    cmbDistritos.Items.Add("San Pedro");
                    cmbDistritos.Items.Add("Platanares");
                    cmbDistritos.Items.Add("Pejibaye");
                    cmbDistritos.Items.Add("Cajón");
                    cmbDistritos.Items.Add("Barú");
                    cmbDistritos.Items.Add("Rio Nuevo");
                    cmbDistritos.Items.Add("Páramo");
                    cmbDistritos.Items.Add("La Amistad");
                }
                else if (cmbCantones.SelectedIndex == 8)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Pablo");
                    cmbDistritos.Items.Add("San Andrés");
                    cmbDistritos.Items.Add("Llano Bonito");
                    cmbDistritos.Items.Add("San Isidro");
                    cmbDistritos.Items.Add("Santa Cruz");
                    cmbDistritos.Items.Add("San Antonio");
                }
                #endregion
            }
            else if (cmbProvincias.SelectedIndex == 1)
            {
                #region Alajuela
                if (cmbCantones.SelectedIndex == 0)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Alajuela");
                    cmbDistritos.Items.Add("San José");
                    cmbDistritos.Items.Add("Carrizal");
                    cmbDistritos.Items.Add("San Antonio");
                    cmbDistritos.Items.Add("Guácima");
                    cmbDistritos.Items.Add("San Isidro");
                    cmbDistritos.Items.Add("Sabanilla");
                    cmbDistritos.Items.Add("Río Segundo");
                    cmbDistritos.Items.Add("Desamparados");
                    cmbDistritos.Items.Add("Turrúcares");
                    cmbDistritos.Items.Add("Tambor");
                    cmbDistritos.Items.Add("Garita");
                    cmbDistritos.Items.Add("Sarapiquí");
                }
                else if (cmbCantones.SelectedIndex == 10)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Ramón");
                    cmbDistritos.Items.Add("Santiago");
                    cmbDistritos.Items.Add("San Juan");
                    cmbDistritos.Items.Add("Piedades Norte");
                    cmbDistritos.Items.Add("Piedades Sur");
                    cmbDistritos.Items.Add("San Rafael");
                    cmbDistritos.Items.Add("San Isidro");
                    cmbDistritos.Items.Add("Ángeles");
                    cmbDistritos.Items.Add("Alfaro");
                    cmbDistritos.Items.Add("Volio");
                    cmbDistritos.Items.Add("Concepción");
                    cmbDistritos.Items.Add("Zapotal");
                    cmbDistritos.Items.Add("Peñas Blancas");
                    cmbDistritos.Items.Add("San Lorenzo");
                }
                else if (cmbCantones.SelectedIndex == 2)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Grecia");
                    cmbDistritos.Items.Add("San Isidro");
                    cmbDistritos.Items.Add("San José");
                    cmbDistritos.Items.Add("San Roque");
                    cmbDistritos.Items.Add("Tacares");
                    cmbDistritos.Items.Add("Puente de Piedra");
                    cmbDistritos.Items.Add("Bolívar");
                }
                else if (cmbCantones.SelectedIndex == 11)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Mateo");
                    cmbDistritos.Items.Add("Desmonte");
                    cmbDistritos.Items.Add("Jesús María");
                    cmbDistritos.Items.Add("Labrador");
                }
                else if (cmbCantones.SelectedIndex == 1)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Atenas");
                    cmbDistritos.Items.Add("Jesús");
                    cmbDistritos.Items.Add("Mercedes");
                    cmbDistritos.Items.Add("San Isidro");
                    cmbDistritos.Items.Add("Concepción");
                    cmbDistritos.Items.Add("San José");
                    cmbDistritos.Items.Add("Santa Eulalia");
                    cmbDistritos.Items.Add("Escobal");
                }
                else if (cmbCantones.SelectedIndex == 5)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Naranjo");
                    cmbDistritos.Items.Add("San Miguel");
                    cmbDistritos.Items.Add("Cirrpi");
                    cmbDistritos.Items.Add("San Jerónimo");
                    cmbDistritos.Items.Add("San Juan");
                    cmbDistritos.Items.Add("San José");
                    cmbDistritos.Items.Add("El Rosario");
                    cmbDistritos.Items.Add("Palmitos");
                }
                else if (cmbCantones.SelectedIndex == 7)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Palmares");
                    cmbDistritos.Items.Add("Zaragoza");
                    cmbDistritos.Items.Add("Buenos Aires");
                    cmbDistritos.Items.Add("Santiago");
                    cmbDistritos.Items.Add("Candelaria");
                    cmbDistritos.Items.Add("Esquipulas");
                    cmbDistritos.Items.Add("La Granja");
                }
                else if (cmbCantones.SelectedIndex == 8)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Pedro");
                    cmbDistritos.Items.Add("San Juan");
                    cmbDistritos.Items.Add("San Rafael");
                    cmbDistritos.Items.Add("Carrillos");
                    cmbDistritos.Items.Add("Saban Redonda");
                }
                else if (cmbCantones.SelectedIndex == 6)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Orotina");
                    cmbDistritos.Items.Add("Mastate");
                    cmbDistritos.Items.Add("Hacienda Vieja");
                    cmbDistritos.Items.Add("Coyolar");
                    cmbDistritos.Items.Add("La Ceiba");
                }
                else if (cmbCantones.SelectedIndex == 9)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Quesada");
                    cmbDistritos.Items.Add("Florencia");
                    cmbDistritos.Items.Add("Buena Vista");
                    cmbDistritos.Items.Add("Aguas Zarcas");
                    cmbDistritos.Items.Add("Venecia");
                    cmbDistritos.Items.Add("Pital");
                    cmbDistritos.Items.Add("La Fortuna");
                    cmbDistritos.Items.Add("La Tigra");
                    cmbDistritos.Items.Add("La Palmera");
                    cmbDistritos.Items.Add("Venado");
                    cmbDistritos.Items.Add("Cutris");
                    cmbDistritos.Items.Add("Monterrey");
                    cmbDistritos.Items.Add("Pocosol");
                }
                else if (cmbCantones.SelectedIndex == 12)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Zarcero");
                    cmbDistritos.Items.Add("Laguna");
                    cmbDistritos.Items.Add("Tapezco");
                    cmbDistritos.Items.Add("Guadalupe");
                    cmbDistritos.Items.Add("Palmira");
                    cmbDistritos.Items.Add("Zapote");
                    cmbDistritos.Items.Add("Brisas");
                }
                else if (cmbCantones.SelectedIndex == 13)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Sarchí Norte");
                    cmbDistritos.Items.Add("Sarchí Sur");
                    cmbDistritos.Items.Add("Toro Amarillo");
                    cmbDistritos.Items.Add("San Pedro");
                    cmbDistritos.Items.Add("Rodríguez");
                }
                else if (cmbCantones.SelectedIndex == 14)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Upala");
                    cmbDistritos.Items.Add("Aguas Claras");
                    cmbDistritos.Items.Add("San José(Pizote)");
                    cmbDistritos.Items.Add("Bijagua");
                    cmbDistritos.Items.Add("Delicias");
                    cmbDistritos.Items.Add("Dos Ríos");
                    cmbDistritos.Items.Add("Yolillal");
                    cmbDistritos.Items.Add("Canalete");
                }
                else if (cmbCantones.SelectedIndex == 4)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Los Chiles");
                    cmbDistritos.Items.Add("Caño Negro");
                    cmbDistritos.Items.Add("El Amparo");
                    cmbDistritos.Items.Add("San Jorge");
                }
                else if (cmbCantones.SelectedIndex == 3)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Rafael");
                    cmbDistritos.Items.Add("Buenavista");
                    cmbDistritos.Items.Add("Cote");
                    cmbDistritos.Items.Add("Katira");
                    cmbDistritos.Items.Add("Río Cuarto");
                }
                #endregion
            }
            else if (cmbProvincias.SelectedIndex == 2)
            {
                #region Cartago
                if (cmbCantones.SelectedIndex == 0)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Oriental");
                    cmbDistritos.Items.Add("Occidental");
                    cmbDistritos.Items.Add("Carmen");
                    cmbDistritos.Items.Add("San Nicolás");
                    cmbDistritos.Items.Add("Agua Caliente");
                    cmbDistritos.Items.Add("Guadalupe");
                    cmbDistritos.Items.Add("Corralillo");
                    cmbDistritos.Items.Add("Tierra Blanca");
                    cmbDistritos.Items.Add("Dulce Nombre");
                    cmbDistritos.Items.Add("Llano Grande");
                    cmbDistritos.Items.Add("Quebradilla");
                }
                else if (cmbCantones.SelectedIndex == 1)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Paraíso");
                    cmbDistritos.Items.Add("Santiago de Paraíso");
                    cmbDistritos.Items.Add("Orosi");
                    cmbDistritos.Items.Add("Cachí");
                    cmbDistritos.Items.Add("Llanos de Santa Lucía");
                }
                else if (cmbCantones.SelectedIndex == 2)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Tres Ríos");
                    cmbDistritos.Items.Add("San Diego");
                    cmbDistritos.Items.Add("San Juan");
                    cmbDistritos.Items.Add("San Rafael");
                    cmbDistritos.Items.Add("Concepción");
                    cmbDistritos.Items.Add("Dulce Nombre");
                    cmbDistritos.Items.Add("San Ramón");
                    cmbDistritos.Items.Add("Río Azul");
                }
                else if (cmbCantones.SelectedIndex == 3)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Juan Viñas");
                    cmbDistritos.Items.Add("Tucurrique");
                    cmbDistritos.Items.Add("Pejibaye");
                }
                else if (cmbCantones.SelectedIndex == 4)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Turrialba");
                    cmbDistritos.Items.Add("La Suiza");
                    cmbDistritos.Items.Add("Peralta");
                    cmbDistritos.Items.Add("Santa Cruz");
                    cmbDistritos.Items.Add("Santa Teresita");
                    cmbDistritos.Items.Add("Pavones");
                    cmbDistritos.Items.Add("Tuis");
                    cmbDistritos.Items.Add("Tayutic");
                    cmbDistritos.Items.Add("Santa Rosa");
                    cmbDistritos.Items.Add("Tres Equis");
                    cmbDistritos.Items.Add("La Isabel");
                    cmbDistritos.Items.Add("Chirripó");
                }
                else if (cmbCantones.SelectedIndex == 5)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Pacayas");
                    cmbDistritos.Items.Add("Cervantes");
                    cmbDistritos.Items.Add("Capellades");
                }
                else if (cmbCantones.SelectedIndex == 6)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Rafael");
                    cmbDistritos.Items.Add("Cot");
                    cmbDistritos.Items.Add("Potreo Cerrado");
                    cmbDistritos.Items.Add("Cipreses");
                    cmbDistritos.Items.Add("Santa Rosa");
                }
                else if (cmbCantones.SelectedIndex == 7)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Tejar");
                    cmbDistritos.Items.Add("San Isidro");
                    cmbDistritos.Items.Add("Tobosi");
                    cmbDistritos.Items.Add("Patio de Agua");
                }
                #endregion
            }
            else if (cmbProvincias.SelectedIndex == 3)
            {
                #region Heredia
                if (cmbCantones.SelectedIndex == 0)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Heredia");
                    cmbDistritos.Items.Add("Mercedes");
                    cmbDistritos.Items.Add("San Francisco");
                    cmbDistritos.Items.Add("Ulloa");
                    cmbDistritos.Items.Add("Vara Blanca");
                }
                else if (cmbCantones.SelectedIndex == 1)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Barva");
                    cmbDistritos.Items.Add("San Pedro");
                    cmbDistritos.Items.Add("San Pablo");
                    cmbDistritos.Items.Add("San Roque");
                    cmbDistritos.Items.Add("Santa Lucía");
                    cmbDistritos.Items.Add("San José de la Montaña");
                }
                else if (cmbCantones.SelectedIndex == 2)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Santo Domingo");
                    cmbDistritos.Items.Add("San Vicente");
                    cmbDistritos.Items.Add("San Miguel");
                    cmbDistritos.Items.Add("Paracito");
                    cmbDistritos.Items.Add("Santo Tomás");
                    cmbDistritos.Items.Add("Santa Rosa");
                    cmbDistritos.Items.Add("Tures");
                    cmbDistritos.Items.Add("Pará");
                }
                else if (cmbCantones.SelectedIndex == 3)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Santa Bárbara");
                    cmbDistritos.Items.Add("San Pedro");
                    cmbDistritos.Items.Add("San Juan");
                    cmbDistritos.Items.Add("Jesús");
                    cmbDistritos.Items.Add("Santo Domingo");
                    cmbDistritos.Items.Add("Purabá");
                }
                else if (cmbCantones.SelectedIndex == 4)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Rafael");
                    cmbDistritos.Items.Add("San Josecito");
                    cmbDistritos.Items.Add("Santiago");
                    cmbDistritos.Items.Add("Ángeles");

                }
                else if (cmbCantones.SelectedIndex == 5)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Isidro");
                    cmbDistritos.Items.Add("Concepción");
                    cmbDistritos.Items.Add("San José");
                    cmbDistritos.Items.Add("San Francisco");
                }
                else if (cmbCantones.SelectedIndex == 6)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Antonio");
                    cmbDistritos.Items.Add("La Ribera");
                    cmbDistritos.Items.Add("San Miguel");
                    cmbDistritos.Items.Add("La Asunción");
                }
                else if (cmbCantones.SelectedIndex == 7)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Joaquín");
                    cmbDistritos.Items.Add("Barrantes");
                    cmbDistritos.Items.Add("Llorente");
                }
                else if (cmbCantones.SelectedIndex == 8)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Pablo");
                    cmbDistritos.Items.Add("Rincón de Sabanilla");
                }
                else if (cmbCantones.SelectedIndex == 9)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Puerto Viejo");
                    cmbDistritos.Items.Add("La Virgen");
                    cmbDistritos.Items.Add("Horquetas");
                    cmbDistritos.Items.Add("Llanuras del Gaspar");
                    cmbDistritos.Items.Add("Cureña");
                }
                #endregion
            }
            else if (cmbProvincias.SelectedIndex == 4)
            {
                #region Guanacaste
                if (cmbCantones.SelectedIndex == 0)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Liberia");
                    cmbDistritos.Items.Add("Cañas Dulces");
                    cmbDistritos.Items.Add("Mayorga");
                    cmbDistritos.Items.Add("Nacascolo");
                    cmbDistritos.Items.Add("Curubande");
                }
                else if (cmbCantones.SelectedIndex == 1)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Nicoya");
                    cmbDistritos.Items.Add("Mansión");
                    cmbDistritos.Items.Add("San Antonio");
                    cmbDistritos.Items.Add("Quebrada Honda");
                    cmbDistritos.Items.Add("Sámara");
                    cmbDistritos.Items.Add("Nosara");
                    cmbDistritos.Items.Add("Belén de Nosarita");
                }
                else if (cmbCantones.SelectedIndex == 2)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Santa Cruz");
                    cmbDistritos.Items.Add("Bolsón");
                    cmbDistritos.Items.Add("Veintisiete de Abril");
                    cmbDistritos.Items.Add("Tempate");
                    cmbDistritos.Items.Add("Cartagena");
                    cmbDistritos.Items.Add("Cuajiniquil");
                    cmbDistritos.Items.Add("Diriá");
                    cmbDistritos.Items.Add("Cabo Velas");
                    cmbDistritos.Items.Add("Tamarindo");
                }
                else if (cmbCantones.SelectedIndex == 3)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Bagaces");
                    cmbDistritos.Items.Add("La Fortuna");
                    cmbDistritos.Items.Add("Mogote");
                    cmbDistritos.Items.Add("Río Naranjo");
                }
                else if (cmbCantones.SelectedIndex == 4)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Filadelfia");
                    cmbDistritos.Items.Add("Palmira");
                    cmbDistritos.Items.Add("Sardinal");
                    cmbDistritos.Items.Add("Belén");
                }
                else if (cmbCantones.SelectedIndex == 5)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Cañas");
                    cmbDistritos.Items.Add("Palmira");
                    cmbDistritos.Items.Add("San Miguel");
                    cmbDistritos.Items.Add("Bebedero");
                    cmbDistritos.Items.Add("Porozal");
                }
                else if (cmbCantones.SelectedIndex == 6)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Las Juntas");
                    cmbDistritos.Items.Add("Sierra");
                    cmbDistritos.Items.Add("San Juan");
                    cmbDistritos.Items.Add("Colorado");
                }
                else if (cmbCantones.SelectedIndex == 7)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Tilarán");
                    cmbDistritos.Items.Add("Quebrada Grande");
                    cmbDistritos.Items.Add("Tronadora");
                    cmbDistritos.Items.Add("Santa Rosa");
                    cmbDistritos.Items.Add("Líbano");
                    cmbDistritos.Items.Add("Tierras Morenas");
                    cmbDistritos.Items.Add("Arenal");
                }
                else if (cmbCantones.SelectedIndex == 8)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Carmona");
                    cmbDistritos.Items.Add("Santa Rita");
                    cmbDistritos.Items.Add("Zapotal");
                    cmbDistritos.Items.Add("San Pablo");
                    cmbDistritos.Items.Add("Porvenir");
                    cmbDistritos.Items.Add("Bejuco");
                }
                else if (cmbCantones.SelectedIndex == 9)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("La Cruz");
                    cmbDistritos.Items.Add("Santa Cecilia");
                    cmbDistritos.Items.Add("La Garita");
                    cmbDistritos.Items.Add("Santa Elena");
                }
                else if (cmbCantones.SelectedIndex == 10)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Hojancha");
                    cmbDistritos.Items.Add("Monte Romo");
                    cmbDistritos.Items.Add("Puerto Carrillo");
                    cmbDistritos.Items.Add("Huacas");
                    cmbDistritos.Items.Add("Matambú");
                }
                #endregion
            }
            else if (cmbProvincias.SelectedIndex == 5)
            {
                #region Puntarenas
                if (cmbCantones.SelectedIndex == 0)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Puntarenas");
                    cmbDistritos.Items.Add("Pitahaya");
                    cmbDistritos.Items.Add("Chomes");
                    cmbDistritos.Items.Add("Lepanto");
                    cmbDistritos.Items.Add("Paquera");
                    cmbDistritos.Items.Add("Manzanillo");
                    cmbDistritos.Items.Add("Guacimal");
                    cmbDistritos.Items.Add("Barranca");
                    cmbDistritos.Items.Add("Monteverde");
                    cmbDistritos.Items.Add("Isla del Coco");
                    cmbDistritos.Items.Add("Cóbano");
                    cmbDistritos.Items.Add("Chacarita");
                    cmbDistritos.Items.Add("Chira");
                    cmbDistritos.Items.Add("Acapulco");
                    cmbDistritos.Items.Add("El Roble");
                    cmbDistritos.Items.Add("Arancibia");
                }
                else if (cmbCantones.SelectedIndex == 1)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Espíritu Santo");
                    cmbDistritos.Items.Add("San Juan Grande");
                    cmbDistritos.Items.Add("Macacona");
                    cmbDistritos.Items.Add("San Rafael");
                    cmbDistritos.Items.Add("San Jerónimo");
                    cmbDistritos.Items.Add("Caldera");
                }
                else if (cmbCantones.SelectedIndex == 2)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Buenos Aires");
                    cmbDistritos.Items.Add("Volcán");
                    cmbDistritos.Items.Add("Potrero Grande");
                    cmbDistritos.Items.Add("Boruca");
                    cmbDistritos.Items.Add("Pilas");
                    cmbDistritos.Items.Add("Colinas");
                    cmbDistritos.Items.Add("Chánguena");
                    cmbDistritos.Items.Add("Biolley");
                    cmbDistritos.Items.Add("Brunka");
                }
                else if (cmbCantones.SelectedIndex == 3)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Miramar");
                    cmbDistritos.Items.Add("La Unión");
                    cmbDistritos.Items.Add("San Isidro");
                }
                else if (cmbCantones.SelectedIndex == 4)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Cortés");
                    cmbDistritos.Items.Add("Palmar");
                    cmbDistritos.Items.Add("Sierpe");
                    cmbDistritos.Items.Add("Bahía Ballena");
                    cmbDistritos.Items.Add("Piedras Blancas");
                    cmbDistritos.Items.Add("Bahía Drake");
                }
                else if (cmbCantones.SelectedIndex == 5)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Quepos");
                    cmbDistritos.Items.Add("Savegre");
                    cmbDistritos.Items.Add("Naranjito");
                }
                else if (cmbCantones.SelectedIndex == 6)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Golfito");
                    cmbDistritos.Items.Add("Puerto Jiménez");
                    cmbDistritos.Items.Add("Guaycará");
                    cmbDistritos.Items.Add("Pavón");
                }
                else if (cmbCantones.SelectedIndex == 7)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("San Vito");
                    cmbDistritos.Items.Add("Sabalito");
                    cmbDistritos.Items.Add("Tronadora");
                    cmbDistritos.Items.Add("Aguabuena");
                    cmbDistritos.Items.Add("Limoncito");
                    cmbDistritos.Items.Add("Pittier");
                    cmbDistritos.Items.Add("Gutiérrez Brown");
                }
                else if (cmbCantones.SelectedIndex == 8)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Parrita");
                }
                else if (cmbCantones.SelectedIndex == 9)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Corredor");
                    cmbDistritos.Items.Add("La Cuesta");
                    cmbDistritos.Items.Add("Paso Canoas");
                    cmbDistritos.Items.Add("Laurel");
                }
                else if (cmbCantones.SelectedIndex == 10)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Jacó");
                    cmbDistritos.Items.Add("Tárcoles");
                }
                #endregion
            }
            else if (cmbProvincias.SelectedIndex == 6)
            {
                #region Limón
                if (cmbCantones.SelectedIndex == 0)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Limón");
                    cmbDistritos.Items.Add("Valle La Estrella");
                    cmbDistritos.Items.Add("Río Blanco");
                    cmbDistritos.Items.Add("Matama");
                }
                else if (cmbCantones.SelectedIndex == 1)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Guápiles");
                    cmbDistritos.Items.Add("Jiménez");
                    cmbDistritos.Items.Add("La Rita");
                    cmbDistritos.Items.Add("Roxana");
                    cmbDistritos.Items.Add("Cariari");
                    cmbDistritos.Items.Add("Colorado");
                    cmbDistritos.Items.Add("La Colonia");
                }
                else if (cmbCantones.SelectedIndex == 2)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Siquirres");
                    cmbDistritos.Items.Add("Pacuarito");
                    cmbDistritos.Items.Add("Florida");
                    cmbDistritos.Items.Add("Germania");
                    cmbDistritos.Items.Add("Cairo");
                    cmbDistritos.Items.Add("Alegría");
                }
                else if (cmbCantones.SelectedIndex == 3)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Bratsi");
                    cmbDistritos.Items.Add("Sixaola");
                    cmbDistritos.Items.Add("Cahuita");
                    cmbDistritos.Items.Add("Telire");
                }
                else if (cmbCantones.SelectedIndex == 4)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Matina");
                    cmbDistritos.Items.Add("Batán");
                    cmbDistritos.Items.Add("Carrandi");
                }
                else if (cmbCantones.SelectedIndex == 5)
                {
                    cmbDistritos.Items.Clear();
                    cmbDistritos.Items.Add("Guácimo");
                    cmbDistritos.Items.Add("Mercedes");
                    cmbDistritos.Items.Add("Pocora");
                    cmbDistritos.Items.Add("Río Jiménez");
                    cmbDistritos.Items.Add("Duacari");
                }
                #endregion
            }
            #endregion
        }
    }
}