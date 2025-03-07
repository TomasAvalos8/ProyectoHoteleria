<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ProyectoHotel.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" d-flex justify-content-center align-items-center">

        <div class="container text-center">

            <h2 class="text-danger">¡Error!</h2>
            <asp:Label ID="lblError" runat="server" CssClass="fw-bold text-danger"></asp:Label>

            <div class="mt-3">
                <asp:TextBox ID="txtErrorDetails" runat="server" CssClass="form-control"
                    TextMode="MultiLine" ReadOnly="true" Rows="4"></asp:TextBox>
            </div>

            <div class="mt-4">
                <asp:Button ID="btnVolver" runat="server" CssClass="btn-editar"
                    Text="Volver al Inicio" OnClick="btnVolver_Click" />

            </div>
        </div>
    </div>
</asp:Content>
