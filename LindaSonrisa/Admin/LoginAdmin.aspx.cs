using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LindaSonrisa.Admin
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        public SqlConnection cn = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_click(object sender, EventArgs e)
        {
            cn.Open();
            string query = "select count(*) from Administrador where CorreoElectronico= @correo and Contrasena = @password";
            SqlCommand cm = new SqlCommand(query, cn);
            cm.Parameters.AddWithValue("@correo", txtCorreo.Value);
            cm.Parameters.AddWithValue("@password", txtcontrasena.Value);

            //Si existe un usuario con los datos retorna true, caso contrario false
            bool correcto = Convert.ToInt32(cm.ExecuteScalar()) > 0;

            if (correcto)
            {
                Session["Admin"] = txtCorreo.Value.ToString();
                Response.Redirect("GestionUsuario.aspx");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('bienvenido'); ", true);
               
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