using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace LindaSonrisa
{
    public partial class RecuperarContrasena : System.Web.UI.Page
    {
        String mycon = "Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            String password;
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RecuperarContrasena";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Correo", SqlDbType.NVarChar, 60);
            cmd.Parameters["@Correo"].Value = txtUser.Value.ToString();
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Label3.Text = "Data Found";

                password = ds.Tables[0].Rows[0]["contrasena"].ToString();
                EnviarContraseñaEmail(password, txtUser.Value.ToString());
                Response.Redirect("Login.aspx");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Estimado su contraseña a sido enviada al correo electrónico')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error, correo electrónico no registrado')", true);

            }
            con.Close();

        }

        private void EnviarContraseñaEmail(String password, String email)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("lindasonrisaduocportafolio@gmail.com", "duoc001D");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Recuperación de contraseña";
            msg.Body = "Estimado su constraseña es:  " + password + "\n\n\nMuchas Gracias\nLinda Sonrisa";
            string toaddress = txtUser.Value.ToString();
            msg.To.Add(toaddress);
            string fromaddress = "Linda Sonrisa <lindasonrisaduocportafolio@gmail.com>";
            msg.From = new MailAddress(fromaddress);
            try
            {
                smtp.Send(msg);


            }
            catch
            {
                throw;
            }
        }
        private void limpiar()
        {
            txtUser.Value = "";
        }
    }
}