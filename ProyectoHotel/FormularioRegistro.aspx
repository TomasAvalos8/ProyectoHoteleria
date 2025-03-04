<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioRegistro.aspx.cs" Inherits="ProyectoHotel.FormularioRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body>
 <header>
    <nav class="navbar" style="background-color:#003b95">
        <div class="container-fluid">
            <a class="navbar-brand text-white" href="#">Hoteleria
            </a>
        </div>
    </nav>
</header>
    <form id="form1" runat="server">
        <div class="row justify-content-center align-items-center" style="height: 80vh;width:100%;">
            <div class="col-4"></div>
            <div class="col-4">
                <div class="mb-3">
                    <label for="txtUsuario" class="form-label">Usuario</label>
                    <asp:TextBox runat="server" type="text" CssClass="form-control" ID="txtUser" aria-describedby="emailHelp" />


                </div>
                <div class="mb-3">
                    <label for="txtContraseña" class="form-label">Contraseña</label>
                    <asp:TextBox runat="server" type="password" CssClass="form-control" ID="txtPass" />
                </div>

                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarme" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
                
            </div>
            <div class="col-4"></div>
        </div>
    </form>
</body>
</html>