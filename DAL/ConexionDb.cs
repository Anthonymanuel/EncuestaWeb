using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ConexionDb
    {
        private SqlConnection con;
        private SqlCommand Cmd;

        public ConexionDb()
        {

            //(@"Data Source=tcp:encuesta.database.windows.net,1433;Initial Catalog=EncuestaDb;User ID=Anthony@encuesta;Password=Admin01.");
            con = new SqlConnection(@"Data Source=tcp:encuesta.database.windows.net,1433;Initial Catalog=EncuestaDb;User ID=Anthony@encuesta;Password=Admin01."); //(@"Data Source=Anthony\SQLEXPRESS;Initial Catalog=EncuestasWebForm;Integrated Security=True");
            Cmd = new SqlCommand();

        }


        public bool Ejecutar(String ComandoSql)
        {
            bool retorno = false;

            try
            {
                con.Open();
                Cmd.Connection = con;
                Cmd.CommandText = ComandoSql;
                Cmd.ExecuteNonQuery();
                retorno = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return retorno;
        }

        public DataTable ObtenerDatos(String ComandoSql)
        {

            SqlDataAdapter adapter;
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                Cmd.Connection = con;
                Cmd.CommandText = ComandoSql;

                adapter = new SqlDataAdapter(Cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return dt;
        }


        public Object ObtenerValor(String ComandoSql)
        {
            Object retorno = null;

            try
            {
                con.Open();
                Cmd.Connection = con;
                Cmd.CommandText = ComandoSql;
                retorno = Cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return retorno;
        }

    }
}
