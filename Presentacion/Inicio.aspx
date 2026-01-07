<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Presentacion.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="repProductos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100 shadow-sm custom-card">

                        <div class="text-center bg-light p-3">
                            <img src="<%# Eval("UrlImagen") %>" class="card-img-top" alt="producto"
                                style="height: 220px; object-fit: contain; width: 100%;">
                        </div>

                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title text-dark"><%# Eval("Nombre") %></h5>
                            <p class="card-text text-muted small"><%# Eval("Descripcion") %></p>

                            <div class="mt-auto">
                                <h3 class="text-primary fw-bold">$ <%# Eval("Precio", "{0:F2}") %></h3>
                            </div>
                        </div>

                        <div class="card-footer bg-white border-top-0 d-grid gap-2 mb-2">
                            <a href="Detalle.aspx?id=<%# Eval("Id") %>" class="btn btn-primary">Ver Detalle</a>
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar al Carrito" CssClass="btn btn-outline-success" />
                        </div>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
