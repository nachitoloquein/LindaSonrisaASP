using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LindaSonrisa.Odontologo
{
    public partial class PanelDeFichas : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string usuario = Session["Odontologo"].ToString();
                }
                catch (Exception ex)
                {
                    Response.Redirect("LoginOdontologo.aspx");
                }
                BotonEliminar.Enabled = false;
                cargarDatos();
                cargarComboUsuario();
            }
        }
        public void limpiarProveedor()
        {
            HfId.Value = "";
            txtDiagnostico.Value = "";
            txtMotivo.Value = "";
            txtReceta.Value = "";
            txtSintoma.Value = "";

            BotonEliminar.Enabled = false;
        }
        protected void btnAgregar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("AgregarActualizarFicha", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Id", (HfId.Value == "" ? 0 : Convert.ToInt32(HfId.Value)));
            sqlcmd.Parameters.AddWithValue("@NombreOdontologo", Session["Odontologo"].ToString());
            sqlcmd.Parameters.AddWithValue("@IdNombreUsuario", comboUsuario.SelectedValue);
            sqlcmd.Parameters.AddWithValue("@MotivoConsulta", txtMotivo.Value.ToString());
            sqlcmd.Parameters.AddWithValue("@Sintomas", txtSintoma.Value.ToString());
            sqlcmd.Parameters.AddWithValue("@Diagnostico", txtDiagnostico.Value.ToString());
            sqlcmd.Parameters.AddWithValue("@Receta", txtReceta.Value.ToString());
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            limpiarProveedor();
            cargarDatos();
        }
        void cargarDatos()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("VerFichasUsuario", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@nombreOdontologo", Session["Odontologo"].ToString());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
        }
        void cargarComboUsuario()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandText = "cargarUsuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlcon;

                cmd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                this.comboUsuario.DataSource = dt;
                this.comboUsuario.DataTextField = "NombreUsuario";
                this.comboUsuario.DataValueField = "Id";
                this.comboUsuario.DataBind();

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
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("buscarFichaPorId", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            HfId.Value = id.ToString();
            txtDiagnostico.Value = dtbl.Rows[0]["Diagnostico"].ToString();
            txtMotivo.Value = dtbl.Rows[0]["MotivoConsulta"].ToString();
            txtReceta.Value = dtbl.Rows[0]["Receta"].ToString();
            txtSintoma.Value = dtbl.Rows[0]["Sintomas"].ToString();
            comboUsuario.SelectedValue = dtbl.Rows[0]["IdNombreUsuario"].ToString();
            BotonEliminar.Enabled = true;
            cargarDatos();
        }
        protected void btnEliminar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlDa = new SqlCommand("EliminarFichaPorId", sqlcon);
            sqlDa.CommandType = CommandType.StoredProcedure;
            sqlDa.Parameters.AddWithValue("@Id", Convert.ToInt32(HfId.Value));
            sqlDa.ExecuteNonQuery();
            sqlcon.Close();
            limpiarProveedor();
            cargarDatos();
        }
    }
}