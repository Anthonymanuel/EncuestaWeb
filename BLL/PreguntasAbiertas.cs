using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class PreguntasAbiertas : ClaseMaestra
    {

        public int PreguntaAbiertaId { get; set; }
        public string Descripcion { get; set; }

        public PreguntasAbiertas()
        {
            this.PreguntaAbiertaId = 0;
            this.Descripcion = "";
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("Insert Into PreguntasAbiertas (Descripcion) Values('{0}')", this.Descripcion));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("Update PreguntasAbiertas Set Descripcion = '{0}' Where PreguntaAbiertaId = {1}", this.Descripcion, this.PreguntaAbiertaId));
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
                retorno = conexion.Ejecutar(String.Format("Alter table RespuestasAbiertas NOCHECK constraint ALL;" +
                                                            "Alter table Encuestas NOCHECK constraint ALL;" +
                                                            "Alter table EncuestaPreguntasCerradas NOCHECK constraint ALL;" +
                                                            "Alter table EncuestaPreguntasAbiertas NOCHECK constraint ALL;" +
                                                            "Delete PreguntasAbiertas Where PreguntaAbiertaId = {0}"+ 
                                                            "Alter table Encuestas CHECK constraint ALL;" +
                                                            "Alter table EncuestaPreguntasCerradas CHECK constraint ALL;" +
                                                            "Alter table EncuestaPreguntasAbiertas CHECK constraint ALL;"+
                                                            "Alter table RespuestasAbiertas CHECK constraint ALL;", this.PreguntaAbiertaId));
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

            dt = conexion.ObtenerDatos(String.Format("Select * From PreguntasAbiertas Where PreguntaAbiertaId = {0}", idBuscado));

            if (dt.Rows.Count > 0)
            {
                this.PreguntaAbiertaId = (int)dt.Rows[0]["PreguntaAbiertaId"];
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";

            if (!Orden.Equals(""))
                ordenFinal = " Order By " + Orden;

            return conexion.ObtenerDatos("Select " + Campos + " From PreguntasAbiertas Where " +
                                          Condicion + " " + ordenFinal);
        }
    }
}
