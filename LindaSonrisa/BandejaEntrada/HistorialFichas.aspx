<%@ Page Title="Historial Fichas" Language="C#" MasterPageFile="~/BandejaEntrada/BandejaEntrada.Master" AutoEventWireup="true" CodeBehind="HistorialFichas.aspx.cs" Inherits="LindaSonrisa.BandejaEntrada.HistorialFichas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Fichas odontológicas</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Inicio</a></li>
              <li class="breadcrumb-item active">Historial de fichas</li>
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
              <h3 class="card-title">Historial de las fichas odontológicas realizadas</h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                    <Columns>
                       
                        <asp:BoundField DataField="MotivoConsulta" HeaderText="Motivo de Consulta"/>
                        <asp:BoundField DataField="Sintomas" HeaderText="Sintomas"/>
                        <asp:BoundField DataField="Diagnostico" HeaderText="Diagnostico"/>
                        <asp:BoundField DataField="Receta" HeaderText="Receta"/>
                        <asp:BoundField DataField="Odontologo" HeaderText="Odontologo"/>
                        
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
