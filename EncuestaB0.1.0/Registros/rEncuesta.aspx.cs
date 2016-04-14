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
                PreguntasCerradas cerradas = new PreguntasCerradas();
                PreguntasAbiertas abiertas = new PreguntasAbiertas();

                if (Request.QueryString["idBuscado"] != null)
                {
                    int idBuscado = Utilitarios.ConveritrId(Request.QueryString["idBuscado"].ToString());
                    if (encuesta.Buscar(idBuscado))
                    {
                        LlenarCampos(encuesta);
                    }
                }
                
                PreguntasAbiertasDropDownList.DataSource = abiertas.Listado("*", "1=1", "");
                PreguntasAbiertasDropDownList.DataTextField = "Descripcion";
                PreguntasAbiertasDropDownList.DataValueField = "PreguntaAbiertaId";
                PreguntasAbiertasDropDownList.DataBind();


                PreguntasCerradasDropDownList.DataSource = cerradas.Listado("*", "1=1", ""); ;
                PreguntasCerradasDropDownList.DataTextField = "Descripcion";
                PreguntasCerradasDropDownList.DataValueField = "PreguntaCerradaId";
                PreguntasCerradasDropDownList.DataBind();

                AgregarGrid();

                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public void AgregarGrid()
        {

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Pregunta abierta id"), new DataColumn("Descripcion") });
            PreguntasAbiertasGridView.DataSource = dt;
            PreguntasAbiertasGridView.DataBind();
            Session["Abiertas"] = dt;

            DataTable dt2 = new DataTable();
            dt2.Columns.AddRange(new DataColumn[2] { new DataColumn("Pregunta cerrada id"), new DataColumn("Descripcion") });
            PreguntasCerradasGridView.DataSource = dt2;
            PreguntasCerradasGridView.DataBind();
            Session["Cerradas"] = dt2;
                
        }

        
        public void LLenarDatos(Encuestas encuestas)
        {
            encuestas.EncuestaId = Utilitarios.ConveritrId(EncuestaIdTextBox.Text);
            encuestas.Entidad = EntidadTextBox.Text;
            encuestas.Descripcion = DescripcionTextBox.Text;
            encuestas.Fecha = FechaTextBox.Text;
            foreach (GridViewRow item in PreguntasAbiertasGridView.Rows)
            {
                encuestas.AgregarPreguntasAbiertas(1,Utilitarios.ConveritrId(item.Cells[1].Text), item.Cells[2].Text);
            }

            foreach (GridViewRow item in PreguntasCerradasGridView.Rows)
            {
                encuestas.AgregarPreguntasCerradas(1, Utilitarios.ConveritrId(item.Cells[1].Text), item.Cells[2].Text);
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
            AgregarGrid(); 
        }

        public void BindData()
        {
            DataTable dt2 = (DataTable)Session["Cerradas"];
            dt2.Rows.Add(PreguntasCerradasDropDownList.SelectedValue, PreguntasCerradasDropDownList.SelectedItem.Text);
            PreguntasCerradasGridView.DataSource = dt2;
            PreguntasCerradasGridView.DataBind();
            Session["Cerradas"] = dt2;
        }

        protected void AgregarCButton_Click(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData1()
        {
            DataTable dt = (DataTable)Session["Abiertas"];
            dt.Rows.Add(PreguntasAbiertasDropDownList.SelectedValue, PreguntasAbiertasDropDownList.SelectedItem.Text);
            PreguntasAbiertasGridView.DataSource = dt;
            PreguntasAbiertasGridView.DataBind();
            Session["Abiertas"] = dt;
        }

        protected void AgregarAButton_Click(object sender, EventArgs e)
        {
            BindData1();
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

       
      

        protected void PreguntasCerradasGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["Cerradas"];
            dt.Rows[Utilitarios.ConveritrId(e.RowIndex.ToString())].Delete();
            Session["Cerradas"] = dt;
            PreguntasCerradasGridView.DataSource = Session["Cerradas"] as DataTable;
            PreguntasCerradasGridView.DataBind();

        }

        protected void PreguntasAbiertasGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["Abiertas"];
            dt.Rows[Utilitarios.ConveritrId(e.RowIndex.ToString())].Delete();
            Session["Abiertas"] = dt;
            PreguntasAbiertasGridView.DataSource = Session["Abiertas"] as DataTable;
            PreguntasAbiertasGridView.DataBind();
        }

        protected void PreguntasCerradasGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PreguntasCerradasGridView.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void PreguntasAbiertasGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PreguntasAbiertasGridView.PageIndex = e.NewPageIndex;
            BindData1();
        }

       
    }
}