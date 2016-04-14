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

            TituloRepeater.DataSource = encuestas.Listado("Entidad,Descripcion,Fecha", " EncuestaId =" + id.ToString(), "");
            TituloRepeater.DataBind();
            Tipo1Repeater.DataSource = encuestas.ListadoCerradas("e.EncuestaId,e.Entidad,c.Descripcion,r.Respuestas,e.Fecha,c.PreguntaCerradaId ", " p.TipoDePreguntaCerrada = 1 and e.EncuestaId = " + id.ToString());
            Tipo1Repeater.DataBind();

            Tipo2Repeater.DataSource = encuestas.ListadoCerradas("e.EncuestaId,e.Entidad,c.Descripcion,r.Respuestas,e.Fecha,c.PreguntaCerradaId ", " p.TipoDePreguntaCerrada = 2 and e.EncuestaId =  " + id.ToString());
            Tipo2Repeater.DataBind();

            PreguntasAbiertasRepeater.DataSource = encuestas.ListadoAbiertas("e.EncuestaId,e.Entidad,a.Descripcion,e.Fecha,a.PreguntaAbiertaId ", " e.EncuestaId =" + id.ToString());
            PreguntasAbiertasRepeater.DataBind();
        }

        protected void LlenarButton_Click(object sender, EventArgs e)
        {
            
            RespuestasAbiertas abiertas = new RespuestasAbiertas();
            foreach (RepeaterItem item in PreguntasAbiertasRepeater.Items)
            {
                TextBox txt = (TextBox)item.FindControl("RespuestasTextBox");
                Label la = (Label)item.FindControl("PreguntaAbiertaIdLabel");
                if (txt != null)
                {
                    abiertas.Descricpcion = txt.Text;

                }
                if (la != null)
                {
                    abiertas.PreguntaAbiertaId = Utilitarios.ConveritrId(la.Text);

                }
                if (abiertas.Insertar())
                {

                    txt.Text = "";
                    Response.Redirect("~/Login.aspx");
                }
            }
            foreach (RepeaterItem item in Tipo1Repeater.Items)
            {
                RespuestasCerradas cerrada = new RespuestasCerradas();
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var radio = item.FindControl("RespuestasRadioButtonList") as RadioButtonList;
                    var label = item.FindControl("PreguntaCerradaIdLabel") as Label;

                    //cerrada.RespuestaCerradaId = Utilitarios.ConveritrId(radio.SelectedValue.ToString());
                    //cerrada.Editar();

                }
            }
            foreach (RepeaterItem item in Tipo2Repeater.Items)
            {
                RespuestasCerradas cerrada = new RespuestasCerradas();
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var check = item.FindControl("RespuestasCheckBoxList") as CheckBoxList;

                    //cerrada.RespuestaCerradaId = Utilitarios.ConveritrId(check.SelectedValue.ToString());
                    //cerrada.Editar();


                }
            }
        }


        protected void Tipo1Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            int id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "PreguntaCerradaId"));
            PreguntasCerradas cerrada = new PreguntasCerradas();
            DataTable dt = new DataTable();
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                dt = cerrada.ListadoRespuestasPosbiles("Respuestas,RespuestaPosibleId", "PreguntaCerradaId = " + id.ToString());
                RadioButtonList radio = (RadioButtonList)e.Item.FindControl("RespuestasRadioButtonList");
                radio.DataValueField = "RespuestaPosibleId";
                radio.DataTextField = "Respuestas";
                radio.DataSource = dt;
                radio.DataBind();

            }

        }

        protected void Tipo2Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "PreguntaCerradaId"));
            PreguntasCerradas cerrada = new PreguntasCerradas();
            DataTable dt = new DataTable();
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                dt = cerrada.ListadoRespuestasPosbiles("Respuestas,RespuestaPosibleId", "PreguntaCerradaId = " + id.ToString());
                CheckBoxList check = (CheckBoxList)e.Item.FindControl("RespuestasCheckBoxList");
                check.DataValueField = "RespuestaPosibleId";
                check.DataTextField = "Respuestas";
                check.DataSource = dt;
                check.DataBind();
            }
        }
    }
}