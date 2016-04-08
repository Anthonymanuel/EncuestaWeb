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
        public List<Encuestas> EncuestaPreguntasAbiertas { get; set; }
        public List<Encuestas> EncuestaPreguntasCerradas { get; set; }

        public Encuestas()
        {
            this.EncuestaId = 0;
            this.Entidad = "";
            this.Descripcion = "";
            this.EncuestaPreguntasAbiertas = new List<Encuestas>();
            this.EncuestaPreguntasCerradas = new List<Encuestas>();
        }

        public Encuestas(int encuestaId,int preguntaId,string descripcion)
        {
            this.EncuestaId = encuestaId;
            this.Descripcion = descripcion;
            this.PreguntaId = preguntaId;
        }

        public void AgregarPreguntasAbiertas(int encuestaId, int preguntaId, string descripcion)
        {
            this.EncuestaPreguntasAbiertas.Add(new Encuestas(encuestaId, preguntaId, descripcion));
        }

        public void AgregarPreguntasCerradas(int encuestaId, int preguntaId, string descripcion)
        {
            this.EncuestaPreguntasCerradas.Add(new Encuestas(encuestaId, preguntaId, descripcion));
        }
        public void LimpiarListas()
        {
            EncuestaPreguntasAbiertas.Clear();
            EncuestaPreguntasCerradas.Clear();
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
                foreach (var item in this.EncuestaPreguntasAbiertas)
                {
                    conexion.Ejecutar(String.Format("Insert Into EncuestaPreguntasAbiertas(EncuestaId,PreguntaAbiertaId,Descripcion) Values({0},{1},'{2}')", this.EncuestaId, item.PreguntaId, item.Descripcion));
                }
                foreach (var item in this.EncuestaPreguntasCerradas)
                {
                    conexion.Ejecutar(String.Format("Insert Into EncuestaPreguntasCerradas(EncuestaId,PreguntaCerradaId,Descripcion) Values({0},{1},'{2}')", this.EncuestaId, item.PreguntaId, item.Descripcion));
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
                    retorno = conexion.Ejecutar(String.Format("Delete EncuestaPreguntasAbiertas Where EncuestaId = {0};" +
                                                          "Delete EncuestaPreguntasCerradas Where EncuestaId = {0};", this.EncuestaId));
                    foreach (var item in this.EncuestaPreguntasAbiertas)
                    {
                        conexion.Ejecutar(String.Format("Insert Into EncuestaPreguntasAbiertas(EncuestaId,PreguntaAbiertaId,Descripcion) Values({0},{1},'{2}')", this.EncuestaId, item.PreguntaId, item.Descripcion));
                    }
                    foreach (var item in this.EncuestaPreguntasCerradas)
                    {
                        conexion.Ejecutar(String.Format("Insert Into EncuestaPreguntasCerradas(EncuestaId,PreguntaCerradaId,Descripcion) Values({0},{1},'{2}')", this.EncuestaId, item.PreguntaId, item.Descripcion));
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
                retorno = conexion.Ejecutar(String.Format("Delete EncuestaPreguntasAbiertas Where EncuestaId = {0};" +
                                                          "Delete EncuestaPreguntasCerradas Where EncuestaId = {0};"+
                                                          "Delete Encuestas Where EncuestaId = {0}" , this.EncuestaId));
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
            DataTable dtCerradas = new DataTable();
            DataTable dtAbiertas = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * From Encuestas Where EncuestaId = {0}", idBuscado));
            if (dt.Rows.Count > 0)
            {
                this.EncuestaId = (int)dt.Rows[0]["EncuestaId"];
                this.Entidad = dt.Rows[0]["Entidad"].ToString();
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                this.Fecha = dt.Rows[0]["Fecha"].ToString();

                
                dtCerradas = conexion.ObtenerDatos(String.Format("Select * From EncuestaPreguntasCerradas where EncuestaId = {0} ",this.EncuestaId));
                dtAbiertas = conexion.ObtenerDatos(String.Format("Select * From EncuestaPreguntasAbiertas where EncuestaId = {0} ", this.EncuestaId));
                LimpiarListas();

                foreach (DataRow item in dtCerradas.Rows)
                {
                    AgregarPreguntasCerradas((int)item["EncuestaId"],(int)item["PreguntaCerradaId"], item["Descripcion"].ToString());
                }
                foreach (DataRow item in dtAbiertas.Rows)
                {
                    AgregarPreguntasAbiertas((int)item["EncuestaId"], (int)item["PreguntaAbiertaId"], item["Descripcion"].ToString());
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
            return conexion.ObtenerDatos("Select " + Campos + " From Encuestas e inner join EncuestaPreguntasAbiertas a on  a.EncuestaId = e.EncuestaId"+ 
                                         " inner join EncuestaPreguntasCerradas c on c.EncuestaId = e.EncuestaId Where " +
                                          Condicion + " " + ordenFinal);
        }
    }
}
