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

namespace LindaSonrisa.Admin
{
    public partial class GestionDeOdontologos : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-CH3B2RV\\SQLEXPRESS;Initial Catalog=LindaSonrisa;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BotonEliminar.Enabled = false;
                cargarDatos();
                cargarEspecialidad();
            }
        }
        public void limpiar()
        {
            hfId.Value = "";
            txtPrimerNombre.Value = "";
            txtSegundoNombre.Value = "";
            txtApPat.Value = "";
            txtApMat.Value = "";
            comboEspecialidad.SelectedValue = "1";
            TxtContrasena.Value = "";
            BotonEliminar.Enabled = false;
        }
        void cargarDatos()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("VerOdontologo", sqlcon);
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
            SqlCommand sqlcmd = new SqlCommand("AgregarActualizarOdontologo", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@id", (hfId.Value == "" ? 0 : Convert.ToInt32(hfId.Value)));
            sqlcmd.Parameters.AddWithValue("@PNombre ", txtPrimerNombre.Value);
            sqlcmd.Parameters.AddWithValue("@SNombre", txtSegundoNombre.Value);
            sqlcmd.Parameters.AddWithValue("@ApellidoMat ", txtApMat.Value);
            sqlcmd.Parameters.AddWithValue("@ApellidoPat", txtApPat.Value);
            sqlcmd.Parameters.AddWithValue("@Contrasena", TxtContrasena.Value);
            sqlcmd.Parameters.AddWithValue("@Especialidad_id", comboEspecialidad.SelectedValue);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            limpiar();
            cargarDatos();
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("BuscarOdontologoId", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlcon.Close();
            hfId.Value = id.ToString();
            txtPrimerNombre.Value = dtbl.Rows[0]["PNombre"].ToString();
            txtSegundoNombre.Value = dtbl.Rows[0]["SNombre"].ToString();
            txtApPat.Value = dtbl.Rows[0]["ApellidoPat"].ToString();
            txtApMat.Value = dtbl.Rows[0]["ApellidoMat"].ToString();
            comboEspecialidad.SelectedValue = dtbl.Rows[0]["Especialidad_Id"].ToString();
            BotonEliminar.Enabled = true;
            cargarDatos();
        }
        protected void btnEliminar_click(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand sqlDa = new SqlCommand("EliminarOdontologoPorId", sqlcon);
            sqlDa.CommandType = CommandType.StoredProcedure;
            sqlDa.Parameters.AddWithValue("@id", Convert.ToInt32(hfId.Value));
            sqlDa.ExecuteNonQuery();
            sqlcon.Close();
            limpiar();
            cargarDatos();
        }
        protected void btnExportar_click(object sender, EventArgs e)
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=InformeDatosOdontologo.xls");
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
        void cargarEspecialidad()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandText = "CargarEspecialidad";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlcon;

                cmd.ExecuteScalar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                this.comboEspecialidad.DataSource = dt;
                this.comboEspecialidad.DataTextField = "Descripcion";
                this.comboEspecialidad.DataValueField = "Id";
                this.comboEspecialidad.DataBind();

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