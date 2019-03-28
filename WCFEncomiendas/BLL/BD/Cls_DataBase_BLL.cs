using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.BD;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BLL.BD
{
    public class Cls_DataBase_BLL
    {
        public void CrearCnx(ref Cls_DataBase_DAL OBJ_DataBase_DAL)
        {
            try
            {
                OBJ_DataBase_DAL.SCxCadena = ConfigurationManager.ConnectionStrings["Windows_AUT"].ConnectionString;
                OBJ_DataBase_DAL.OBJ_Connection_DataBase = new SqlConnection(OBJ_DataBase_DAL.SCxCadena);
                OBJ_DataBase_DAL.SError = string.Empty;
            }
            catch (Exception ex)
            {
                OBJ_DataBase_DAL.SError = ex.Message.ToString();
                OBJ_DataBase_DAL.OBJ_Connection_DataBase = null;
                OBJ_DataBase_DAL.SCxCadena = string.Empty;
            }
        }

        public void Crear_Parametros(ref Cls_DataBase_DAL OBJ_DataBase_DAL)
        {
            try
            {
                OBJ_DataBase_DAL.dt_Parametros = new DataTable("Parametros");
                OBJ_DataBase_DAL.dt_Parametros.Columns.Add("Nombre");
                OBJ_DataBase_DAL.dt_Parametros.Columns.Add("Tipo");
                OBJ_DataBase_DAL.dt_Parametros.Columns.Add("Valor");

                OBJ_DataBase_DAL.SError = string.Empty;
            }
            catch (Exception Error)
            {
                OBJ_DataBase_DAL.SError = Error.Message.ToString();
                OBJ_DataBase_DAL.dt_Parametros = null;
            }

        }

        public void Execute_DataAdapter(ref Cls_DataBase_DAL OBJ_DataBase_DAL)
        {
            try
            {
                CrearCnx(ref OBJ_DataBase_DAL);

                if ((OBJ_DataBase_DAL.OBJ_Connection_DataBase != null) && (OBJ_DataBase_DAL.SError == string.Empty))
                {
                    if (OBJ_DataBase_DAL.OBJ_Connection_DataBase.State == ConnectionState.Closed)
                    {
                        OBJ_DataBase_DAL.OBJ_Connection_DataBase.Open();
                    }

                    OBJ_DataBase_DAL.OBJ_DataAdapter = new SqlDataAdapter(OBJ_DataBase_DAL.SSP_Nombre, OBJ_DataBase_DAL.OBJ_Connection_DataBase);

                    if (OBJ_DataBase_DAL.dt_Parametros.Rows.Count >= 1)
                    {
                        foreach (DataRow DR in OBJ_DataBase_DAL.dt_Parametros.Rows)
                        {
                            SqlDbType DBType = SqlDbType.VarChar;

                            switch (DR[1].ToString())
                            {
                                case "1":
                                    {
                                        DBType = SqlDbType.Int;
                                        break;
                                    }
                                case "2":
                                    {
                                        DBType = SqlDbType.VarChar;
                                        break;
                                    }
                                case "3":
                                    {
                                        DBType = SqlDbType.NVarChar;
                                        break;
                                    }
                                case "4":
                                    {
                                        DBType = SqlDbType.Char;
                                        break;
                                    }
                                case "5":
                                    {
                                        DBType = SqlDbType.NChar;
                                        break;
                                    }
                                case "6":
                                    {
                                        DBType = SqlDbType.Decimal;
                                        break;
                                    }
                                case "7":
                                    {
                                        DBType = SqlDbType.DateTime;
                                        break;
                                    }
                                default:

                                    DBType = SqlDbType.VarChar;
                                    break;
                            }

                            OBJ_DataBase_DAL.OBJ_DataAdapter.SelectCommand.Parameters.Add(DR[0].ToString(), DBType).Value = DR[2].ToString();
                        }
                    }

                    OBJ_DataBase_DAL.OBJ_DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    OBJ_DataBase_DAL.OBJ_DataAdapter.Fill(OBJ_DataBase_DAL.OBJ_DataSet, OBJ_DataBase_DAL.SNombreTabla);

                    OBJ_DataBase_DAL.SError = string.Empty;
                }

                OBJ_DataBase_DAL.SError = string.Empty;
            }
            catch (Exception Error)
            {
                OBJ_DataBase_DAL.SError = Error.Message.ToString();

            }
            finally
            {
                if (OBJ_DataBase_DAL.OBJ_Connection_DataBase != null)
                {
                    if (OBJ_DataBase_DAL.OBJ_Connection_DataBase.State == ConnectionState.Open)
                    {
                        OBJ_DataBase_DAL.OBJ_Connection_DataBase.Close();
                    }

                    OBJ_DataBase_DAL.OBJ_Connection_DataBase.Dispose();
                }
            }
        }

        public void Execute_NonQuery(ref Cls_DataBase_DAL OBJ_DataBase_DAL)
        {
            try
            {
                CrearCnx(ref OBJ_DataBase_DAL);

                if ((OBJ_DataBase_DAL.OBJ_Connection_DataBase != null) && (OBJ_DataBase_DAL.SError == string.Empty))
                {
                    if (OBJ_DataBase_DAL.OBJ_Connection_DataBase.State == ConnectionState.Closed)
                    {
                        OBJ_DataBase_DAL.OBJ_Connection_DataBase.Open();
                    }

                    OBJ_DataBase_DAL.OBJ_Command = new SqlCommand(OBJ_DataBase_DAL.SSP_Nombre, OBJ_DataBase_DAL.OBJ_Connection_DataBase);

                    if (OBJ_DataBase_DAL.dt_Parametros.Rows.Count >= 1)
                    {
                        foreach (DataRow DR in OBJ_DataBase_DAL.dt_Parametros.Rows)
                        {
                            SqlDbType DBType = SqlDbType.VarChar;

                            switch (DR[1].ToString())
                            {
                                case "1":
                                    {
                                        DBType = SqlDbType.Int;
                                        break;
                                    }
                                case "2":
                                    {
                                        DBType = SqlDbType.VarChar;
                                        break;
                                    }
                                case "3":
                                    {
                                        DBType = SqlDbType.NVarChar;
                                        break;
                                    }
                                case "4":
                                    {
                                        DBType = SqlDbType.Char;
                                        break;
                                    }
                                case "5":
                                    {
                                        DBType = SqlDbType.NChar;
                                        break;
                                    }
                                case "6":
                                    {
                                        DBType = SqlDbType.Decimal;
                                        break;
                                    }
                                case "7":
                                    {
                                        DBType = SqlDbType.DateTime;
                                        break;
                                    }
                                default:

                                    DBType = SqlDbType.VarChar;
                                    break;
                            }

                            OBJ_DataBase_DAL.OBJ_Command.Parameters.Add(DR[0].ToString(), DBType).Value = DR[2].ToString();
                        }
                    }

                    OBJ_DataBase_DAL.OBJ_Command.CommandType = CommandType.StoredProcedure;

                    OBJ_DataBase_DAL.OBJ_Command.ExecuteNonQuery();

                    OBJ_DataBase_DAL.SError = string.Empty;
                }

                OBJ_DataBase_DAL.SError = string.Empty;
            }
            catch (Exception Error)
            {
                OBJ_DataBase_DAL.SError = Error.Message.ToString();

            }
            finally
            {
                if (OBJ_DataBase_DAL.OBJ_Connection_DataBase != null)
                {
                    if (OBJ_DataBase_DAL.OBJ_Connection_DataBase.State == ConnectionState.Open)
                    {
                        OBJ_DataBase_DAL.OBJ_Connection_DataBase.Close();
                    }

                    OBJ_DataBase_DAL.OBJ_Connection_DataBase.Dispose();
                }
            }
        }

        public void Execute_Scalar(ref Cls_DataBase_DAL OBJ_DataBase_DAL)
        {
            try
            {
                CrearCnx(ref OBJ_DataBase_DAL);

                if ((OBJ_DataBase_DAL.OBJ_Connection_DataBase != null) && (OBJ_DataBase_DAL.SError == string.Empty))
                {
                    if (OBJ_DataBase_DAL.OBJ_Connection_DataBase.State == ConnectionState.Closed)
                    {
                        OBJ_DataBase_DAL.OBJ_Connection_DataBase.Open();
                    }

                    OBJ_DataBase_DAL.OBJ_Command = new SqlCommand(OBJ_DataBase_DAL.SSP_Nombre, OBJ_DataBase_DAL.OBJ_Connection_DataBase);

                    if (OBJ_DataBase_DAL.dt_Parametros.Rows.Count >= 1)
                    {
                        foreach (DataRow DR in OBJ_DataBase_DAL.dt_Parametros.Rows)
                        {
                            SqlDbType DBType = SqlDbType.VarChar;

                            switch (DR[1].ToString())
                            {
                                case "1":
                                    {
                                        DBType = SqlDbType.Int;
                                        break;
                                    }
                                case "2":
                                    {
                                        DBType = SqlDbType.VarChar;
                                        break;
                                    }
                                case "3":
                                    {
                                        DBType = SqlDbType.NVarChar;
                                        break;
                                    }
                                case "4":
                                    {
                                        DBType = SqlDbType.Char;
                                        break;
                                    }
                                case "5":
                                    {
                                        DBType = SqlDbType.NChar;
                                        break;
                                    }
                                case "6":
                                    {
                                        DBType = SqlDbType.Decimal;
                                        break;
                                    }
                                case "7":
                                    {
                                        DBType = SqlDbType.DateTime;
                                        break;
                                    }
                                default:

                                    DBType = SqlDbType.VarChar;
                                    break;
                            }

                            OBJ_DataBase_DAL.OBJ_Command.Parameters.Add(DR[0].ToString(), DBType).Value = DR[2].ToString();
                        }
                    }

                    OBJ_DataBase_DAL.OBJ_Command.CommandType = CommandType.StoredProcedure;

                    OBJ_DataBase_DAL.SScalarValue = OBJ_DataBase_DAL.OBJ_Command.ExecuteScalar().ToString();

                    OBJ_DataBase_DAL.SError = string.Empty;
                }

                OBJ_DataBase_DAL.SError = string.Empty;
            }
            catch (Exception Error)
            {
                OBJ_DataBase_DAL.SError = Error.Message.ToString();

            }
            finally
            {
                if (OBJ_DataBase_DAL.OBJ_Connection_DataBase != null)
                {
                    if (OBJ_DataBase_DAL.OBJ_Connection_DataBase.State == ConnectionState.Open)
                    {
                        OBJ_DataBase_DAL.OBJ_Connection_DataBase.Close();
                    }

                    OBJ_DataBase_DAL.OBJ_Connection_DataBase.Dispose();
                }
            }
        }
    }
}
