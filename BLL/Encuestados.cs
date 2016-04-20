using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Encuestados : ClaseMaestra
    {
        public int EncuestaId { get; set; }
        public int Cantidad { get; set; }



        public Encuestados()
        {
            this.EncuestaId = 0;
            this.Cantidad = 0;

        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                conexion.Ejecutar(String.Format("Insert Into Encuestados(EncuestaId,Cantidad) Values({0},{1})",this.EncuestaId, this.Cantidad));

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
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";

            if (!Orden.Equals(""))
                ordenFinal = " Orden By " + Orden;
            return conexion.ObtenerDatos("Select " + Campos + " From Encuestados");
        }
    }
}
