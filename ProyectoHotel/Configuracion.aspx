﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="ProyectoHotel.Configuracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <ul class="nav nav-tabs" id="myTab" role="tablist" sytle="with:100%">
        <li class="nav-item" role="presentation">
            <button class="nav-link active" id="registro-tab" data-bs-toggle="tab" data-bs-target="#registro" type="button" role="tab">Registro</button>
        </li>
        <li class="nav-item" role="presentation">
            <button class="nav-link" id="config-tab" data-bs-toggle="tab" data-bs-target="#configuracion" type="button" role="tab">Configuración</button>
        </li>
    </ul>


    <div class="tab-content mt-3">
        <div class="tab-pane fade show active" id="registro" role="tabpanel" aria-labelledby="home-tab">



            <div class="d-flex justify-content-center align-items-center" style="height: 70vh">

                <div class="col-4">

                    <h2>Registro</h2>
                    <div class="mb-3">
                        <label class="form-label">Usuario</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuer" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Contraseña</label>
                        <div class="input-group">

                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" TextMode="Password" />


                            <button type="button" class="btn btn-outline-secondary" id="togglePassword">
                                <i class="bi bi-eye text-white"></i>
                            </button>
                        </div>
                    </div>


                    <script>
                        document.getElementById("togglePassword").addEventListener("click", function () {
                            const passwordInput = document.getElementById("<%= txtPass.ClientID %>");
                            const icon = this.querySelector("i");


                            if (passwordInput.type === "password") {
                                passwordInput.type = "text";
                                icon.classList.remove("bi-eye");
                                icon.classList.add("bi-eye-slash");
                            } else {
                                passwordInput.type = "password";
                                icon.classList.remove("bi-eye-slash");
                                icon.classList.add("bi-eye");
                            }
                        });

                    </script>
                    <div class="mb-3">
                        <div class="col-6">

                            <asp:Button Text="Registrar" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
                            <a href="Reservas.aspx">Cancelar</a>


                        </div>
                    </div>




                </div>

            </div>
        </div>

    </div>


</asp:Content>
