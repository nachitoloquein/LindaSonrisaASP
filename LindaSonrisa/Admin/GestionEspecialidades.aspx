<%@ Page Title="Gestion Especialidades" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GestionEspecialidades.aspx.cs" Inherits="LindaSonrisa.Admin.GestionEspecialidades" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Gestión de Especialidades</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                            <li class="breadcrumb-item active">Gestión de Especialidades</li>
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
                            <h3 class="card-title">Especialidad</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="inputName">Especialidad</label>
                               <input type="text" id="txtEspecialidad" class="form-control" runat="server">
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
                    <button class="btn btn-success float-right" id="btnExportar" runat="server" onserverclick="btnExportar_click">Exportar a xlsx</button>
                    
                </div>
            </div>
            <asp:HiddenField ID="hfId" runat="server" />
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Descripcion" HeaderText="Nombre de la especialidad"/>
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
