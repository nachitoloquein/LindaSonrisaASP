<%@ Page Title="" Language="C#" MasterPageFile="~/BandejaEntrada/BandejaEntrada.Master" AutoEventWireup="true" CodeBehind="ComprarUsuario.aspx.cs" Inherits="LindaSonrisa.BandejaEntrada.ComprarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Comprar productos</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                            <li class="breadcrumb-item active">Comprar productos</li>
                        </ol>
                    </div>
                </div>
            </div>
            </section>
         <section class="content">
            <div class="row" >
                <div class="col-md-6" style="flex:100%; max-width:100%">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">Usuario</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="inputName">Empleado</label>
                                <asp:DropDownList ID="comboEmpleado" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="comboProveedor_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                             <div class="form-group">
                                <label for="inputName">Producto</label>
                               <asp:DropDownList ID="comboProducto" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            
                             <div class="form-group">
                                <label for="inputName">Cantidad</label>
                                 <asp:TextBox ID="TxtCantidad" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="inputName">Comuna</label>
                               <asp:DropDownList ID="comboComuna" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                             <div class="form-group">
                                <label for="inputName">Dirección</label>
                                 <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="inputName">Total a pagar</label>
                                <asp:TextBox ID="txtTotalAPagar" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>

                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
            </div>
           
            <div class="row">
                <div class="col-12">
                    <asp:Button ID="BotonCancelar" runat="server" Text="Cancelar" CssClass="btn btn-success float-right" onclick ="btnCancelar_Click"/>
                   
                    <button class="btn btn-success float-right" id="btnComprar" runat="server" onserverclick="btnComprar_click" >Comprar</button>
               
                    <button class="btn btn-success float-right" id="btnAgregar" runat="server" onserverclick="btnAgregar_click">Agregar</button>
                    
                </div>
            </div>
             </section>
         </div>
</asp:Content>
