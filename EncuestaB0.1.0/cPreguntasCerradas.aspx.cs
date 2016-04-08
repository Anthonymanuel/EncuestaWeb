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
    public partial class cPreguntasCerradas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            PreguntasCerradas cerradas = new PreguntasCerradas();
            DataTable dt = new DataTable();
            string condicion;
            if (CampoTextBox.Text.Trim().Length == 0)
            {
                condicion = "1=1";
            }
            else
            {
                if (FiltroDropDownList.SelectedIndex == 0)
                {
                    condicion =  FiltroDropDownList.SelectedItem.Text + " = " + Utilitarios.ConveritrId(CampoTextBox.Text).ToString();
                }
                else
                {
                    condicion =   FiltroDropDownList.SelectedItem.Text + " like " + "'%" + CampoTextBox.Text + "%'";
                }
            }
            dt = cerradas.Listado(" * ", condicion, "");
            DatoGridView.DataSource = dt;
            DatoGridView.DataBind();
        }

    }
}