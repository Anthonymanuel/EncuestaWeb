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
    public partial class rPreguntasCerradas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                PreguntasCerradas pregunta = new PreguntasCerradas();

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
            PreguntaCerradaIdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            TipoPreguntaCerradaDropDownList.SelectedIndex = 0;
            RespuestasTextBox.Text = "";
            RespuestasPosiblesListBox.Items.Clear();
            ErrorLabel.Text = "";
        }

        public void LlenarDatos(PreguntasCerradas cerradas)
        {
            cerradas.PreguntaCerradaId = Utilitarios.ConveritrId(PreguntaCerradaIdTextBox.Text);
            cerradas.Descripcion = DescripcionTextBox.Text;
            if (TipoPreguntaCerradaDropDownList.SelectedIndex == 0)
            {
                cerradas.TipoDePreguntaCerrada = 1;
            }
            else if (TipoPreguntaCerradaDropDownList.SelectedIndex == 1)
            {
                cerradas.TipoDePreguntaCerrada = 2;
            }
            foreach (var item in RespuestasPosiblesListBox.Items)
            {
                cerradas.AgregarRepuestasPosibles(1, item.ToString());
            }
        }

        public void LlenarCampos(PreguntasCerradas cerradas)
        {
            PreguntaCerradaIdTextBox.Text = cerradas.PreguntaCerradaId.ToString();
            DescripcionTextBox.Text = cerradas.Descripcion;
            if (cerradas.TipoDePreguntaCerrada == 1)
            {
                TipoPreguntaCerradaDropDownList.SelectedIndex = 0;
            }
            else
            {
                TipoPreguntaCerradaDropDownList.SelectedIndex = 1;
            }
            foreach (var item in cerradas.RepuestasPosibles)
            {
                RespuestasPosiblesListBox.Items.Add(item.Respuestas);
            }
        }
        

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            PreguntasCerradas cerradas = new PreguntasCerradas();

            if (cerradas.Buscar(Utilitarios.ConveritrId(PreguntaCerradaIdTextBox.Text)))
            {
                LlenarCampos(cerradas);
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
            PreguntasCerradas cerradas = new PreguntasCerradas();
            LlenarDatos(cerradas);
            if (PreguntaCerradaIdTextBox.Text.Trim().Length == 0)
            {
                if (cerradas.Insertar())
                {
                    Limpiar();
                    Utilitarios.ShowToastr(this.Page, "Pregunta guardada", "Correcto", "success");
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "No se pudo guardar la pregunta", "Error", "Error");
                }
            }
            if (PreguntaCerradaIdTextBox.Text.Trim().Length > 0)
            {
                if (cerradas.Editar())
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
            PreguntasCerradas cerradas = new PreguntasCerradas();
            cerradas.PreguntaCerradaId = Utilitarios.ConveritrId(PreguntaCerradaIdTextBox.Text);
            if (cerradas.Eliminar())
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
            if (RespuestasPosiblesListBox.Items.IndexOf(RespuestasPosiblesListBox.SelectedItem) >= 0) {
                RespuestasPosiblesListBox.Items.RemoveAt(RespuestasPosiblesListBox.Items.IndexOf(RespuestasPosiblesListBox.SelectedItem));
                ErrorLabel.Text = "";
            }
            else
            {
                ErrorLabel.Text = "Debe seleccionar la repuestas para eliminarla";
            }

        }
    }
}