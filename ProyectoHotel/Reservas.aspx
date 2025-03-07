<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="ProyectoHotel.Reservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" class="contenido-principal">
        <ContentTemplate>



            <h1>Gestión de Habitaciones y Reservas</h1>

            <asp:Button ID="btnAgregarHabitacion" runat="server"
                Text="Agregar Habitación"
                CssClass="btn btn-success ms-3"
                OnClick="btnAgregarHabitacion_Click"></asp:Button>


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
                    <asp:BoundField DataField="PrecioBase" HeaderText="Precio Base" />
                    <asp:TemplateField>
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
                            <h5 class="modal-title" id="tituloAgregar" runat="server">Agregar Habitacion</h5>
                            <h5 class="modal-title" id="tituloEditar" runat="server">Editar Habitacion</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>

                        <div class="modal-body">
                            <div class="mb-3">
                                <label for="txtNumero" type="number" class="form-label">Numero habitacion</label>
                                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" />

                            </div>
                            <div class="mb-3">
                                <label for="txtCapacidad" class="form-label">Capacidad de la habitacion</label>
                                <asp:TextBox runat="server" ID="txtCapacidad" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label for="txtPrecioBase" class="form-label">Precio base de la habitacion</label>
                                <asp:TextBox runat="server" ID="txtPrecioBase" CssClass="form-control" />
                            </div>
                            <div class="mb-1">
                                <label for="txtEstado" class="form-label">Estado de la habitacion</label>
                                <asp:DropDownList ID="ddlEstado" runat="server">
                                    <asp:ListItem Text="Disponible" Value="Disponible"></asp:ListItem>
                                    <asp:ListItem Text="Ocupada" Value="Ocupada"></asp:ListItem>
                                    <asp:ListItem Text="Mantenimiento" Value="Mantenimiento"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnaceptar" runat="server" Text="Guardar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="btnEditar" runat="server" Text="Aceptar Cambios" OnClick="btnEditar_Click" CssClass="btn btn-primary" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="modal fade" id="EliminarHabitacion" tabindex="-1" aria-labelledby="formularioModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content bg-white text-dark">

                        <div class="modal-header">
                            <h5 class="modal-title" id="EliminarHab">Eliminar Habitacion</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div class="mb-3">

                                <label for="txtNro" type="number" class="form-label">Numero Habitación</label>
                                <asp:TextBox runat="server" ID="txtNro" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <div class="mb-3 text-center">
                                    <label class="form-label">¿Está seguro que desea eliminar la habitación seleccionada?</label>
                                </div>
                                <div class="d-flex justify-content-around mt-3">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                                    <asp:Button ID="btnEHabitacion" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEHabitacion_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

