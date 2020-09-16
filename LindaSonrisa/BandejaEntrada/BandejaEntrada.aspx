<%@ Page Title="Consultas Médicas" Language="C#" MasterPageFile="~/BandejaEntrada/BandejaEntrada.Master" AutoEventWireup="true" CodeBehind="BandejaEntrada.aspx.cs" Inherits="LindaSonrisa.BandejaEntrada.BandejaEntrada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
    <link rel="stylesheet" href="plugins/datatables-bs4/css/dataTables.bootstrap4.min.css">
  <link rel="stylesheet" href="plugins/datatables-responsive/css/responsive.bootstrap4.min.css">
   </asp:content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Consultas Médicas</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Inicio</a></li>
              <li class="breadcrumb-item active">Consultas Médicas</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="row">
        <div class="col-12">
          <div class="card">
            <div class="card-header">
              <h3 class="card-title">Historial de todas las horas médicas reservadas</h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body">
                <asp:HiddenField ID="hfId" runat="server" />
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnEliminar_Click" > Eliminar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Fecha Pedido Atención" HeaderText="Fecha Pedido Atención"/>
                        <asp:BoundField DataField="Fecha de Atención" HeaderText="Fecha de Atención"/>
                        <asp:BoundField DataField="Hora de Atención" HeaderText="Hora de Atención"/>
                        <asp:BoundField DataField="Nombre Del Odontologo" HeaderText="Nombre Del Odontologo"/>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
                        <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                        
                    </Columns>
                </asp:GridView>
              
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->

        
            <!-- /.card-header -->
          
            <!-- /.card-body -->
          </div>
          <!-- /.card -->

        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
  </div>
    <script>
  $(function () {
    $("#example1").DataTable({
      "responsive": true,
      "autoWidth": false,
    });
    $('#example2').DataTable({
      "paging": true,
      "lengthChange": false,
      "searching": false,
      "ordering": true,
      "info": true,
      "autoWidth": false,
      "responsive": true,
    });
  });
</script>
<!-- Page specific script -->

</asp:Content>
