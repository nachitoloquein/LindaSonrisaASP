using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LindaSonrisa.BandejaEntrada
{
    public partial class RegistrarHora : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string usuario = Session["Usuario"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("../Login.aspx");
            }
            cargarOdontologo();
            cargarTipoServicio();
        }
        protected void btnAgregar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("agregarAtencion", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@fechaAtencion", txtFechaAtención.Value);
            sqlcmd.Parameters.AddWithValue("@horaAtencion", txtHoraAtencion.Value);
            sqlcmd.Parameters.AddWithValue("@nombreUsuario", Session["Usuario"].ToString());
            sqlcmd.Parameters.AddWithValue("@odontologo_id", comboProfesional.SelectedValue);
            sqlcmd.Parameters.AddWithValue("@tipoServicio_Id", comboServicio.SelectedValue);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            limpiarRegistro();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El registro fue ingresado de manera exitosa')", true);
            Response.Redirect("BandejaEntrada.aspx");
        }
        protected void btnEliminar_click(object sender, EventArgs e)
        {
            limpiarRegistro();
        }

        void cargarOdontologo()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandText = "CargarProfesional";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlcon;

                cmd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                this.comboProfesional.DataSource = dt;
                this.comboProfesional.DataTextField = "Nombre";
                this.comboProfesional.DataValueField = "Id";
                this.comboProfesional.DataBind();

            }
            catch
            {
                cmd.Dispose();
                sqlcon.Close();
            }
        }
        void cargarTipoServicio()
        {
            try
            {


                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                try
                {
                    cmd.CommandText = "CargarTipoServicio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = sqlcon;

                    cmd.ExecuteScalar();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);

                    this.comboServicio.DataSource = dt;
                    this.comboServicio.DataTextField = "Descripcion";
                    this.comboServicio.DataValueField = "Id";
                    this.comboServicio.DataBind();

                 
                }
                catch
                {
                    cmd.Dispose();
                    sqlcon.Close();
                    sqlcon.Dispose();
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        void limpiarRegistro()
        {
            txtFechaAtención.Value = "";
            txtHoraAtencion.Value = "";
            comboServicio.SelectedValue = "1";
            comboProfesional.SelectedValue = "1";
        }
    }
}