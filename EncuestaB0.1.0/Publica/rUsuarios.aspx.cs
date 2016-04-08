using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;

namespace EncuestaB0._1._0.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FechaInicioTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }


        public void LlenarDatos(Usuarios usuarios)
        {
            usuarios.NombreUsuario = NombreUsuarioTextBox.Text;
            usuarios.Nombres = NombresTextBox.Text;
            usuarios.Apellidos = ApellidosTextBox.Text;
            usuarios.Email = EmailTextBox.Text;
            usuarios.Telefono = TelefonoTextBox.Text;
            usuarios.Contrasena = ContrasenaTextBox.Text;
            usuarios.FechaInicio = FechaInicioTextBox.Text;
        }

        public void Limpiar()
        {
            NombreUsuarioTextBox.Text = "";
            NombresTextBox.Text = "";
            ApellidosTextBox.Text = "";
            EmailTextBox.Text = "";
            TelefonoTextBox.Text = "";
            ContrasenaTextBox.Text = "";
            ConfirmarContrasenaTextBox.Text = "";
            FechaInicioTextBox.Text = "";
        }

        protected void RegistrarseButton_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            LlenarDatos(usuarios);
            if (usuarios.Insertar())
            {
                Utilitarios.ShowToastr(this.Page, "Usuario registrado", "Correcto", "Success");
                FormsAuthentication.RedirectFromLoginPage(EmailTextBox.Text, false);
                Limpiar();
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "Error al registrar el usuario", "Error", "Error");
            }
        }

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}