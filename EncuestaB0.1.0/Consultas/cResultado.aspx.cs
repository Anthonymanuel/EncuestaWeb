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
    public partial class cResultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        public void BindData()
        {
            Encuestas encuesta = new Encuestas();
            DataTable dt = new DataTable();
            string condicion;
            
                if (FiltroDropDownList.SelectedIndex == 0)
                {
                    condicion =  FiltroDropDownList.SelectedItem.Text + " = " + Utilitarios.ConveritrId(CampoTextBox.Text).ToString();
                }
                else if (FiltroDropDownList.SelectedIndex == 3)
                {
                    condicion =  FiltroDropDownList.SelectedItem.Text + " =" + "'" + CampoTextBox.Text + "'";

                }
                else
                {
                    condicion =  FiltroDropDownList.SelectedItem.Text + " like " + "'%" + CampoTextBox.Text + "%'";
                }
            
            dt = encuesta.ListadoResultado(" e.EncuestaId,e.Entidad,e.Descripcion,e.Fecha,p.Descripcion,r.Descripcion,c.Respuesta ","e."+condicion, "");
            DatoGridView.DataSource = dt;
            DatoGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void DatoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DatoGridView.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}