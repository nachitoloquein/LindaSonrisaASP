using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace LindaSonrisa
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Clicknviar(object sender, EventArgs e)
        {

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add("lindasonrisaduocportafolio@gmail.com");
            msg.Subject = txtAsunto.Value.ToString();
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Bcc.Add(txtCorreo.Value.ToString());


            msg.Body = txtNombre.Value + "<br/ >" + txtMensaje.Value;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new System.Net.Mail.MailAddress(txtCorreo.Value.ToString());

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("lindasonrisaduocportafolio@gmail.com", "duoc001D");
            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = "smtp.gmail.com";
            try
            {

                cliente.Send(msg);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Estimado(a), El mensaje a sido enviado'); ", true);
                limpiarContacto();
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Estimado(a), Hubo un error con el sistema, escriba nuevamente su correo electrónico'); ", true);
                limpiarContacto();
            }
        }
        private void limpiarContacto()
        {
            txtAsunto.Value = "";
            txtCorreo.Value = "";
            txtNombre.Value = "";
            txtMensaje.Value = "";
        }

    }
}