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
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Encuestas encuestas = new Encuestas();
            DefaultRepeater.DataSource = encuestas.Listado("EncuestaId,Entidad,Descripcion", " 1=1", "");
            DefaultRepeater.DataBind();
        }

        protected void DefaultRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Encuestados encuestado = new Encuestados();
                Repeater FooterRepeater = (Repeater)e.Item.FindControl("FooterRepeater");
                FooterRepeater.DataSource = encuestado.Listado(" Count(Cantidad) as 'Total' ", "", ""); 
                FooterRepeater.DataBind();
            }
        }
    }
}