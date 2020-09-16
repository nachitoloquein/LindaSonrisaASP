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
    public partial class ComprarUsuario : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        string cnString = "Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True";
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
                ordenarEmpleado();
                cargarComboProducto();
                btnComprar.Visible = false;
                btnAgregar.Visible = true;
                CargarComuna();
            }

            
        }

        void CargarComuna()
        {
            SqlConnection cn = new SqlConnection(cnString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "cargarComuna";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                this.comboComuna.DataSource = dt;
                this.comboComuna.DataTextField = "Descripcion";
                this.comboComuna.DataValueField = "Id";
                this.comboComuna.DataBind();

                cn.Close();

                cmd.Dispose();
                cn.Dispose();
            }
            catch
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        void ordenarEmpleado()
        {
            SqlConnection cn = new SqlConnection(cnString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "ordenarEmpleador";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                this.comboEmpleado.DataSource = dt;
                this.comboEmpleado.DataTextField = "Nombre Empleador";
                this.comboEmpleado.DataValueField = "id";
                this.comboEmpleado.DataBind();

                cn.Close();

                cmd.Dispose();
                cn.Dispose();
            }
            catch
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        private void cargarComboProducto()
        {
            SqlConnection cn = new SqlConnection(cnString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "cargarProductoDeEmpleados";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEmpleado", comboEmpleado.SelectedValue);
                cmd.Connection = cn;

                cmd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                this.comboProducto.DataSource = dt;
                this.comboProducto.DataTextField = "NombreProducto";
                this.comboProducto.DataValueField = "Id";
                this.comboProducto.DataBind();

                cn.Close();

                cmd.Dispose();
                cn.Dispose();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        protected void comboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboProducto();
        }

        protected void btnAgregar_click(object sender, EventArgs e)
        {
            try
            {
                int total = int.Parse(TxtCantidad.Text);
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("ClientePaga", sqlcon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@id", comboProducto.SelectedValue);
                sqlDa.SelectCommand.Parameters.AddWithValue("@cantidad", total);
                sqlDa.SelectCommand.Parameters.AddWithValue("@nombreUsuario", Session["Usuario"].ToString());
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                string pagar = dtbl.Rows[0]["Total"].ToString();
                sqlcon.Close();
                if (pagar == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La cantidad de productos excede el total')", true);
                }
                else
                {
                    txtTotalAPagar.Text = pagar;
                    btnComprar.Visible = true;
                    btnAgregar.Visible = false;
                }

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La cantidad de productos excede el total')", true);
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        void limpiar()
        {
            txtTotalAPagar.Text = "";
            comboEmpleado.SelectedValue = "1";
            comboProducto.SelectedValue = "1";
            TxtCantidad.Text = "";
            btnComprar.Visible = false;
            btnAgregar.Visible = true;
        }
        protected void btnComprar_click(object sender, EventArgs e)
        {
            
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("generarBoleta", sqlcon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@Empleado_Id", comboEmpleado.SelectedValue);
                sqlDa.SelectCommand.Parameters.AddWithValue("@NombreUsuario", Session["Usuario"].ToString());
                sqlDa.SelectCommand.Parameters.AddWithValue("@Total", Convert.ToInt32(txtTotalAPagar.Text));
                sqlDa.SelectCommand.Parameters.AddWithValue("@Producto", comboProducto.SelectedItem.ToString());
                sqlDa.SelectCommand.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(TxtCantidad.Text));
                sqlDa.SelectCommand.Parameters.AddWithValue("@idComuna", comboComuna.SelectedValue);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                sqlcon.Close();
                Response.Redirect("Boleta.aspx");
            
            
        }
    }
}