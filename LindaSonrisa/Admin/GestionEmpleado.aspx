<%@ Page Title="Gestión Empleado" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GestionEmpleado.aspx.cs" Inherits="LindaSonrisa.Admin.GestionEmpleado" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Gestión de Empleado</h1>
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
                            <h3 class="card-title">Usuario</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="inputName">Primer Nombre</label>
                               <input type="text" id="txtPrimerNombre" class="form-control" runat="server">
                            </div>
                             <div class="form-group">
                                <label for="inputName">Segundo Nombre</label>
                               <input type="text" id="txtSegundoNombre" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Apellido Paterno</label>
                               <input type="text" id="txtApPat" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Apellido Materno</label>
                               <input type="text" id="txtApMat" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Correo Electrónico</label>
                               <input type="text" id="TxtCorreo" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Contraseña</label>
                               <input type="text" id="TxtContrasena" class="form-control" runat="server">
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
                    <button class="btn btn-success float-right" id="btnExportar" runat="server" onserverclick="btnExportar_click">Exportar XLSX</button>
                    
                </div>
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre"/>
                        <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre"/>
                        <asp:BoundField DataField="ApellidoPat" HeaderText="Apellido Paterno"/>
                        <asp:BoundField DataField="ApellidoMat" HeaderText="Apellido Materno"/>
                        <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electronico"/>
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
