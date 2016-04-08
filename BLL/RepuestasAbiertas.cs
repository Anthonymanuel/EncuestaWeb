using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class RepuestasAbiertas : ClaseMaestra
    {

        public int RepuestaAbiertaId { get; set; }
        public int PreguntaAbiertaId { get; set; }
        public string Descricpcion { get; set; }

        public RepuestasAbiertas()
        {
            this.RepuestaAbiertaId = 0;
            this.PreguntaAbiertaId = 0;
            this.Descricpcion = "";
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("Insert Into RepuestasAbiertas(PreguntaAbiertaId,Descripcion) Values({0},'{1}')", this.PreguntaAbiertaId, this.Descricpcion));
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
                retorno = conexion.Ejecutar(String.Format("Update RepuestasAbiertas Set Descripcion = '{1}' Where RepuestaAbiertaId = {1})", this.Descricpcion, this.RepuestaAbiertaId));
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
                retorno = conexion.Ejecutar(String.Format("Delete RepuestasAbiertas Where RepuestaAbiertaId = {0})", this.PreguntaAbiertaId));
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
                this.RepuestaAbiertaId = (int)dt.Rows[0]["RepuestaAbiertaId"];
                this.PreguntaAbiertaId = (int)dt.Rows[0]["PreguntaAbiertaId"];
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

            return conexion.ObtenerDatos("Select " + Campos + " From RepuestasAbiertas Where " +
                                          Condicion + " " + ordenFinal);
        }
    }
}
