<%@ Page Title="Iniciar Sesión Administrador " Language="C#" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="LindaSonrisa.Admin.LoginAdmin" %>
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link href="../img/teeth-icon.png" rel="shortcut icon" />
<!--===============================================================================================-->
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
    <title>Login Admin</title>
<!--===============================================================================================-->
</head>
<body>
	
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-form-title" style="background-image: url(images/bg-01.jpg);">
					<span class="login100-form-title-1">
						Admin | Iniciar Sesión
					</span>
				</div>

				<form class="login100-form validate-form" id="loginId" runat="server">
					<div class="wrap-input100 validate-input m-b-26" data-validate="Username is required">
						<span class="label-input100">Correo Electrónico</span>
						<input class="input100" type="text" name="username" placeholder="Ingrese su correo electrónico" id="txtCorreo" runat="server">
						<span class="focus-input100"></span>
					</div>

					<div class="wrap-input100 validate-input m-b-18" data-validate = "Password is required">
						<span class="label-input100">Contraseña</span>
						<input class="input100" type="password" name="pass" placeholder="Ingrese su contraseña" id="txtcontrasena" runat="server">
						<span class="focus-input100"></span>
					</div>

					<div class="flex-sb-m w-full p-b-30">
						<div class="contact100-form-checkbox">
							<input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me">
							<label class="label-checkbox100" for="ckb1">
								Recuérdame
							</label>
						</div>
					</div>

					<div class="container-login100-form-btn">
						<%-- <button class="login100-form-btn" runat="server" id="btnEntrar" onserverclick="btnEntrar_click">
							Entrar
						</button> --%>
                        <asp:Button ID="btnEntrarASP" runat="server" Text="Entrar" OnClick="btnEntrar_click" CssClass="login100-form-btn"/>
					</div>
				</form>
			</div>
		</div>
	</div>
	
<!--===============================================================================================-->
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

</body>
</html>
