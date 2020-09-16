<%@ Page Title="Fichas" Language="C#" AutoEventWireup="true" MasterPageFile="~/Odontologo/OdontologoMaestra.Master" CodeBehind="PanelDeFichas.aspx.cs" Inherits="LindaSonrisa.Odontologo.PanelDeFichas" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Historial de fichas</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                            <li class="breadcrumb-item active">Historial de fichas</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>

        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-md-6" style="flex: 100%; max-width: 100%">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">Ficha</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="inputName">Usuario</label>
                                <asp:DropDownList ID="comboUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
                                    
                            </div>
                            <div class="form-group">
                                <label for="inputName">Motivo de Consulta</label>
                                <input type="text" id="txtMotivo" class="form-control" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Síntomas</label>
                                <textarea id ="txtSintoma" class="form-control" runat ="server"></textarea>
                            </div>
                            <div class="form-group">
                                <label for="inputName">Diagnostico</label>
                                <textarea id ="txtDiagnostico" class="form-control" runat ="server"></textarea>
                            </div>
                            <div class="form-group">
                                <label for="inputName">Receta</label>
                                <textarea id ="txtReceta" class="form-control" runat ="server"></textarea>
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
                    <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
                    <asp:BoundField DataField="MotivoConsulta" HeaderText="Motivo de Consulta" />
                    <asp:BoundField DataField="Sintomas" HeaderText="Sintomas" />
                    <asp:BoundField DataField="Diagnostico" HeaderText="Diagnostico" />
                    <asp:BoundField DataField="Receta" HeaderText="Receta" />
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
