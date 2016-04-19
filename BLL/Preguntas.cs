using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Preguntas :ClaseMaestra
    {

        public int PreguntaId { get; set; }
        public int EncuestaId { get; set; }
        public string Descripcion { get; set; }
        public string Respuestas { get; set; }
        public int TipoDePregunta { get; set; }
        public int SubTipoDePregunta { get; set; }
        public List<Preguntas> RepuestasPosibles { get; set; }
        


        public Preguntas()
        {
            this.PreguntaId = 0;
            this.Descripcion = "";
            this.Respuestas = "";
            this.TipoDePregunta = 0;
            this.SubTipoDePregunta = 0;
            RepuestasPosibles = new List<Preguntas>();
        }

        public Preguntas(int encuestaId,int preguntaId, string descripcion,int tipoDePregunta)
        {
            this.PreguntaId = preguntaId;
            this.EncuestaId = encuestaId;
            this.Descripcion = descripcion;
            this.TipoDePregunta = tipoDePregunta;
        }

        public Preguntas(int preguntaId, string repuestas)
        {
            this.PreguntaId = preguntaId;
            this.Respuestas = repuestas;
        }

        public void AgregarRepuestasPosibles(int preguntaId, string repuestas)
        {
            this.RepuestasPosibles.Add(new Preguntas(preguntaId, repuestas));
        }

        public void LimpiarLista()
        {
            this.RepuestasPosibles.Clear();
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            int retorno = 0;
            object identity;
            try
            {
                identity = conexion.ObtenerValor(String.Format("Insert Into Preguntas(Descripcion,TipoDePregunta,SubTipoDePregunta) Values('{0}',{1},{2}) select @@Identity ", this.Descripcion, this.TipoDePregunta,this.SubTipoDePregunta));
                int.TryParse(identity.ToString(), out retorno);

                this.PreguntaId = retorno;
                foreach (var item in this.RepuestasPosibles)
                {
                    conexion.Ejecutar(String.Format("Insert Into RespuestasPosibles(PreguntaId,Respuestas) Values({0},'{1}')", this.PreguntaId, item.Respuestas));
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
                retorno = conexion.Ejecutar(String.Format("Update Preguntas Set Descripcion = '{0}',TipoDePregunta = {1},SubTipoDePregunta={2} Where PreguntaId = {3}", this.Descripcion, this.TipoDePregunta,this.SubTipoDePregunta, this.PreguntaId));

                if (retorno)
                {
                    retorno = conexion.Ejecutar(String.Format("Delete RespuestasPosibles Where PreguntaId = {0}",this.PreguntaId));
                    foreach (var item in this.RepuestasPosibles)
                    {
                        conexion.Ejecutar(String.Format("Insert Into RespuestasPosibles(PreguntaId,Respuestas) Values({0},'{1}')", this.PreguntaId, item.Respuestas));
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
                retorno = conexion.Ejecutar(String.Format("Delete RespuestasAbiertas Where PreguntaId = {0};" + 
                                                          "Delete RespuestasCerradas Where PreguntaId = {0};" + 
                                                          "Delete EncuestasPreguntas Where PreguntaId = {0};" + 
                                                          "Delete RespuestasPosibles Where PreguntaId = {0};" +
                                                          "Delete Preguntas Where  PreguntaId = {0};", this.PreguntaId));
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
            DataTable dtDetalle = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * From Preguntas Where PreguntaId = {0} ", idBuscado));

            if (dt.Rows.Count > 0)
            {
                this.PreguntaId = (int)dt.Rows[0]["PreguntaId"];
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                this.TipoDePregunta = (int)dt.Rows[0]["TipoDePregunta"];
                this.SubTipoDePregunta = (int)dt.Rows[0]["SubTipoDePregunta"];

                dtDetalle = conexion.ObtenerDatos(String.Format("Select * From RespuestasPosibles where PreguntaId = {0} ", idBuscado));

                LimpiarLista();
                foreach (DataRow item in dtDetalle.Rows)
                {
                    AgregarRepuestasPosibles((int)item["PreguntaId"], item["Respuestas"].ToString());
                }

            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";

            if (!Orden.Equals(""))
                ordenFinal = " Order By " + Orden;

            return conexion.ObtenerDatos("Select " + Campos + " From Preguntas Where " +
                                          Condicion + " " + ordenFinal);
        }


        public DataTable ListadoRespuestasPosbiles(string Campos, string Condicion)
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.ObtenerDatos("Select " + Campos + " From RespuestasPosibles Where " +
                                          Condicion);
        }

    

}
}
