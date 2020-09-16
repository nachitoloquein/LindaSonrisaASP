using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LindaSonrisa.Empleado
{
    public partial class BandejaEntrada : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        string cnString = "Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True";
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
            cargarDatos();
        }

        void cargarDatos()
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string sql = null;
            SqlConnection connection = new SqlConnection(cnString);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "cargarFoto";
            command.Parameters.Add("@correoEmpleado", SqlDbType.VarChar, 80);
            command.Parameters["@correoEmpleado"].Value = Session["Empleado"].ToString();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            connection.Close();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        protected void btnOtorgarBeneficio_Click(object sender, EventArgs e)
        {
            string nombreUsuario = (sender as LinkButton).CommandArgument;
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlDa = new SqlCommand("otorgarBeneficio", sqlcon);
            sqlDa.CommandType = CommandType.StoredProcedure;
            sqlDa.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            sqlDa.ExecuteNonQuery();
            sqlcon.Close();
            hfNombreUsuario.Value = nombreUsuario.ToString();
            cargarDatos();
        }
        protected void btnEliminarSoli_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlDa = new SqlCommand("eliminarSolicitud", sqlcon);
            sqlDa.CommandType = CommandType.StoredProcedure;
            sqlDa.Parameters.AddWithValue("@id", id);
            sqlDa.ExecuteNonQuery();
            sqlcon.Close();
            hfId.Value = id.ToString();
            cargarDatos();
        }
    }
}