<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="ProyectoHotel.Reservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" class="contenido-principal">
        <ContentTemplate>

      <%--      <div class="container-fluid ">
                <h2>Filtro de búsqueda para reservar</h2>
                <form class="d-flex" role="search">
                    <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
                    <button class="btn btn-outline-success" type="submit">Search</button>
                </form>
            </div>
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
            </div>--%>


<h1>Gestión de Habitaciones y Reservas</h1>


<button type="button" class="btn btn-secondary me-md-2" data-bs-toggle="modal" data-bs-target="#formularioModalAgregarHabitacion">Agregar Habitacion </button>

<asp:GridView ID="gvHabitaciones" runat="server" AutoGenerateColumns="false" CssClass="mi-tabla" Visible="true">
    <Columns>
        <asp:BoundField DataField="Numero" HeaderText="Habitación" />
        <asp:BoundField DataField="Estado" HeaderText="Estado" />
    </Columns>
</asp:GridView>

          
    <div class="modal fade" id="formularioModalAgregarHabitacion" tabindex="-1" aria-labelledby="formularioModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content bg-white text-dark">

                <div class="modal-header">
                    <h5 class="modal-title" id="formularioModalLabelAgregar">Agregar Habitacion</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="txtNombre" type="number" class="form-label">Numero habitacion</label>
                        <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" />
                    </div>
                     <div class="mb-3">
                        <label for="txtCapacidad" class="form-label">Capacidad de la habitacion</label>
                        <asp:TextBox runat="server" ID="txtCapacidad" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtEstado" class="form-label">Estado de la habitacion</label>
                        <asp:TextBox runat="server" ID="txtEstado" CssClass="form-control" />
                    </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnaceptar" runat="server" Text="aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>


        </ContentTemplate>









    </asp:UpdatePanel>


</asp:Content>

