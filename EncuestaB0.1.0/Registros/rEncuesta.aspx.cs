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
    public partial class rEncuesta1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Encuestas encuesta = new Encuestas();

                if (Request.QueryString["idBuscado"] != null)
                {
                    int idBuscado = Utilitarios.ConveritrId(Request.QueryString["idBuscado"].ToString());
                    if (encuesta.Buscar(idBuscado))
                    {
                        LlenarCampos(encuesta);
                    }
                }
                DropDow();
                BindGrid();
                AgregarGrid();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public void DropDow()
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            PreguntasCerradas cerradas = new PreguntasCerradas();
            PreguntasAbiertas abiertas = new PreguntasAbiertas();
            dt = abiertas.Listado("*", "1=1", "");
            dt2 = cerradas.Listado("*", "1=1", "");

            PreguntasAbiertasDropDownList.DataSource = dt;
            PreguntasAbiertasDropDownList.DataTextField = "Descripcion";
            PreguntasAbiertasDropDownList.DataValueField = "PreguntaAbiertaId";
            PreguntasAbiertasDropDownList.DataBind();


            PreguntasCerradasDropDownList.DataSource = dt2;
            PreguntasCerradasDropDownList.DataTextField = "Descripcion";
            PreguntasCerradasDropDownList.DataValueField = "PreguntaCerradaId";
            PreguntasCerradasDropDownList.DataBind();
        }

        public void AgregarGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PreguntaId");
            dt.Columns.Add("Telefono");
            PreguntasAbiertasGridView.DataSource = dt;
            PreguntasAbiertasGridView.DataBind();
            Session["Abiertas"] = dt;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("PreguntaId");
            dt2.Columns.Add("Descripcion");
            PreguntasCerradasGridView.DataSource = dt2;
            PreguntasCerradasGridView.DataBind();
            Session["Cerradas"] = dt2;

        }
        public void BindGrid()
        {

            PreguntasAbiertasGridView.DataSource = Session["Abiertas"] as DataTable;
            PreguntasAbiertasGridView.DataBind();
            PreguntasCerradasGridView.DataSource = Session["Cerradas"] as DataTable;
            PreguntasCerradasGridView.DataBind();
        }

        public void LLenarDatos(Encuestas encuestas)
        {
            encuestas.EncuestaId = Utilitarios.ConveritrId(EncuestaIdTextBox.Text);
            encuestas.Entidad = EntidadTextBox.Text;
            encuestas.Descripcion = DescripcionTextBox.Text;
            encuestas.Fecha = FechaTextBox.Text;
            foreach (GridViewRow item in PreguntasAbiertasGridView.Rows)
            {
                encuestas.AgregarPreguntasAbiertas(1, Utilitarios.ConveritrId(item.Cells[0].Text), item.Cells[1].Text);
            }

            foreach (GridViewRow item in PreguntasCerradasGridView.Rows)
            {
                encuestas.AgregarPreguntasCerradas(1, Utilitarios.ConveritrId(item.Cells[0].Text), item.Cells[1].Text);
            }
        }


        public void LlenarCampos(Encuestas encuesta)
        {

            DataTable dt = (DataTable)Session["Abiertas"];
            DataTable dt2 = (DataTable)Session["Cerradas"];
            EncuestaIdTextBox.Text = encuesta.EncuestaId.ToString();
            EntidadTextBox.Text = encuesta.Entidad;
            DescripcionTextBox.Text = encuesta.Descripcion;
            FechaTextBox.Text = encuesta.Fecha;
            foreach (var item in encuesta.EncuestaPreguntasAbiertas)
            {
                dt.Rows.Add(item.PreguntaId, item.Descripcion);
            }
            foreach (var item in encuesta.EncuestaPreguntasCerradas)
            {
                dt2.Rows.Add(item.PreguntaId, item.Descripcion);
            }

            PreguntasAbiertasGridView.DataSource = dt;
            PreguntasAbiertasGridView.DataBind();
            PreguntasCerradasGridView.DataSource = dt2;
            PreguntasCerradasGridView.DataBind();
        }

        public void Limpiar()
        {
            EncuestaIdTextBox.Text = "";
            EntidadTextBox.Text = "";
            DescripcionTextBox.Text = "";
            PreguntasAbiertasGridView.DataSource = null;
            PreguntasAbiertasGridView.DataBind();
            Session.Remove("Abiertas");
            Session.Remove("Cerradas");
            PreguntasCerradasGridView.DataSource = null;
            PreguntasCerradasGridView.DataBind();
          
            
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Encuestas encuestas = new Encuestas();
            
            if (encuestas.Buscar(Utilitarios.ConveritrId(EncuestaIdTextBox.Text)))
            {
                LlenarCampos(encuestas);
            }
            else
            {
                Utilitarios.ShowToastr(this.Page, " No existe el id ", "Error", "Error");
            }
        }

        protected void AgregarCButton_Click(object sender, EventArgs e)
        {
            DataTable dt2 = (DataTable)Session["Cerradas"];
            dt2.Rows.Add(PreguntasCerradasDropDownList.SelectedValue, PreguntasCerradasDropDownList.SelectedItem.Text);
            PreguntasCerradasGridView.DataSource = dt2;
            PreguntasCerradasGridView.DataBind();
            Session["Cerradas"] = dt2;
        }

        protected void AgregarAButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["Abiertas"];
            dt.Rows.Add(PreguntasAbiertasDropDownList.SelectedValue, PreguntasAbiertasDropDownList.SelectedItem.Text);
            PreguntasAbiertasGridView.DataSource = dt;
            PreguntasAbiertasGridView.DataBind();
            Session["Abiertas"] = dt;
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
                if (PreguntasAbiertasGridView != null && PreguntasCerradasGridView != null && encuestas.Insertar())
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
                if (PreguntasAbiertasGridView != null && PreguntasCerradasGridView != null && encuestas.Editar())
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

       
        protected void PreguntasCerradasGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["Cerradas"];
            dt.Rows[Utilitarios.ConveritrId((e.RowIndex).ToString())].Delete();
            Session["Cerradas"] = dt;
            AgregarGrid();

        }

        protected void PreguntasCerradasGridView_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["Cerradas"];
            dt.Rows[Utilitarios.ConveritrId(e.RowIndex.ToString())].Delete();
            Session["Cerradas"] = dt;
            BindGrid();
        }

        protected void PreguntasAbiertasGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["Abiertas"];
            dt.Rows[Utilitarios.ConveritrId(e.RowIndex.ToString())].Delete();
            Session["Abiertas"] = dt;
            BindGrid();
        }
    }
}