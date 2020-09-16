using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LindaSonrisa.Proveedor
{
    public partial class ProveedorMaestro : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string usuario = Session["Proveedor"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("LoginProveedor.aspx");
            }
            NombreProveedor();
        }

        protected void cerrarSesion_click(object sender, EventArgs e)
        {
            Session.Remove("Proveedor");
            Response.Redirect("LoginProveedor.aspx");
        }
        protected void NombreProveedor()
        {
            nombreUsuario.Text = Session["Proveedor"].ToString();
        }
    }
}