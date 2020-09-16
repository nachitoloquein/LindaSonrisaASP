<%@ Page Title="Gestión de productos" Language="C#" MasterPageFile="~/Empleado/EmpleadoMaster.Master" AutoEventWireup="true" CodeBehind="GestionarProductos.aspx.cs" Inherits="LindaSonrisa.Empleado.GestionarProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Gestión de Productos</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                            <li class="breadcrumb-item active">Gestión de Productos</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>
        <section class="content">
            <div class="row" >
                <div class="col-md-6" style="flex:100%; max-width:100%">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">Producto</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="inputName">Nombre del producto</label>
                               <input type="text" id="txtNombreprod" class="form-control" runat="server">
                            </div>
                             <div class="form-group">
                                <label for="inputName">Fecha de Elaboración</label>
                               <input type="date" id="txtFechaelab" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Fecha de Vencimiento</label>
                               <input type="date" id="txtFechaVenc" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Tipo de producto</label>
                                <asp:DropDownList ID="comboTipoPro" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="inputName">Cantidad</label>
                               <input type="number" id="TxtCantidad" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Precio</label>
                               <input type="text" id="TxtPrecio" class="form-control" runat="server">
                            </div>
                          </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <asp:Button ID="BotonEliminar" runat="server" Text="Eliminar" CssClass="btn btn-success float-right" OnClick="btnEliminar_click" />
                    <button class="btn btn-success float-right" id="btnAgregar" runat="server" onserverclick="btnAgregar_click">Agregar</button>
                    
                </div>
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="NombreProducto" HeaderText="Nombre Del Producto"/>
                        <asp:BoundField DataField="FechaElaboracion" HeaderText="Fecha De Elaboración"/>
                        <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha De Vencimiento"/>
                        <asp:BoundField DataField="Descripcion" HeaderText="Tipo de Producto"/>
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
                        <asp:BoundField DataField="precio" HeaderText="Precio"/>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnEditar_Click"> Editar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>



        </section>
        <!-- /.content -->
    </div>
</asp:Content>
