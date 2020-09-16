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
    public partial class Compra : System.Web.UI.Page
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
                CargarComboEmpleado();
                cargarComboProducto();
                btnComprar.Visible = false;
                btnAgregar.Visible = true;
                
                
            }
        }
        private void CargarComboEmpleado()
        {
            SqlConnection cn = new SqlConnection(cnString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandText = "OrdenarProveedor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                this.comboProveedor.DataSource = dt;
                this.comboProveedor.DataTextField = "correoElectronico";
                this.comboProveedor.DataValueField = "id";
                this.comboProveedor.DataBind();

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
                cmd.CommandText = "cargarProductoParaComprarAPRoveedor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", comboProveedor.SelectedValue);
                cmd.Connection = cn;

                cmd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                this.comboProducto.DataSource = dt;
                this.comboProducto.DataTextField = "nombreProducto";
                this.comboProducto.DataValueField = "id";
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("TotalAPagar", sqlcon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@id", comboProducto.SelectedValue);
                sqlDa.SelectCommand.Parameters.AddWithValue("@cantidad", total);
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
            comboProveedor.SelectedValue = "1";
            comboProducto.SelectedValue = "1";
            TxtCantidad.Text = "";
            btnComprar.Visible = false;
            btnAgregar.Visible = true;
        }
        protected void btnComprar_click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("GenerarFactura", sqlcon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("@Proveedor_Id", comboProveedor.SelectedValue);
                sqlDa.SelectCommand.Parameters.AddWithValue("@CorreoEmpleado", Session["Empleado"].ToString());
                sqlDa.SelectCommand.Parameters.AddWithValue("@Total", Convert.ToInt32(txtTotalAPagar.Text));
                sqlDa.SelectCommand.Parameters.AddWithValue("@Producto", comboProducto.SelectedItem.ToString());
                sqlDa.SelectCommand.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(TxtCantidad.Text));
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                sqlcon.Close();
                Response.Redirect("Factura.aspx");
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La cantidad de productos excede el total')", true);
                limpiar();
            }
        }
    }
}
