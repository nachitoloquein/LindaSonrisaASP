using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LindaSonrisa.Odontologo
{
    public partial class OdontologoMaestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string usuario = Session["Odontologo"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("LoginOdontologo.aspx");
            }
            NombreOdontologo();
        }
        protected void cerrarSesion_click(object sender, EventArgs e)
        {
            Session.Remove("Odontologo");
            Response.Redirect("LoginOdontologo.aspx");
        }
        protected void NombreOdontologo()
        {
            nombreUsuario.Text = Session["Odontologo"].ToString();
        }
    }
}