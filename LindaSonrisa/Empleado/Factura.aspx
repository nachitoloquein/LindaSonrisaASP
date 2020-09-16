<%@ Page Title="Factura" Language="C#" MasterPageFile="~/Empleado/EmpleadoMaster.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="LindaSonrisa.Empleado.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Factura</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Inicio</a></li>
              <li class="breadcrumb-item active">Factura</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>
        <section class="content">
      <div class="container-fluid">
        <div class="row">
          <div class="col-12">
              <div class="invoice p-3 mb-3">
              <!-- title row -->
              <div class="row">
                <div class="col-12">
                  <h4>
                    <i class="fas fa-globe"></i> Linda Sonrisa.
                    <small class="float-right">Fecha: 2/10/2014</small>
                  </h4>
                </div>
                <!-- /.col -->
              </div>
              <!-- info row -->
              <div class="row invoice-info">
                <div class="col-sm-4 invoice-col">
                  Desde
                  <address>
                    <strong>Proveedor.</strong><br>
                    Nombre: Yalila Aguad<br>
                    Teléfono: 40106258<br>
                    Email: yalila@gmail.com
                  </address>
                </div>
                <!-- /.col -->
                <div class="col-sm-4 invoice-col">
                  Para
                  <address>
                    <strong>Empleado</strong><br>
                    Nombre: Juan Perez<br>
                    Email: juanitoPerez@gmail.com
                  </address>
                </div>
                <!-- /.col -->
                <div class="col-sm-4 invoice-col">
                  <b>Factura #9</b><br>
                  <br>
                  <b>Número de orden:</b> <asp:Label ID="lblNumOrden" runat="server" Text="100244416001" ></asp:Label><br>
                </div>
                <!-- /.col -->
              </div>
              <!-- /.row -->

              <!-- Table row -->
              <div class="row">
                <div class="col-12 table-responsive">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                     <Columns>
                        <asp:BoundField DataField="Producto" HeaderText="Producto"/>
                         <asp:BoundField DataField="Total" HeaderText="Total"/>
                    </Columns>
                        </asp:GridView>
                </div>
                <!-- /.col -->
              </div>
              <!-- /.row -->

              <div class="row">
                <!-- accepted payments column -->
                <div class="col-6">
                  <p class="lead">Métodos de pago</p>
                  <img src="dist/img/credit/visa.png" alt="Visa">
                  <img src="dist/img/credit/mastercard.png" alt="Mastercard">
                  <img src="dist/img/credit/american-express.png" alt="American Express">
                  <img src="dist/img/credit/paypal2.png" alt="Paypal">

                  <p class="text-muted well well-sm shadow-none" style="margin-top: 10px;">
                    Este sistema hace uso de la aplicación WebPay Plus para llevar a cabo las transacciones monetarias
                  </p>
                </div>
                <!-- /.col -->
                <!-- /.col -->
              </div>
              <!-- /.row -->

              <!-- this row will not appear when printing -->
              <div class="row no-print">
                <div class="col-12">
                  <button type="button" class="btn btn-primary float-right" runat="server" id="btnImprimir" onclick="window.open('Factura.aspx')"><i class="fas fa-print"></i> Imprimir</button>
                  <button type="button" class="btn btn-primary float-right" id="btnVolver" runat="server" onserverclick="btnVolver_Click" style="margin-right: 5px;">
                    Volver a la página de inicio
                  </button>
                </div>
              </div>
            </div>
            <!-- /.invoice -->
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
  </div>
    <script language="javascript">
window.print();
</script>
</asp:Content>
