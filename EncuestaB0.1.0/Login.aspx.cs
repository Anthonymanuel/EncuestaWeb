using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;

namespace EncuestaB0._1._0
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            if (usuario.Login(EmailTextBox.Text, ContrasenaTextBox.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(EmailTextBox.Text, RecordarmeCheckBox.Checked);
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "Error usuario o contraña incorrecto", "Error", "Error");
            }

        }
    }
}