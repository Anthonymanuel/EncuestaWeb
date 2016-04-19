using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace EncuestaB0._1._0.Registros
{
    public partial class rPreguntas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Preguntas pregunta = new Preguntas();

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
            Preguntas pregunta = new Preguntas();
            PreguntaIdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            TipoPreguntaCerradaDropDownList.SelectedIndex = 0;
            RespuestasTextBox.Text = "";
            RespuestasPosiblesListBox.Items.Clear();
            ErrorLabel.Text = "";
            pregunta.LimpiarLista();
        }

        public void LlenarDatos(Preguntas pregunta)
        {
            pregunta.PreguntaId = Utilitarios.ConveritrId(PreguntaIdTextBox.Text);
            pregunta.Descripcion = DescripcionTextBox.Text;
            if (TipoDePreguntaDropDownList.SelectedIndex == 0)
            {
                pregunta.TipoDePregunta = 1;
                pregunta.SubTipoDePregunta = 0;
            }
            else if (TipoDePreguntaDropDownList.SelectedIndex == 1)
            {
                pregunta.TipoDePregunta = 2;
                if (TipoPreguntaCerradaDropDownList.SelectedIndex == 0)
                {
                    pregunta.SubTipoDePregunta = 1;

                }
                else if(TipoPreguntaCerradaDropDownList.SelectedIndex == 1)
                {
                    pregunta.SubTipoDePregunta = 2;
                }

            }
            foreach (var item in RespuestasPosiblesListBox.Items)
            {
                pregunta.AgregarRepuestasPosibles(1, item.ToString());
            }

        }

        public void LlenarCampos(Preguntas pregunta)
        {
            Limpiar();
            PreguntaIdTextBox.Text = pregunta.PreguntaId.ToString();
            DescripcionTextBox.Text = pregunta.Descripcion;
            if (pregunta.TipoDePregunta == 1)
            {
                TipoDePreguntaDropDownList.SelectedIndex = 0;
            }
            else
            {
                TipoDePreguntaDropDownList.SelectedIndex = 1;
            }

            if (pregunta.SubTipoDePregunta == 1)
            {
                TipoPreguntaCerradaDropDownList.SelectedIndex = 0;
            }
            else
            {
                TipoPreguntaCerradaDropDownList.SelectedIndex = 1;
            }
            foreach (var item in pregunta.RepuestasPosibles)
            {
                RespuestasPosiblesListBox.Items.Add(item.Respuestas);
            }

        }


        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Preguntas pregunta = new Preguntas();

            if (pregunta.Buscar(Utilitarios.ConveritrId(PreguntaIdTextBox.Text)))
            {
                LlenarCampos(pregunta);
                if (TipoDePreguntaDropDownList.SelectedIndex == 0)
                    TipoDePreguntaDropDownList_SelectedIndexChanged(sender, e);
                else
                    TipoDePreguntaDropDownList_SelectedIndexChanged(sender, e);
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "No existe el id", "Error", "Error");
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Preguntas pregunta = new Preguntas();
            LlenarDatos(pregunta);
            if (PreguntaIdTextBox.Text.Trim().Length == 0)
            {
                if (pregunta.Insertar())
                {
                    Limpiar();
                    Utilitarios.ShowToastr(this.Page, "Pregunta guardada", "Correcto", "success");
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "No se pudo guardar la pregunta", "Error", "Error");
                }
            }
            if (PreguntaIdTextBox.Text.Trim().Length > 0)
            {
                if (pregunta.Editar())
                {
                    Limpiar();
                    Utilitarios.ShowToastr(this.Page, "Pregunta editada", "Corecto", "success");
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "No se pudo editar la pregunta", "Error", "Error");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Preguntas pregunta = new Preguntas();
            pregunta.PreguntaId = Utilitarios.ConveritrId(PreguntaIdTextBox.Text);
            if (pregunta.Eliminar())
            {
                Limpiar();
                Utilitarios.ShowToastr(this.Page, "Pregunta eliminada", "Correcto", "Success");
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "No se pudo eliminar la pregunta", "Error", "Error");
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            if (RespuestasTextBox.Text.Trim().Length > 0)
            {
                RespuestasPosiblesListBox.Items.Add(RespuestasTextBox.Text);
                RespuestasTextBox.Text = "";
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "Ingresa una respuestas", "Advertencia", "Warning");
            }
        }

        protected void BorrarButton_Click(object sender, EventArgs e)
        {
            if (RespuestasPosiblesListBox.Items.IndexOf(RespuestasPosiblesListBox.SelectedItem) >= 0)
            {
                RespuestasPosiblesListBox.Items.RemoveAt(RespuestasPosiblesListBox.Items.IndexOf(RespuestasPosiblesListBox.SelectedItem));
                ErrorLabel.Text = "";
            }
            else
            {
                ErrorLabel.Text = "Debe seleccionar la repuestas para eliminarla";
            }

        }

        protected void TipoDePreguntaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoDePreguntaDropDownList.SelectedIndex == 0)
            {
                Label3.Visible = false;
                TipoPreguntaCerradaDropDownList.Visible = false;
                Label2.Visible = false;
                RespuestasTextBox.Visible = false;
                AgregarButton.Visible = false;
                Label1.Visible = false;
                RespuestasPosiblesListBox.Visible = false;
                BorrarButton.Visible = false;
            }
            if (TipoDePreguntaDropDownList.SelectedIndex == 1)
            {
                Label3.Visible = true;
                TipoPreguntaCerradaDropDownList.Visible = true;
                Label2.Visible = true;
                RespuestasTextBox.Visible = true;
                AgregarButton.Visible = true;
                Label1.Visible = true;
                RespuestasPosiblesListBox.Visible = true;
                BorrarButton.Visible = true;
            }
        }
    }
}