<%@ Page Title="Historial de compras" Language="C#" MasterPageFile="~/Empleado/EmpleadoMaster.Master" AutoEventWireup="true" CodeBehind="HistorialCompras.aspx.cs" Inherits="LindaSonrisa.Empleado.HistorialCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Estados de compra</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Inicio</a></li>
              <li class="breadcrumb-item active">Estado de las compras</li>
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
              <h3 class="card-title">Historial de todas las compras realizadas</h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body">
                <asp:HiddenField ID="hfId" runat="server" />
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("Id") %>'  OnClick ="PedidoRecibido_Click"> Marcar como recibido</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="linkView1" runat="server" CommandArgument='<%# Eval("Id") %>'  OnClick ="PedidoCancelado_Click"> Cancelar Pedido</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FechaPedido" HeaderText="Fecha Del Pedido"/>
                        <asp:BoundField DataField="Proveedor" HeaderText="Proveedor"/>
                        <asp:BoundField DataField="Total" HeaderText="Total"/>
                        <asp:BoundField DataField="OrdenPedido" HeaderText="Orden del pedido"/>
                        <asp:BoundField DataField="Producto" HeaderText="Producto"/>
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
                        <asp:BoundField DataField="EstadoProducto" HeaderText="Estado Del producto"/>
                        
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
</asp:Content>
