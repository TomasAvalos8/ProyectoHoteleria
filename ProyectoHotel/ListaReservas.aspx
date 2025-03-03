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


            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px"
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                ForeColor="#003399"
                OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" CellPadding="1" Height="250px" Width="100%">
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <WeekendDayStyle BackColor="#CCCCFF" />
            </asp:Calendar>

            <button type="button" class="btn btn-secondary me-md-2" data-bs-toggle="modal" data-bs-target="#modalFechaSeleccionada">Agregar Habitacion </button>

            <!-- Modal para mostrar información de la fecha seleccionada -->
            <div class="modal fade show" id="modalFechaSeleccionada" tabindex="-1" aria-labelledby="modalLabel"
                aria-hidden="true" runat="server" >
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="modalLabel">Detalles de la Fecha Seleccionada</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnCerrarModal" runat="server" CssClass="btn btn-secondary" Text="Cerrar"  />
                        </div>
                    </div>
                </div>
            </div>

            


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
