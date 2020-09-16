
<%@ Page Title="Gestion Proveedor" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GestionProveedor.aspx.cs" Inherits="LindaSonrisa.Admin.GestionProveedor" EnableEventValidation = "false" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
     <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Gestión de Proveedor</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                            <li class="breadcrumb-item active">Gestión de Usuario</li>
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
                            <h3 class="card-title">Proveedor</h3>


                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="inputName">Nombre</label>
                               <input type="text" id="txtNombre" class="form-control" runat="server">
                            </div>
                             <div class="form-group">
                                <label for="inputName">Apellido</label>
                               <input type="text" id="txtApellido" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Número Telefónico</label>
                               <input type="text" id="txtNumTel" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Rubro</label>
                                <asp:DropDownList ID="comboRubro" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="inputName">Correo Electrónico</label>
                               <input type="text" id="txtCorreo" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Contraseña</label>
                               <input type="text" id="txtContrasena" class="form-control" runat="server">
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
                    <button class="btn btn-success float-right" id="BtnExportar" runat="server" onserverclick="btnExportar_click">Exportar XLSX</button>
                    
                </div>
            </div>
            <asp:HiddenField ID="HfId" runat="server" />
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                        <asp:BoundField DataField="Apellidos" HeaderText="Apellido"/>
                        <asp:BoundField DataField="NumeroTelefonico" HeaderText="Número Telefónico"/>
                        <asp:BoundField DataField="descripcion" HeaderText="Rubro"/>
                        <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico"/>
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
