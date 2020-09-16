<%@ Page Title="Actualizar Datos" Language="C#" MasterPageFile="~/BandejaEntrada/BandejaEntrada.Master" AutoEventWireup="true" CodeBehind="ActualizarUsuario.aspx.cs" Inherits="LindaSonrisa.BandejaEntrada.ActualizarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Actualizar Datos</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                            <li class="breadcrumb-item active">Actualizar Datos</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>

        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-md-6">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">General</h3>


                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="inputName">Liquidaciones de sueldos</label>
                                <asp:FileUpload ID="FileSueldoUs" runat="server" />
                            </div>
                            <div class="form-group">
                                <label for="inputName">Finiquitos</label>
                                <asp:FileUpload ID="FileFiniquUs" runat="server" />
                            </div>
                            <div class="form-group">
                                <label for="inputName">Certificado de pensión mensual</label>
                               <asp:FileUpload ID="FilePensionUs" runat="server" />
                            </div>
                            <div class="form-group">
                                <label for="inputName">Certificado de jubilación</label>
                                <asp:FileUpload ID="FileCertUs" runat="server" />
                            </div>
                            <div class="form-group">
                                <label for="inputStatus">Empleador</label>
                                <asp:DropDownList ID="comboEmpleado" CssClass="form-control custom-select" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
                <div class="col-md-6">
                    <div class="card card-secondary">
                        <div class="card-header">
                            <h3 class="card-title">Ayuda</h3>

                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="inputEstimatedBudget">En esta sección usted puede subir uno de sus documentos en los cuales deja evidenciada su situación económica, con subir al menos uno, nuestros empleadores verán si es aplicable un descuento o un beneficio por su situación socioeconómica</label>
                            </div>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <button class="btn btn-secondary">Cancelar</button>
                    <button class="btn btn-success float-right" runat="server" id="btnEnviar" onserverclick="btnEnviar_click">Enviar</button>
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>
</asp:Content>
