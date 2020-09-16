<%@ Page Title="Bandeja Solicitudes" Language="C#" MasterPageFile="~/Empleado/EmpleadoMaster.Master" AutoEventWireup="true" CodeBehind="BandejaEntrada.aspx.cs" Inherits="LindaSonrisa.Empleado.BandejaEntrada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Bandeja de solicitudes de usuario</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Inicio</a></li>
                            <li class="breadcrumb-item active">Bandeja de solicitudes</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>

          <section class="content">
            <div class="row" >
                <div class="col-md-6" style="flex:100%; max-width:100%">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">Bandeja de solicitudes</h3>
                                </div>
                        </div>
                    </div>
                </div>
              <asp:HiddenField ID="hfNombreUsuario" runat="server" />
              <asp:HiddenField ID="hfId" runat="server" />
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Acción" >
                            <ItemTemplate>
                                <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("nombreUsuario") %>' OnClick="btnOtorgarBeneficio_Click" > Otorgar Beneficio 10% de dto</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnEliminarSoli_Click" > Eliminar Solicitud</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario"/>
                        <asp:TemplateField HeaderText="Liquidación de Sueldo">
                            <ItemTemplate>
                                <asp:Image Id="liquidacionSueldo"  ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("liquidacionSueldo")) %>' runat="server" Width="200px" Height="200px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText ="Finiquito">
                            <ItemTemplate>
                                <asp:Image Id="finiquito" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("finiquito")) %>' runat="server" Width="200px" Height="200px"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Pensión Mensual">
                            <ItemTemplate>
                                <asp:Image Id="pensionMensual" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("pensionMensual")) %>' runat="server" Width="200px" Height="200px"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="Jubilación">
                            <ItemTemplate>
                                <asp:Image Id="jubilacion" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("jubilacion")) %>' runat="server" Width="200px" Height="200px"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
              </section>
         </div>
</asp:Content>
