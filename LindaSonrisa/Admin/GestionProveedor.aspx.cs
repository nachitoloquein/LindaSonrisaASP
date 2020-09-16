using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace LindaSonrisa.Admin
{
    public partial class GestionProveedor : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BotonEliminar.Enabled = false;
                cargarDatos();
                cargarComboRubro();
            }

        }
        public void limpiarProveedor()
        {
            HfId.Value = "";
            txtNombre.Value = "";
            txtApellido.Value = "";
            txtNumTel.Value = "";
            comboRubro.Items.Clear();
            txtCorreo.Value = "";
            txtContrasena.Value = "";
           
            BotonEliminar.Enabled = false;
        }
        protected void btnAgregar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("AgregarActualizarProveedor", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", (HfId.Value == "" ? 0 : Convert.ToInt32(HfId.Value)));
            sqlcmd.Parameters.AddWithValue("@Nombre", txtNombre.Value);
            sqlcmd.Parameters.AddWithValue("@Apellido", txtApellido.Value);
            sqlcmd.Parameters.AddWithValue("@NumeroTel", txtNumTel.Value.ToString());
            sqlcmd.Parameters.AddWithValue("@Rubro", comboRubro.SelectedValue);
            sqlcmd.Parameters.AddWithValue("@Correo", txtCorreo.Value);
            sqlcmd.Parameters.AddWithValue("@Contrasena", Encrypt(txtContrasena.Value));
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            limpiarProveedor();
            cargarDatos();
        }
        void cargarDatos()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("VerProveedor", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
        }
        void cargarComboRubro()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandText = "CargarRubro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlcon;

                cmd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                this.comboRubro.DataSource = dt;
                this.comboRubro.DataTextField = "descripcion";
                this.comboRubro.DataValueField = "Id";
                this.comboRubro.DataBind();

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
            SqlDataAdapter sqlDa = new SqlDataAdapter("BuscarProveedorPorId", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            HfId.Value = id.ToString();
            txtCorreo.Value = dtbl.Rows[0]["CorreoElectronico"].ToString();
            txtNombre.Value = dtbl.Rows[0]["Nombre"].ToString();
            txtApellido.Value = dtbl.Rows[0]["Apellidos"].ToString();
            txtNumTel.Value = dtbl.Rows[0]["NumeroTelefonico"].ToString();
            comboRubro.SelectedValue = dtbl.Rows[0]["Rubro_Id"].ToString();
            BotonEliminar.Enabled = true;
            cargarDatos();
        }
        protected void btnEliminar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlDa = new SqlCommand("EliminarProveedorPorID", sqlcon);
            sqlDa.CommandType = CommandType.StoredProcedure;
            sqlDa.Parameters.AddWithValue("@Id", Convert.ToInt32(HfId.Value));
            sqlDa.ExecuteNonQuery();
            sqlcon.Close();
            limpiarProveedor();
            cargarDatos();
        }
        protected void btnExportar_click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=InformeDatosProveedor.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                GridView1.AllowPaging = false;
                this.cargarDatos();

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView1.RenderControl(hw);


                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //verificamos que el control está renderizado
        }

        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
    }
}