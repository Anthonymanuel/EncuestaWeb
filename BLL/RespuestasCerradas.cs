using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class RespuestasCerradas : ClaseMaestra
    {

        public int RespuestaCerradaId { get; set; }
        public int PreguntaId { get; set; }
        public int Respuestas { get; set; }
        public List<RespuestasCerradas> Respuesta { get; set; }

        public RespuestasCerradas()
        {
            this.RespuestaCerradaId = 0;
            this.PreguntaId = 0;
            this.Respuestas = 0;
            this.Respuesta = new List<RespuestasCerradas>();
        }

        public RespuestasCerradas(int preguntaId, int respuestas)
        {
            this.PreguntaId = preguntaId;
            this.Respuestas = respuestas;
        }

        public void AgregarRepuestas(int preguntaId, int respuestas)
        {
            this.Respuesta.Add(new RespuestasCerradas(preguntaId, respuestas));
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                conexion.Ejecutar(String.Format("Insert Into RespuestasCerradas(PreguntaId,Respuesta) Values({0},{1})", this.PreguntaId, this.Respuestas));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public override bool Editar()
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public override bool Buscar(int idBuscado)
        {
            throw new NotImplementedException();
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            throw new NotImplementedException();
        }
    }
}

