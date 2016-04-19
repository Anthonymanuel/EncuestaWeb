using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class RespuestasAbiertas : ClaseMaestra
    {

        public int RespuestaAbiertaId { get; set; }
        public int PreguntaId { get; set; }
        public string Descricpcion { get; set; }

        public RespuestasAbiertas()
        {
            this.RespuestaAbiertaId = 0;
            this.PreguntaId = 0;
            this.Descricpcion = "";
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("Insert Into RespuestasAbiertas(PreguntaId,Descripcion) Values({0},'{1}')", this.PreguntaId, this.Descricpcion));
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
                retorno = conexion.Ejecutar(String.Format("Update RespuestasAbiertas Set Descripcion = '{0}' Where RespuestaAbiertaId = {1})", this.Descricpcion, this.RespuestaAbiertaId));
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
                retorno = conexion.Ejecutar(String.Format("Delete RepuestasAbiertas Where RespuestaAbiertaId = {0})", this.PreguntaId));
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

            dt = conexion.ObtenerDatos(String.Format("Select * From RepuestasAbiertas Where RepuestaAbiertaId = {0}", idBuscado));

            if (dt.Rows.Count > 0)
            {
                this.RespuestaAbiertaId = (int)dt.Rows[0]["RespuestaAbiertaId"];
                this.PreguntaId = (int)dt.Rows[0]["PreguntaId"];
                this.Descricpcion = dt.Rows[0]["Descripcion"].ToString();
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";

            if (!Orden.Equals(""))
                ordenFinal = " Order By " + Orden;

            return conexion.ObtenerDatos("Select " + Campos + " From RespuestasAbiertas Where " +
                                          Condicion + " " + ordenFinal);
        }
    }
}
