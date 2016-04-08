using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace EncuestaB0._1._0.Registros
{
    public partial class rPreguntasAbiertas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                PreguntasAbiertas pregunta = new PreguntasAbiertas();
                if (Request.QueryString["idBuscado"] != null)
                {
                    int idBuscado = Utilitarios.ConveritrId(Request.QueryString["idBuscado"].ToString());
                    if (idBuscado > 0)
                    {
                        pregunta.Buscar(idBuscado);
                        LlenarCampos(pregunta);
                    }
                }
            }
        }

        public void Limpiar()
        {
            PreguntaAbiertaIdTextBox.Text = "";
            DescricpionTextBox.Text = "";
        }

        public void LlenarDatos(PreguntasAbiertas pregunta)
        {
            pregunta.PreguntaAbiertaId = Utilitarios.ConveritrId(PreguntaAbiertaIdTextBox.Text);
            pregunta.Descripcion = DescricpionTextBox.Text;
        }

        public void LlenarCampos(PreguntasAbiertas pregunta)
        {
            PreguntaAbiertaIdTextBox.Text = pregunta.PreguntaAbiertaId.ToString();
            DescricpionTextBox.Text = pregunta.Descripcion;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            PreguntasAbiertas preguntas = new PreguntasAbiertas();
            if (preguntas.Buscar(Utilitarios.ConveritrId(PreguntaAbiertaIdTextBox.Text)))
            {
                LlenarCampos(preguntas);
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "Error no exite ese id", "Error", "Error");
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void DescripcionCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length < 10;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            PreguntasAbiertas preguntas = new PreguntasAbiertas();
            LlenarDatos(preguntas);


            if (PreguntaAbiertaIdTextBox.Text.Trim().Length == 0)
            {
                if (preguntas.Insertar() && Page.IsValid)
                {
                    Limpiar();
                    Utilitarios.ShowToastr(this.Page, "Pregunta registrada", "Correcto", "Success");
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al registrar la pregunta", "Error", "Error");
                }
            }
            else
            {
                if (preguntas.Editar())
                {
                    Limpiar();
                    Utilitarios.ShowToastr(this.Page, "Pregunta edita", "Correcto", "Success");
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al editar", "Error", "Error");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            PreguntasAbiertas preguntas = new PreguntasAbiertas();
            preguntas.PreguntaAbiertaId = Utilitarios.ConveritrId(PreguntaAbiertaIdTextBox.Text);
            if (PreguntaAbiertaIdTextBox.Text.Trim().Length > 0)
            {
                if (preguntas.Eliminar())
                {
                    Limpiar();
                    Utilitarios.ShowToastr(this.Page, "Pregunta elimanda", "Correcto", "success");
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "Error al eliminar la pregunta", "Error", "Error");
                }
            }
        }
    }
}