<%@ Page Title="Recuperar Contraseña " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarContrasena.aspx.cs" Inherits="LindaSonrisa.RecuperarContrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="LoginEstilos/vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginEstilos/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginEstilos/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginEstilos/vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="LoginEstilos/vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginEstilos/vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginEstilos/vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="LoginEstilos/vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginEstilos/css/util.css">
	<link rel="stylesheet" type="text/css" href="LoginEstilos/css/main.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-form-title" style="background-image: url(LoginEstilos/images/bg-01.jpg);">
					<span class="login100-form-title-1">
						Recuperar Contraseña
					</span>
				</div>

				<section class="login100-form validate-form">
					<div class="wrap-input100 validate-input m-b-26">
						<span class="label-input100">Correo Electrónico</span>
						<input class="input100" type="email" name="username" id="txtUser" runat="server" placeholder="Ingrese su correo electrónico">
						<span class="focus-input100"></span>
					</div>
					<div class="container-login100-form-btn">
						<button class="login100-form-btn" id="btnEnviar" runat="server" onserverclick="btnEnviar_Click">
							Enviar
						</button>
					</div>
				</section>
			</div>
		</div>
	</div>
    <script src="LoginEstilos/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="LoginEstilos/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="LoginEstilos/vendor/bootstrap/js/popper.js"></script>
	<script src="LoginEstilos/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="LoginEstilos/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="LoginEstilos/vendor/daterangepicker/moment.min.js"></script>
	<script src="LoginEstilos/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="LoginEstilos/vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="LoginEstilos/js/main.js"></script>
</asp:Content>
