<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="ProyectoHotel.Reservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" class="contenido-principal">
        <ContentTemplate>



            <h1>Gestión de Habitaciones y Reservas</h1>


            <button type="button" class="btn btn-secondary me-md-2" data-bs-toggle="modal" data-bs-target="#formularioModalAgregarHabitacion">Agregar Habitacion </button>
            

            <asp:GridView ID="gvHabitaciones" runat="server" AutoGenerateColumns="false" CssClass="mi-tabla"
                OnRowCommand="gvHabitaciones_RowCommand">
                <Columns>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnSeleccionar" runat="server" CommandName="Agregar"
                                CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn-accion">
                    ➕ Agregar Reserva
                </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Numero" HeaderText="Habitación" />
                    <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:TemplateField >
                        <ItemTemplate>

                            <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar"
                                CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn-editar">
                    ✏️ Editar
                </asp:LinkButton>


                            <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar"
                                CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn-eliminar">
                    🗑️ Eliminar
                </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

