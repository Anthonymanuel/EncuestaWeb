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
    public partial class rEncuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Encuestas encuesta = new Encuestas();
                Preguntas preguntas = new Preguntas();

                if (Request.QueryString["idBuscado"] != null)
                {
                    int idBuscado = Utilitarios.ConveritrId(Request.QueryString["idBuscado"].ToString());
                    if (encuesta.Buscar(idBuscado))
                    {
                        LlenarCampos(encuesta);
                    }
                }
                
                PreguntasDropDownList.DataSource = preguntas.Listado("*", "1=1", ""); ;
                PreguntasDropDownList.DataTextField = "Descripcion";
                PreguntasDropDownList.DataValueField = "PreguntaId";
                PreguntasDropDownList.DataBind();

                AgregarGrid();

                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public void AgregarGrid()
        {
          
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Pregunta id"), new DataColumn("Descripcion"), new DataColumn("Tipo de pregunta") });
            PreguntasGridView.DataSource = dt;
            PreguntasGridView.DataBind();
            Session["Preguntas"] = dt;

        }


        public void LLenarDatos(Encuestas encuestas)
        {
            encuestas.EncuestaId = Utilitarios.ConveritrId(EncuestaIdTextBox.Text);
            encuestas.Entidad = EntidadTextBox.Text;
            encuestas.Descripcion = DescripcionTextBox.Text;
            encuestas.Fecha = FechaTextBox.Text;
            foreach (GridViewRow item in PreguntasGridView.Rows)
            {
                int tipoPregunta = 0;
                string tipo="";
                if(tipo.Equals("Abierta"))
                {
                    tipoPregunta = 1;
                }
                else
                {
                    tipoPregunta = 2;
                }
                encuestas.AgregarPreguntas(1, Utilitarios.ConveritrId(item.Cells[1].Text), item.Cells[2].Text,tipoPregunta);
            }
        }

        public void LlenarCampos(Encuestas encuesta)
        {

            DataTable dt = (DataTable)Session["Preguntas"];
            EncuestaIdTextBox.Text = encuesta.EncuestaId.ToString();
            EntidadTextBox.Text = encuesta.Entidad;
            DescripcionTextBox.Text = encuesta.Descripcion;
            FechaTextBox.Text = encuesta.Fecha;
            foreach (var item in encuesta.EncuestaPreguntas)
            {
                string tipo = "";
                if (item.TipoDePregunta == 1)
                {
                    tipo = "Abierta";
                }
                else
                {
                    tipo = "Cerrada";
                }
                dt.Rows.Add(item.PreguntaId, item.Descripcion,tipo);
            }

            PreguntasGridView.DataSource = dt;
            PreguntasGridView.DataBind();
        }

        public void Limpiar()
        {
            EncuestaIdTextBox.Text = "";
            EntidadTextBox.Text = "";
            DescripcionTextBox.Text = "";
            AgregarGrid();
        }

        public void BindData()
        {
            DataTable dt = (DataTable)Session["Preguntas"];
            Preguntas preguntas = new Preguntas();
            preguntas.Buscar(Utilitarios.ConveritrId(PreguntasDropDownList.SelectedValue));
            string tipo = "";
            if (preguntas.TipoDePregunta == 1)
            {
                tipo = "Abierta";
            }
            else
            {
                tipo = "Cerrada";
            }
            dt.Rows.Add(PreguntasDropDownList.SelectedValue, PreguntasDropDownList.SelectedItem.Text,tipo);
            PreguntasGridView.DataSource = dt;
            PreguntasGridView.DataBind();
            Session["Preguntas"] = dt;
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Encuestas encuestas = new Encuestas();
            AgregarGrid();
            if (encuestas.Buscar(Utilitarios.ConveritrId(EncuestaIdTextBox.Text)))
            {
                LlenarCampos(encuestas);
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, " No existe el id ", "Error", "Error");
            }
        }


        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Encuestas encuestas = new Encuestas();
            LLenarDatos(encuestas);
            if (EncuestaIdTextBox.Text.Trim().Length == 0)
            {
                if (encuestas.Insertar())
                {
                    Limpiar();
                    Utilitarios.ShowToastr(this.Page, "Encuesta Guardada", "Correcto", "Success");
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "No se pudo guardar la encuesta", "Error", "Error");

                }
            }
            if (EncuestaIdTextBox.Text.Trim().Length > 0)
            {
                if (encuestas.Editar())
                {
                    Limpiar();
                    Utilitarios.ShowToastr(this.Page, "Encuesta editada", "Correcto", "Success");
                }
                else
                {
                    Utilitarios.ShowToastr(this.Page, "No se pudo editar la encuesta", "Error", "Error");

                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Encuestas encuestas = new Encuestas();
            encuestas.EncuestaId = Utilitarios.ConveritrId(EncuestaIdTextBox.Text);
            if (encuestas.Eliminar())
            {
                Limpiar();
                Utilitarios.ShowToastr(this.Page, "Encuesta eliminada", "Correcto", "Success");
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, "No se pudo eliminar la encuesta", "Error", "Error");
            }
        }

        protected void PreguntasGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["Preguntas"];
            dt.Rows[Utilitarios.ConveritrId(e.RowIndex.ToString())].Delete();
            Session["Preguntas"] = dt;
            PreguntasGridView.DataSource = Session["Preguntas"] as DataTable;
            PreguntasGridView.DataBind();

        }

        protected void PreguntasGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PreguntasGridView.PageIndex = e.NewPageIndex;
            BindData();
        }

    }
}