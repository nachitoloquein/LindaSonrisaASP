using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace LindaSonrisa
{
    public partial class Login : System.Web.UI.Page
    {
        public SqlConnection cn = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            
            cn.Open();
            string query = "select count(*) from Usuario where nombreUsuario= @usuario and contrasena = @password";
            //string user = "select count(*) from Usuario where nombreUsuario= @usuario";
            SqlCommand cm = new SqlCommand(query, cn);
            cm.Parameters.AddWithValue("@usuario", txtUser.Value);
            cm.Parameters.AddWithValue("@password", txtPass.Value);

            //Si existe un usuario con los datos retorna true, caso contrario false
            bool correcto = Convert.ToInt32(cm.ExecuteScalar()) > 0;

            if (correcto)
            {
                Session["Usuario"] = txtUser.Value.ToString();
                Response.Redirect("BandejaEntrada/BandejaEntrada.aspx");

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('El Usuario o Contraseña incorrectos'); ", true);
                limpiarLogin();
            }
            cn.Close();

            
        }

        private void limpiarLogin()
        {
            txtUser.Value = "";
            txtPass.Value = "";
        }

      
        
    }
}