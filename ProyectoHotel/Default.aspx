<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoHotel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <h2>Filtro de búsqueda para reservar</h2>
            <h2>Tabla de habitaciones con seleccionable</h2>

            <!-- Calendario ASP.NET -->
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px"
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                ForeColor="#003399"
                OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" CellPadding="1" Height="200px" Width="220px">
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <WeekendDayStyle BackColor="#CCCCFF" />
            </asp:Calendar>


            <asp:Button ID="btnReservar" runat="server" Text="Reservar Fecha" OnClick="btnReservar_Click" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar Fechas" OnClick="btnLimpiar_Click" />

            <!-- Etiqueta para mostrar la fecha seleccionada -->
            <div class="calendar-footer-container">
                <h3>Fechas Reservadas:</h3>
                <asp:Label ID="lblReservas" runat="server" Text="Ninguna"></asp:Label>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
