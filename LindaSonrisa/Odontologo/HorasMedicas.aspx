<%@ Page Title="" Language="C#" MasterPageFile="~/Odontologo/OdontologoMaestra.Master" AutoEventWireup="true" CodeBehind="HorasMedicas.aspx.cs" Inherits="LindaSonrisa.Odontologo.HorasMedicas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Consultas Médicas</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Inicio</a></li>
              <li class="breadcrumb-item active">Consultas Médicas</li>
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
              <h3 class="card-title">Historial de todas las horas médicas reservadas</h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body">
                <asp:HiddenField ID="hfId" runat="server" />
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnRealizada_Click" > Marcar como Realizada</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FechaAtencion" HeaderText="Fecha de Atención"/>
                        <asp:BoundField DataField="HoraAtencion" HeaderText="Hora de Atención"/>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
                        <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                        <asp:BoundField DataField="nombre_usuario" HeaderText="Usuario"/>
                        
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
