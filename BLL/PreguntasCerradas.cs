using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;


namespace BLL
{
    public class PreguntasCerradas : ClaseMaestra
    {
        public int PreguntaCerradaId { get; set; }
        public string Descripcion { get; set; }
        public string Respuestas { get; set; }
        public int TipoDePreguntaCerrada { get; set; }
        public List<PreguntasCerradas> RepuestasPosibles { get; set; }

        public PreguntasCerradas()
        {
            this.PreguntaCerradaId = 0;
            this.Descripcion = "";
            this.Respuestas = "";
            this.TipoDePreguntaCerrada = 0;
            RepuestasPosibles = new List<PreguntasCerradas>();
        }

        public PreguntasCerradas(int preguntaCerradaId, string repuestas)
        {
            this.PreguntaCerradaId = preguntaCerradaId;
            this.Respuestas = repuestas;
        }

        public void AgregarRepuestasPosibles(int preguntaCerradaId, string repuestas)
        {
            this.RepuestasPosibles.Add(new PreguntasCerradas(preguntaCerradaId, repuestas));
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
                identity = conexion.ObtenerValor(String.Format("Insert Into PreguntasCerradas(Descripcion,TipoDePreguntaCerrada) Values('{0}',{1}) select @@Identity ", this.Descripcion, this.TipoDePreguntaCerrada));
                int.TryParse(identity.ToString(), out retorno);

                this.PreguntaCerradaId = retorno;
                foreach (var item in this.RepuestasPosibles)
                {
                    conexion.Ejecutar(String.Format("Insert Into RespuestasPosibles(PreguntaCerradaId,Respuestas) Values({0},'{1}')", this.PreguntaCerradaId, item.Respuestas));
                    conexion.Ejecutar(String.Format("Insert Into RespuestasCerradas(PreguntaCerradaId,Respuesta) Values({0},{1})", this.PreguntaCerradaId,0));
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
                retorno = conexion.Ejecutar(String.Format("Update PreguntasCerradas Set Descripcion = '{0}',TipoDePreguntaCerrada = {1} Where PreguntaCerradaId = {2}", this.Descripcion, this.TipoDePreguntaCerrada, this.PreguntaCerradaId));

                if (retorno)
                {
                    retorno = conexion.Ejecutar(String.Format("Delete RespuestasPosibles Where PreguntaCerradaId = {0};"+
                                                               "Delete RespuestasCerradas Where PreguntaCerradaId = {0}", this.PreguntaCerradaId));
                    foreach (var item in this.RepuestasPosibles)
                    {
                        conexion.Ejecutar(String.Format("Insert Into RespuestasPosibles(PreguntaCerradaId,Respuestas) Values({0},'{1}')", this.PreguntaCerradaId, item.Respuestas));
                        conexion.Ejecutar(String.Format("Insert Into RespuestasCerradas(PreguntaCerradaId,Respuesta) Values({0},{1})", this.PreguntaCerradaId, 0));
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
                retorno = conexion.Ejecutar(String.Format("Alter table RespuestasCerradas NOCHECK constraint ALL;" +
                                                             "Alter table Encuestas NOCHECK constraint ALL;" +
                                                            "Alter table EncuestaPreguntasCerradas NOCHECK constraint ALL;" +
                                                            "Alter table EncuestaPreguntasAbiertas NOCHECK constraint ALL;" + 
                                                            "Delete RespuestasPosibles Where PreguntaCerradaId = {0};" +
                                                          "Delete PreguntasCerradas Where PreguntaCerradaId = {0};"+
                                                            "Alter table Encuestas CHECK constraint ALL;" +
                                                            "Alter table EncuestaPreguntasCerradas CHECK constraint ALL;" +
                                                            "Alter table EncuestaPreguntasAbiertas CHECK constraint ALL;"+
                                                            "Alter table RespuestasCerradas  CHECK constraint ALL;", this.PreguntaCerradaId));
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
            dt = conexion.ObtenerDatos(String.Format("Select * From PreguntasCerradas Where PreguntaCerradaId = {0} ", idBuscado));

            if (dt.Rows.Count > 0)
            {
                this.PreguntaCerradaId = (int)dt.Rows[0]["PreguntaCerradaId"];
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                this.TipoDePreguntaCerrada = (int)dt.Rows[0]["TipoDePreguntaCerrada"];

                dtDetalle = conexion.ObtenerDatos(String.Format("Select * From RespuestasPosibles where PreguntaCerradaId = {0} ",idBuscado));

                LimpiarLista();
                foreach (DataRow item in dtDetalle.Rows)
                {
                    AgregarRepuestasPosibles((int)item["PreguntaCerradaId"], item["Respuestas"].ToString());
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

            return conexion.ObtenerDatos("Select " + Campos + " From PreguntasCerradas Where " +
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
