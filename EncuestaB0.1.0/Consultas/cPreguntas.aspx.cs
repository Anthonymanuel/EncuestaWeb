using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace EncuestaB0._1._0.Consultas
{
    public partial class cPreguntas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindData()
        {
            Preguntas preguntas = new Preguntas();
            string condicion;
            if (CampoTextBox.Text.Trim().Length == 0)
            {
                condicion = "1=1";
            }
            else
            {
                if (FiltroDropDownList.SelectedIndex == 0)
                {
                    condicion = FiltroDropDownList.SelectedItem.Text + " = " + Utilitarios.ConveritrId(CampoTextBox.Text).ToString();
                }
                if(FiltroDropDownList.SelectedIndex == 1)
                {
                    condicion = FiltroDropDownList.SelectedItem.Text + " = " + Utilitarios.ConveritrId(CampoTextBox.Text).ToString();

                }
                else
                {
                    condicion = FiltroDropDownList.SelectedItem.Text + " like " + "'%" + CampoTextBox.Text + "%'";
                }
            }
            ImprimirButton.Visible = true;
            DataTable dt = new DataTable();
            dt = preguntas.Listado(" * ", condicion, "");
            DatoGridView.DataSource = dt;
            DatoGridView.DataBind();

        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void DatoGridView_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            DatoGridView.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas reportes/vPreguntas.aspx");
        }
    }
}