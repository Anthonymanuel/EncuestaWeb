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
                LoadPreguntas();
            }
        }
        private void LoadPreguntas()
        {
            DataTable dt = new DataTable();
            PreguntasCerradas cerrada = new PreguntasCerradas();
            dt = cerrada.Listado(" * ", "1=1","");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            
        }

        
    }
}