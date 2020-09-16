using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LindaSonrisa.Proveedor
{
    public partial class GestionDeProductosProveedor : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        string cnString = "Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string usuario = Session["Proveedor"].ToString();
                }
                catch (Exception ex)
                {
                    Response.Redirect("LoginProveedor.aspx");
                }
                BotonEliminar.Enabled = false;
                cargarDatos();
                cargarComboTipoProducto();
            }
        }
        public void limpiarProducto()
        {
            HfId.Value = "";
            txtNombreProducto.Value = "";
            txtCantidad.Value = "";
            txtPrecio.Value = "";
            BotonEliminar.Enabled = false;
        }
        protected void btnAgregar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("AgregarActualizarProductosProveedor", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", (HfId.Value == "" ? 0 : Convert.ToInt32(HfId.Value)));
            sqlcmd.Parameters.AddWithValue("@NombreProducto", txtNombreProducto.Value);
            sqlcmd.Parameters.AddWithValue("@idTipoProducto", comboTipoProducto.SelectedValue);
            sqlcmd.Parameters.AddWithValue("@Precio", txtPrecio.Value);
            sqlcmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Value);
            sqlcmd.Parameters.AddWithValue("@Correo", Session["Proveedor"].ToString());
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            limpiarProducto();
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
            command.CommandText = "VerPoductos";
            command.Parameters.Add("@correo", SqlDbType.VarChar, 50);
            command.Parameters["@correo"].Value = Session["Proveedor"].ToString();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            connection.Close();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("BuscarProductosProveedor", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            HfId.Value = id.ToString();
            txtNombreProducto.Value = dtbl.Rows[0]["NombreProducto"].ToString();
            txtPrecio.Value = dtbl.Rows[0]["Precio"].ToString();
            txtCantidad.Value = dtbl.Rows[0]["Cantidad"].ToString();
            BotonEliminar.Enabled = true;
            cargarDatos();
        }
        protected void btnEliminar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlDa = new SqlCommand("EliminarProductosPorId", sqlcon);
            sqlDa.CommandType = CommandType.StoredProcedure;
            sqlDa.Parameters.AddWithValue("@Id", Convert.ToInt32(HfId.Value));
            sqlDa.ExecuteNonQuery();
            sqlcon.Close();
            limpiarProducto();
            cargarDatos();
        }
        void cargarComboTipoProducto()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandText = "cargarTipoProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlcon;

                cmd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                this.comboTipoProducto.DataSource = dt;
                this.comboTipoProducto.DataTextField = "Descripcion";
                this.comboTipoProducto.DataValueField = "Id";
                this.comboTipoProducto.DataBind();

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
    }
}