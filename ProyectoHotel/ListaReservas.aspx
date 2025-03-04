<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ListaReservas.aspx.cs" Inherits="ProyectoHotel.ListaReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" class="contenido-principal">
        <ContentTemplate>
            <div>

                <div class="container">
                    <div class="row g-2">
                        <!-- "g-2" para separación uniforme entre elementos -->
                        <!-- Filtros en una línea -->
                        <div class="col-md-3">
                            <asp:TextBox ID="txtFiltroFecha" runat="server" CssClass="form-control form-control-sm" Placeholder="Fecha (dd/MM/yyyy)"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtFiltroNroHabitacion" runat="server" CssClass="form-control form-control-sm" Placeholder="N° Habitación"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtFiltroDNI" runat="server" CssClass="form-control form-control-sm" Placeholder="DNI Huesped"></asp:TextBox>
                        </div>
                        <!-- Botones alineados en la misma fila -->
                        <div class="col-md-3">

                            <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary btn-sm w-48" Text="Filtrar" OnClick="btnFiltrar_Click" />
                            <asp:Button ID="btnLimpiarFiltros" runat="server" CssClass="btn btn-danger btn-sm w-48" Text="🗑️ Limpiar" OnClick="btnLimpiarFiltros_Click" />

                        </div>
                    </div>
                </div>




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

                <div>
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

                    <button type="button" class=" m-2 btn-editar" data-bs-toggle="modal" data-bs-target="#modalFechaSeleccionada">Detalles de la Reserva </button>
                </div>

                <!-- Modal para mostrar información de la fecha seleccionada -->
                <div class="modal fade" id="modalFechaSeleccionada" tabindex="-1" aria-labelledby="formularioModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content bg-white text-dark">
                            <div class="modal-header">
                                <h5 class="modal-title" id="modalLabel">Detalles de la Fecha Seleccionada</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <!-- Primera columna -->
                                    <div class="col-md-6">
                                        <div class="mb-1">
                                            <label for="txtNroHabitacion" class="form-label">Número de Habitación</label>
                                            <asp:TextBox runat="server" ID="txtNroHabitacion" CssClass="form-control" />
                                        </div>
                                        <div class="mb-1">
                                            <label for="txtCapacidad" class="form-label">Capacidad</label>
                                            <asp:TextBox runat="server" ID="txtCapacidad" CssClass="form-control" />
                                        </div>
                                        <div class="mb-1">
                                            <label for="txtPrecio" class="form-label">Precio por Noche</label>
                                            <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                                        </div>
                                        <div class="mb-1">
                                            <label for="txtDNI" class="form-label">DNI Huésped</label>
                                            <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" />
                                        </div>
                                    </div>

                                    <!-- Segunda columna -->
                                    <div class="col-md-6">
                                        <div class="mb-1">
                                            <label for="txtNombre" class="form-label">Nombre Huésped</label>
                                            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                                        </div>
                                        <div class="mb-1">
                                            <label for="txtTelefono" class="form-label">Teléfono Huésped</label>
                                            <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" />
                                        </div>
                                        <div class="mb-1">
                                            <label for="txtFechaIngreso" class="form-label">Fecha de Ingreso</label>
                                            <asp:TextBox runat="server" ID="txtFechaIngreso" CssClass="form-control" />
                                        </div>
                                        <div class="mb-1">
                                            <label for="txtFechaEgreso" class="form-label">Fecha de Egreso</label>
                                            <asp:TextBox runat="server" ID="txtFechaEgreso" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
