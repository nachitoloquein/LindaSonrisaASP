<%@ Page  Title="Gestión de productos"Language="C#" MasterPageFile="~/Proveedor/ProveedorMaestro.Master" AutoEventWireup="true" CodeBehind="GestionDeProductosProveedor.aspx.cs" Inherits="LindaSonrisa.Proveedor.GestionDeProductosProveedor" %>
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

        <!-- Main content -->
        <section class="content">
            <div class="row" >
                <div class="col-md-6" style="flex:100%; max-width:100%">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">Productos Proveedor</h3>


                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="inputName">Nombre Producto</label>
                               <input type="text" id="txtNombreProducto" class="form-control" runat="server">
                            </div>
                             <div class="form-group">
                                <label for="inputName">Tipo de Producto</label>
                                 <asp:DropDownList ID="comboTipoProducto" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="inputName">Precio</label>
                               <input type="number" id="txtPrecio" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Cantidad</label>
                               <input type="number" id="txtCantidad" class="form-control" runat="server">
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
            <asp:HiddenField ID="HfId" runat="server" />
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="NombreProducto" HeaderText="Nombre del producto"/>
                        <asp:BoundField DataField="IdTipoProducto" HeaderText="Tipo de producto"/>
                        <asp:BoundField DataField="Precio" HeaderText="Precio"/>
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
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
