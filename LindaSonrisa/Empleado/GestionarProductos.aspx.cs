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
    public partial class GestionarProductos : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        string cnString = "Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string usuario = Session["Empleado"].ToString();
                }
                catch (Exception ex)
                {
                    Response.Redirect("LoginEmpleado.aspx");
                }
                BotonEliminar.Enabled = false;
                cargarDatos();
                cargarTipoProducto();
            }
        }
        public void limpiarProducto()
        {
            hfId.Value = "";
            txtNombreprod.Value = "";
            TxtPrecio.Value = "";
            TxtCantidad.Value = "";
            comboTipoPro.SelectedValue = "1";
            BotonEliminar.Enabled = false;
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
            command.CommandText = "VerProductosEmpleado";
            command.Parameters.Add("@correo", SqlDbType.VarChar, 50);
            command.Parameters["@correo"].Value = Session["Empleado"].ToString();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            connection.Close();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        protected void btnAgregar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("AgregarActualizarProductosEmpleador", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlcmd.Parameters.AddWithValue("@NombreProducto", txtNombreprod.Value.ToString());
            sqlcmd.Parameters.AddWithValue("@FechaElaboracion", txtFechaelab.Value);
            sqlcmd.Parameters.AddWithValue("@FechaVencimiento", txtFechaVenc.Value);
            sqlcmd.Parameters.AddWithValue("@TipoProductoId", comboTipoPro.SelectedValue);
            sqlcmd.Parameters.AddWithValue("@Cantidad",int.Parse(TxtCantidad.Value));
            sqlcmd.Parameters.AddWithValue("@Precio", int.Parse(TxtPrecio.Value));
            sqlcmd.Parameters.AddWithValue("@Correo", Session["Empleado"].ToString());
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            limpiarProducto();
            cargarDatos();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("BuscarProductoEmpleadoPorID", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            hfId.Value = id.ToString();
            txtNombreprod.Value = dtbl.Rows[0]["NombreProducto"].ToString();
            txtFechaelab.Value = dtbl.Rows[0]["FechaElaboracion"].ToString();
            txtFechaVenc.Value = dtbl.Rows[0]["FechaVencimiento"].ToString();
            comboTipoPro.SelectedValue = dtbl.Rows[0]["TipoProducto_Id"].ToString();
            TxtCantidad.Value = dtbl.Rows[0]["Cantidad"].ToString();
            TxtPrecio.Value = dtbl.Rows[0]["precio"].ToString();
            BotonEliminar.Enabled = true;
            cargarDatos();
        }
        protected void btnEliminar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlDa = new SqlCommand("EliminarProductoEmpleadoPorID", sqlcon);
            sqlDa.CommandType = CommandType.StoredProcedure;
            sqlDa.Parameters.AddWithValue("@Id", Convert.ToInt32(hfId.Value));
            sqlDa.ExecuteNonQuery();
            sqlcon.Close();
            limpiarProducto();
            cargarDatos();
        }

        void cargarTipoProducto()
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

                this.comboTipoPro.DataSource = dt;
                this.comboTipoPro.DataTextField = "Descripcion";
                this.comboTipoPro.DataValueField = "Id";
                this.comboTipoPro.DataBind();

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