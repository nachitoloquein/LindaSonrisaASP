using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace LindaSonrisa.Odontologo
{
    public partial class LoginOdontologo : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargarOdontologos();
            }
        }

        void cargarOdontologos()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandText = "cargarOdontologo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlcon;

                cmd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                this.comboOdontologo.DataSource = dt;
                this.comboOdontologo.DataTextField = "odontologo";
                this.comboOdontologo.DataValueField = "Id";
                this.comboOdontologo.DataBind();

                sqlcon.Close();

                cmd.Dispose();
                sqlcon.Dispose();
            }
            catch
            {
                cmd.Dispose();
                sqlcon.Close();
                sqlcon.Dispose();
            }
        }
        protected void btnEntrar_click(object sender, EventArgs e)
        {
            sqlcon.Open();
            string query = "select COUNT(*) from odontologo where Id = @id and Contrasena = @contrasena";
            SqlCommand cm = new SqlCommand(query, sqlcon);
            cm.Parameters.AddWithValue("@id", comboOdontologo.SelectedValue);
            cm.Parameters.AddWithValue("@contrasena", txtcontrasena.Value);

            //Si existe un usuario con los datos retorna true, caso contrario false
            bool correcto = Convert.ToInt32(cm.ExecuteScalar()) > 0;

            if (correcto)
            {
                Session["Odontologo"] = comboOdontologo.SelectedItem.ToString();
                //Response.Redirect("GestionUsuario.aspx");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('bienvenido'); ", true);
                Response.Redirect("PanelDeFichas.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('La Contraseña es incorrecta'); ", true);
                limpiarLogin();
            }
            sqlcon.Close();
        }

        private void limpiarLogin()
        {
            comboOdontologo.SelectedValue = "1";
            txtcontrasena.Value = "";
        }
    }
}