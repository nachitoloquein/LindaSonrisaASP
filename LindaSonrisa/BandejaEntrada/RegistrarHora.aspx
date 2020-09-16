<%@ Page Title="Registrar Hora" Language="C#" MasterPageFile="~/BandejaEntrada/BandejaEntrada.Master" AutoEventWireup="true" CodeBehind="RegistrarHora.aspx.cs" Inherits="LindaSonrisa.BandejaEntrada.RegistrarHora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Registrar Hora</h1>
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
            <div class="row">
                <div class="col-md-6" style="flex: 100%; max-width: 100%">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">Usuario</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="inputName">Fecha de atención</label>
                                <input type="date" id="txtFechaAtención" class="form-control" runat="server" min="2020-07-07">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Hora de atención</label>
                                <input type="time" id="txtHoraAtencion" class="form-control" runat="server" min="08:00" max="19:00">
                            </div>
                            <div class="form-group">
                                <label for="inputName">Profesional a cargo</label>
                                <asp:DropDownList ID="comboProfesional" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="inputName">Tipo de servicio</label>
                                <asp:DropDownList ID="comboServicio" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
            </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Button ID="BotonEliminar" runat="server" Text="Cancelar" CssClass="btn btn-success float-right" OnClick="btnEliminar_click" />
            <button class="btn btn-success float-right" id="btnAgregar" runat="server" onserverclick="btnAgregar_click">Agregar</button>

        </div>
    </div>
    </section>
        </div>
</asp:Content>
