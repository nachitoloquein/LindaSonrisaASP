using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LindaSonrisa.BandejaEntrada
{
    public partial class BandejaEntrada1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string usuario = Session["Usuario"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("../Login.aspx");
            }
            NombreUsuario();
        }
        protected void cerrarSesion_click(object sender, EventArgs e)
        {
            Session.Remove("Usuario");
            Response.Redirect("../Login.aspx");
        }

        protected void NombreUsuario()
        {
            nombreUsuario.Text = Session["Usuario"].ToString();
        }
    }
}