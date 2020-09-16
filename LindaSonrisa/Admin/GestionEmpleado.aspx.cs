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
    public partial class GestionEmpleado : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BotonEliminar.Enabled = false;
                cargarDatos();
            }

        }

        public void limpiarUsuario()
        {
            hfId.Value = "";
            txtPrimerNombre.Value = "";
            txtSegundoNombre.Value = "";
            txtApPat.Value = "";
            txtApMat.Value = "";
            TxtCorreo.Value = "";
            TxtContrasena.Value = "";
            BotonEliminar.Enabled = false;
        }

        void cargarDatos()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("VerEmpleados", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            GridView1.DataSource = dtbl;
            GridView1.DataBind();
        }
        protected void btnAgregar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("AgregarActualizarEmpleado", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlcmd.Parameters.AddWithValue("@primerNombre", txtPrimerNombre.Value);
            sqlcmd.Parameters.AddWithValue("@segundoNombre", txtSegundoNombre.Value);
            sqlcmd.Parameters.AddWithValue("@apellidoMat", txtApMat.Value);
            sqlcmd.Parameters.AddWithValue("@apellidoPat", txtApPat.Value);
            sqlcmd.Parameters.AddWithValue("@contrasena", TxtContrasena.Value);
            sqlcmd.Parameters.AddWithValue("@correo", TxtCorreo.Value);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            limpiarUsuario();
            cargarDatos();
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("BuscarEmpleadoPorId", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            hfId.Value = id.ToString();
            txtPrimerNombre.Value = dtbl.Rows[0]["PrimerNombre"].ToString();
            txtSegundoNombre.Value = dtbl.Rows[0]["SegundoNombre"].ToString();
            txtApPat.Value = dtbl.Rows[0]["ApellidoPat"].ToString();
            txtApMat.Value = dtbl.Rows[0]["ApellidoMat"].ToString();
            TxtCorreo.Value = dtbl.Rows[0]["CorreoElectronico"].ToString();
            BotonEliminar.Enabled = true;
            cargarDatos();
        }
        protected void btnEliminar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlDa = new SqlCommand("EliminarEmpleadoPorID", sqlcon);
            sqlDa.CommandType = CommandType.StoredProcedure;
            sqlDa.Parameters.AddWithValue("@Id", Convert.ToInt32(hfId.Value));
            sqlDa.ExecuteNonQuery();
            sqlcon.Close();
            limpiarUsuario();
            cargarDatos();
        }
        protected void btnExportar_click(object sender, EventArgs e)
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=InformeDatosEmpleados.xls");
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