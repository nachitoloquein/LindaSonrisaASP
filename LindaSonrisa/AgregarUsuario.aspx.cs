using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace LindaSonrisa
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        string cnString = "Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {

            SqlConnection myConn = new SqlConnection(cnString);
            myConn.Open();

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "AgregarUsuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombreUsuario", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@contrasena", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@correo", SqlDbType.NVarChar, 50);
                cmd.Parameters["@nombreUsuario"].Value = txtUser.Value.ToString();
                cmd.Parameters["@contrasena"].Value = txtPass.Value; 
                cmd.Parameters["@correo"].Value = TxtCorreo.Value.ToString();
                cmd.Connection = myConn;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                dt.Dispose();
                myConn.Dispose();
                cmd.Dispose();
                da.Dispose();

                myConn.Close();

                Response.Redirect("Login.aspx");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cuenta creada con éxito')", true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error intente nuevamente')", true);
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        void limpiar()
        {
            TxtCorreo.Value = "";
            txtPass.Value = "";
            txtUser.Value = "";
        }
        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
    }
}