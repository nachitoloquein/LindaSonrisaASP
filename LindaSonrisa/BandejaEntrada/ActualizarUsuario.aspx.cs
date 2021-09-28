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
    public partial class ActualizarUsuario : System.Web.UI.Page
    {
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
                    Response    .Redirect("../Login.aspx");
                }

                CargarComboEmpleado();
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
                cmd.CommandText = "OrdenarEmpleador";
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

        protected void btnEnviar_click(object sender, EventArgs e)
        {
            if (comboEmpleado.SelectedValue.ToString() == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Debe ingresar un empleador para registrar sus datos'); ", true);
                return;
            }
            if (FileSueldoUs.FileBytes.ToString() == "" &&  FileFiniquUs.FileBytes.ToString() == "" && FilePensionUs.FileBytes.ToString() == "" && FileCertUs.FileBytes.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Debe ingresar al menos un documento'); ", true);
                return;
            }



            try
            {
                SqlConnection conectar = new SqlConnection(cnString);
                conectar.Open();
                string comandoInsertar = "insert into recepcionSolicitudes (nombreUsuario, liquidacionSueldo, finiquito,pensionMensual, jubilacion, idempleador) values(@nombreUsuario, @liquidacionSueldo,  @finiquito, @pensionMensual, @jubilacion, @idempleador)";
                SqlCommand cmd = new SqlCommand(comandoInsertar, conectar);
                cmd.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = Session["Usuario"].ToString();
                cmd.Parameters.Add("@liquidacionSueldo", SqlDbType.VarBinary).Value = FileSueldoUs.FileBytes;
                cmd.Parameters.Add("@finiquito", SqlDbType.VarBinary).Value = FileFiniquUs.FileBytes;
                cmd.Parameters.Add("@pensionMensual", SqlDbType.VarBinary).Value = FilePensionUs.FileBytes;
                cmd.Parameters.Add("@jubilacion", SqlDbType.VarBinary).Value = FileCertUs.FileBytes;
                cmd.Parameters.Add("@idempleador", SqlDbType.Int).Value = comboEmpleado.SelectedValue;
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Estimado(a), su solicitud fue enviada con éxito'); ", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(ex)", true);
                System.Diagnostics.Debug.WriteLine(ex);

            }


        }
    }
}
