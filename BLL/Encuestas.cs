using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Encuestas : ClaseMaestra
    {

        public int EncuestaId { get; set; }
        public string Entidad { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public int PreguntaId { get; set; }
        public List<Preguntas> EncuestaPreguntas { get; set; }

        public Encuestas()
        {
            this.EncuestaId = 0;
            this.Entidad = "";
            this.Descripcion = "";
            this.EncuestaPreguntas = new List<Preguntas>();
        }

        public void AgregarPreguntas(int encuestaId, int preguntaId, string descripcion,int tipoDePregunta)
        {
            this.EncuestaPreguntas.Add(new Preguntas(encuestaId, preguntaId, descripcion,tipoDePregunta));
        }
        public void LimpiarListas()
        {
            EncuestaPreguntas.Clear();
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            int retorno = 0;
            object identity;
            try
            {
                identity = conexion.ObtenerValor(String.Format("Insert Into Encuestas(Entidad,Descripcion,Fecha) Values('{0}','{1}','{2}') Select @@Identity", this.Entidad, this.Descripcion, this.Fecha));
                int.TryParse(identity.ToString(), out retorno);

                this.EncuestaId = retorno;
                foreach (var item in this.EncuestaPreguntas)
                {
                    conexion.Ejecutar(String.Format("Insert Into EncuestasPreguntas(EncuestaId,PreguntaId) Values({0},{1})", this.EncuestaId, item.PreguntaId));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno > 0;
        }

        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("Update Encuestas Set Entidad = '{0}',Descripcion = '{1}',Fecha = '{2}' Where EncuestaId = {3}", this.Entidad, this.Descripcion, this.Fecha, this.EncuestaId));
                if (retorno)
                {
                    retorno = conexion.Ejecutar(String.Format("Delete EncuestasPreguntas Where EncuestaId = {0}", this.EncuestaId));
                    foreach (var item in this.EncuestaPreguntas)
                    {
                        conexion.Ejecutar(String.Format("Insert Into EncuestasPreguntas(EncuestaId,PreguntaId) Values({0},{1})", this.EncuestaId, item.PreguntaId));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("Delete EncuestasPreguntas Where EncuestaId = {0};" + 
                                                          "Delete Encuestas Where EncuestaId = {0}", this.EncuestaId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable dtPreguntas = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * From Encuestas Where EncuestaId = {0}", idBuscado));
            if (dt.Rows.Count > 0)
            {
                this.EncuestaId = (int)dt.Rows[0]["EncuestaId"];
                this.Entidad = dt.Rows[0]["Entidad"].ToString();
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                this.Fecha = dt.Rows[0]["Fecha"].ToString();


                dtPreguntas = conexion.ObtenerDatos(String.Format("Select * From EncuestasPreguntas where EncuestaId = {0} ", this.EncuestaId));
                LimpiarListas();

                foreach (DataRow item in dtPreguntas.Rows)
                {
                    Preguntas preguntas = new Preguntas();
                    preguntas.Buscar((int)item["PreguntaId"]);
                    AgregarPreguntas((int)item["EncuestaId"], (int)item["PreguntaId"],preguntas.Descripcion,preguntas.TipoDePregunta );
                }
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";

            if (!Orden.Equals(""))
                ordenFinal = " Orden By " + Orden;
            return conexion.ObtenerDatos("Select " + Campos + " From Encuestas  Where " +
                                          Condicion + " " + ordenFinal);
        }

        public DataTable ListadoResultado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";

            if (!Orden.Equals(""))
                ordenFinal = " Orden By " + Orden;
            return conexion.ObtenerDatos("Select " + Campos + " From Encuestas e inner join EncuestasPreguntas a on a.EncuestaId = e.EncuestaId" +
                                          " inner join Preguntas p on p.PreguntaId = a.PreguntaId inner join RespuestasAbiertas r on r.PreguntaId = p.PreguntaId  Where " +
                                          Condicion + " " + ordenFinal);
        }

        public DataTable ListadoPreguntas(string Campos, string Condicion)
        {
            ConexionDb conexion = new ConexionDb();


            return conexion.ObtenerDatos("Select " + Campos + " From Encuestas e inner Join EncuestasPreguntas q On e.EncuestaId = q.EncuestaId inner join Preguntas p on p.PreguntaId = q.PreguntaId "+ Condicion);
        }

      

    }
}