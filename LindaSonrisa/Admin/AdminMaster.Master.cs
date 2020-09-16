using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LindaSonrisa.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string admin = Session["Admin"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("LoginAdmin.aspx");
            }
            CorreoAdmin();

        }
        protected void cerrarSesion_click(object sender, EventArgs e)
        {
            Session.Remove("Admin");
            Response.Redirect("LoginAdmin.aspx");
        }

        protected void CorreoAdmin()
        {
            nombreUsuario.Text = Session["Admin"].ToString();
        }
    }
}