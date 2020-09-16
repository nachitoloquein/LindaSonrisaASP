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
    public partial class Boleta : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string usuario = Session["Usuario"].ToString();
                }
                catch (Exception ex)
                {
                    Response.Redirect("../Login.aspx");
                }
                cargarDatos();
            }
        }
        void cargarDatos()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("cargarBoleta", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@NombreUsuario", Session["Usuario"].ToString());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            GridView1.DataSource = dtbl;
            GridView1.DataBind();

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistorialProducto.aspx");
        }
    }
}