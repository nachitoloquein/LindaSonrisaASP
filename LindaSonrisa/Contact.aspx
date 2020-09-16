<%@ Page Title="Contacto " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LindaSonrisa.Contact" %>



<asp:Content ID="HeadCont" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="css/style.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <section class="page-info-section set-bg" data-setbg="img/page-info-bg/3.jpg">
		<div class="container">
			<h2>Contáctanos</h2>
		</div>
	</section>
  <section class="contact-section spad">
		<div class="container">
			<div class="row">
				<div class="col-lg-6">
					<div class="contact-text">
						<h3>Contácto general</h3>
						<div class="contact-info">
							<div class="ci-image set-bg" data-setbg="img/doctors/1.jpg"></div>
							<div class="ci-content">
								<p>4127 Raoul Wallenber4127 Raoul Wallen berg Placea</p>
								<p>+56 9 4010 6258</p>
								<p>office@yourbusiness.com</p>
							</div>
						</div>
					</div>
					<section class="contact-form">
						<input type="text" runat="server" id="txtNombre" required placeholder="Nombre">
						<input type="email" runat="server" id="txtCorreo" required placeholder="Correo electrónico">
						<input  runat="server" id="txtAsunto" required placeholder="Asunto">
						<textarea required runat="server" id="txtMensaje" placeholder="Mensaje"></textarea>
                        <asp:Button ID="btnnviar" runat="server" Text="Enviar" OnClick="Clicknviar" Cssclass="site-btn" />
					</section>
				</div>
			</div>
		</div>
		<div class="map" id="map-canvas">
		</div>
	</section>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB0YyDTa0qqOjIerob2VTIwo_XVMhrruxo"></script>
	<script src="js/map.js"></script>
</asp:Content>
