<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ListaReservas.aspx.cs" Inherits="ProyectoHotel.ListaReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" class="contenido-principal">
        <ContentTemplate>

            <asp:GridView ID="dgvReservas" runat="server" AutoGenerateColumns="false" CssClass="mi-tabla" Visible="true">
                <Columns>

                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="DNI_Huesped" HeaderText="DNI Huésped" />
                    <asp:BoundField DataField="Nombre_Huesped" HeaderText="Nombre del Huésped" />
                    <asp:BoundField DataField="Numero_Habitacion" HeaderText="N° Habitación" />
                    <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="FechaEgreso" HeaderText="Fecha Egreso" DataFormatString="{0:dd/MM/yyyy}" />
                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
