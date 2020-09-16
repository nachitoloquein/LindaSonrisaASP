using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace LindaSonrisa.Empleado
{
    public partial class LoginEmpleado : System.Web.UI.Page
    {
        public SqlConnection cn = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_click(object sender, EventArgs e)
        {
            cn.Open();
            string query = "select count(*) from Empleado where CorreoElectronico= @correo and Contrasena = @password";
            SqlCommand cm = new SqlCommand(query, cn);
            cm.Parameters.AddWithValue("@correo", txtCorreo.Value);
            cm.Parameters.AddWithValue("@password", txtcontrasena.Value);

            //Si existe un usuario con los datos retorna true, caso contrario false
            bool correcto = Convert.ToInt32(cm.ExecuteScalar()) > 0;

            if (correcto)
            {
                Session["Empleado"] = txtCorreo.Value.ToString();
                //Response.Redirect("GestionUsuario.aspx");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('bienvenido'); ", true);
                Response.Redirect("BandejaEntrada.aspx");

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('El Correo o Contraseña incorrectos'); ", true);
                limpiarLogin();
            }
            cn.Close();
        }

        private void limpiarLogin()
        {
            txtCorreo.Value = "";
            txtcontrasena.Value = "";
        }
    }
}