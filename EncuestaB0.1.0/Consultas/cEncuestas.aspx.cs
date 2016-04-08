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
    public partial class cEncuestas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Encuestas encuesta = new Encuestas();
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
                    condicion = "e." + FiltroDropDownList.SelectedItem.Text + " = " + Utilitarios.ConveritrId(CampoTextBox.Text).ToString();
                }
                else
                {
                    condicion = "e." + FiltroDropDownList.SelectedItem.Text + " like " + "'%" + CampoTextBox.Text + "%'";
                }
            }
            dt = encuesta.Listado(" e.EncuestaId,e.Entidad,e.Descripcion,e.Fecha,a.Descripcion,c.Descripcion ", condicion, "");
            DatoGridView.DataSource = dt;
            DatoGridView.DataBind();


        }

     
    }
}