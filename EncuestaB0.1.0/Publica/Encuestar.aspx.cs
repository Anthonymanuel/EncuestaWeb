using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace EncuestaB0._1._0
{
    public partial class Encuestar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idBuscado"] != null)
                {
                    int id = Utilitarios.ConveritrId(Request.QueryString["idBuscado"].ToString());
                    LoadPreguntas(id);
                }

            }
        }
        private void LoadPreguntas(int id)
        {

            Encuestas encuestas = new Encuestas();

            TituloRepeater.DataSource = encuestas.Listado("EncuestaId,Entidad,Descripcion,Fecha", " EncuestaId = " + id.ToString(), "");
            TituloRepeater.DataBind();
            PreguntasRepeater.DataSource = encuestas.ListadoPreguntas("p.PreguntaId,p.Descripcion,p.TipoDePregunta,p.SubTipoDePregunta", " where e.EncuestaId  = " + id.ToString());
            PreguntasRepeater.DataBind();
        }

        protected void LlenarButton_Click(object sender, EventArgs e)
        {


            RespuestasAbiertas abiertas = new RespuestasAbiertas();
            foreach (RepeaterItem item in PreguntasRepeater.Items)
            {
                CheckBoxList check = (CheckBoxList)item.FindControl("RespuestasCheckBoxList");
                RadioButtonList radio = (RadioButtonList)item.FindControl("RespuestasRadioButtonList");
                TextBox textBox = (TextBox)item.FindControl("RespuestasTextBox");
                Label label = (Label)item.FindControl("PreguntaIdLabel");
                Label subTipo = (Label)item.FindControl("SubTipoDePreguntaLabel");
                RequiredFieldValidator valido = (RequiredFieldValidator)item.FindControl("RequiredFieldValidator");

                if (textBox.Visible == true)
                {
                    if (textBox != null)
                    {
                        abiertas.Descricpcion = textBox.Text;

                    }
                    if (label != null)
                    {
                        abiertas.PreguntaId = Utilitarios.ConveritrId(label.Text);

                    }
                    if (abiertas.Insertar())
                    {

                        textBox.Text = "";

                    }
                }
                else if (textBox.Visible == false)
                {
                    valido.IsValid = true;
                }
                if (subTipo.Text == "1")
                {
                    RespuestasCerradas cerradas = new RespuestasCerradas();
                    cerradas.PreguntaId = Utilitarios.ConveritrId(label.Text);
                    cerradas.Respuestas = radio.SelectedIndex + 1;
                    cerradas.Insertar();
                        radio.ClearSelection();
                }
                if (subTipo.Text == "2")
                {
                    int x = 0;
                    RespuestasCerradas cerradas = new RespuestasCerradas();
                    cerradas.PreguntaId = Utilitarios.ConveritrId(label.Text);
                    foreach (ListItem aux in check.Items)
                    {
                        x++;
                        if (aux.Selected == true)
                        {
                            cerradas.Respuestas = x; 
                            cerradas.Insertar();
                        }
                    }

                    check.ClearSelection();
                }
            }
            Encuestados encuestados = new Encuestados();
            encuestados.Cantidad = 1;
            encuestados.EncuestaId = Utilitarios.ConveritrId(Request.QueryString["idBuscado"].ToString()); ;
            encuestados.Insertar();
            Response.Redirect("/Default.aspx");

        }


        protected void PreguntasRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            int id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "PreguntaId"));
            int tipo = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TipoDePregunta"));
            int subTipo = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "subTipoDePregunta"));
            Preguntas preguntas = new Preguntas();
            DataTable dt = new DataTable();
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                dt = preguntas.ListadoRespuestasPosbiles("Respuestas,RespuestaPosibleId", "PreguntaId = " + id.ToString());
                if (subTipo == 1)
                {
                    RadioButtonList radio = (RadioButtonList)e.Item.FindControl("RespuestasRadioButtonList");
                    radio.DataValueField = "RespuestaPosibleId";
                    radio.DataTextField = "Respuestas";
                    radio.DataSource = dt;
                    radio.DataBind();
                }
                if (subTipo == 2)
                {
                    CheckBoxList check = (CheckBoxList)e.Item.FindControl("RespuestasCheckBoxList");
                    check.DataValueField = "RespuestaPosibleId";
                    check.DataTextField = "Respuestas";
                    check.DataSource = dt;
                    check.DataBind();
                }
                if (tipo == 1)
                {
                    TextBox textbox = (TextBox)e.Item.FindControl("RespuestasTextBox");
                    textbox.Visible = true;
                }
            }

        }
    }
}