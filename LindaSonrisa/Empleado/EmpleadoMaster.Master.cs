using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LindaSonrisa.Empleado
{
    public partial class EmpleadoMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string usuario = Session["Empleado"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("LoginEmpleado.aspx");
            }
            NombreEmpleado();
        }
        protected void cerrarSesion_click(object sender, EventArgs e)
        {
            Session.Remove("Empleado");
            Response.Redirect("LoginEmpleado.aspx");
        }
        protected void NombreEmpleado()
        {
            nombreUsuario.Text = Session["Empleado"].ToString();
        }
    }
}