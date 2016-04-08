using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Usuarios : ClaseMaestra
    {
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        public string FechaInicio { get; set; }


        public Usuarios()
        {
            this.UsuarioId = 0;
            this.Nombres = "";
            this.Apellidos = "";
            this.NombreUsuario = "";
            this.Email = "";
            this.Telefono = "";
            this.Contrasena = "";
            this.FechaInicio = "";
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            try
            {
                retorno = conexion.Ejecutar(String.Format("Insert Into Usuarios(Nombres,Apellidos,NombreUsuario,Email,Telefono,Contrasena,FechaInicio) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", this.Nombres, this.Apellidos, this.NombreUsuario, this.Email, this.Telefono, this.Contrasena, this.FechaInicio));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            try
            {
                retorno = conexion.Ejecutar(String.Format("Update Usuarios Set Nombres = '{0}',Apellidos = '{1}',NombreUsuario = '{2}',Email = '{3}',Telefono= '{4}',Contrasena = '{5}',FechaInicio = '{6}' where UsuarioId = {7}", this.Nombres, this.Apellidos, this.NombreUsuario, this.Email, this.Telefono, this.Contrasena, this.FechaInicio, this.UsuarioId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            try
            {
                retorno = conexion.Ejecutar(String.Format("Delete Usuarios Where UsuarioId = {0} ", this.UsuarioId));
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
            dt = conexion.ObtenerDatos(String.Format("Select * From Usuarios Where UsuarioId = {0}", idBuscado));

            if (dt.Rows.Count > 0)
            {
                this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                this.Nombres = dt.Rows[0]["Nombres"].ToString();
                this.Apellidos = dt.Rows[0]["Apellidos"].ToString();
                this.NombreUsuario = dt.Rows[0]["NombreUsuario"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Contrasena = dt.Rows[0]["Contrasena"].ToString();
                this.Telefono = dt.Rows[0]["Telefono"].ToString();
                this.FechaInicio = dt.Rows[0]["FechaInicio"].ToString();
            }

            return dt.Rows.Count > 0;
        }
        public bool Login(string nombreUsuarios, string contrasena)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select * From Usuarios Where Email = '{0}' and Contrasena = '{1}' or NombreUsuario = '{2}' and Contrasena = '{3}' ", nombreUsuarios, contrasena, nombreUsuarios, contrasena));


            if (dt.Rows.Count > 0)
            {

                this.NombreUsuario = dt.Rows[0]["NombreUsuario"].ToString();
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Contrasena = dt.Rows[0]["Contrasena"].ToString();

            }

            return dt.Rows.Count > 0;
        }
        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";

            if (!Orden.Equals(""))
                ordenFinal = " Order by " + Orden;

            return conexion.ObtenerDatos("Select " + Campos + " From Usuarios Where " +
                                          Condicion + " " + ordenFinal);
        }
    }
}
