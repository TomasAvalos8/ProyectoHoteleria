<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="FormularioReserva.aspx.cs" Inherits="ProyectoHotel.FormularioReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" class="contenido-principal">
        <ContentTemplate>


            <div style="box-sizing: border-box; margin: 0; max-width: 1200px; margin: 0 auto; padding: 0;">
                <div class="row">
                    <!-- Columna Izquierda - Inputs -->
                    <div class="col-md-6" style="margin: 20px 0 0 0">
                        <div class="card p-4" style="border-radius: 10px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);">
                            <h4 style="color: #003399; font-weight: bold; margin-bottom: 15px; margin-top: 0;">Datos de la Reserva</h4>
                            <div class="mb-1">
                                <label for="txtNroHabitacion" class="form-label">Número de Habitación</label>
                                <asp:TextBox runat="server" ID="txtNroHabitacion" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNroHabitacion_TextChanged" />
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
                                <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDNI_TextChanged" />
                            </div>
                            <div class="mb-1">
                                <label for="txtNombre" runat="server" class="form-label" id="lblNombre">Nombre Huésped</label>
                                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                            </div>
                            <div>
                                <label for="txtTelefono" runat="server" class="form-label" id="lblTelefono">Telefono Huésped</label>
                                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" />
                            </div>
                        </div>
                    </div>

                    <!-- Columna Derecha - Calendario -->
                    <div class="col-md-6" style="margin: 0; padding: 5px; box-sizing: border-box;">
                        <div class="card  text-center" style="border-radius: 10px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); padding: 5px 20px 20px 20px; margin: 15px 0 0 0;">
                            <h4 style="color: #003399; font-weight: bold; margin-bottom: 10px; margin-top: 0;">Seleccione las Fechas</h4>
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

                            <!-- Fechas de Ingreso y Egreso -->

                            <label for="txtFechaIngreso" class="form-label" style="margin-top: 10px">Fecha de Ingreso</label>
                            <asp:TextBox runat="server" ID="txtFechaIngreso" CssClass="form-control" ReadOnly="true" placeholder="Seleccionar fecha en calendario" />
                            <label for="txtFechaEgreso" class="form-label">Fecha de Egreso</label>
                            <asp:TextBox runat="server" ID="txtFechaEgreso" CssClass="form-control" ReadOnly="true" placeholder="Seleccionar fecha en calendario" />
                            <asp:Label ID="lblError" runat="server" Text="Label" style="color:red"></asp:Label>
                            <!-- Botones -->

                            <div class="d-flex mt-4 justify-content-between">
                                <a href="Reservas.aspx" type="button" class="btn btn-danger me-2" style="border-radius: 5px; padding: 8px 20px;">Cancelar</a>
                                <asp:Button ID="btnGuardarReserva" runat="server" Text="Confirmar Reserva" OnClick="btnGuardarReserva_Click" CssClass="btn btn-success" Style="border-radius: 5px; padding: 8px 20px;" />
                                <asp:Button ID="btnEditarReserva" runat="server" Text="Editar Reserva" OnClick="btnEditarReserva_Click" CssClass="btn btn-success" Style="border-radius: 5px; padding: 8px 20px;" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
