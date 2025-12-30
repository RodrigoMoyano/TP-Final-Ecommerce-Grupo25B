<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Presentacion.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row"> <asp:GridView ID="dgvProductos" runat="server" 
        AutoGenerateColumns="false" 
        ShowHeader="false" 
        GridLines="None" 
        CssClass="w-100"> <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div class="col-12 mb-3"> <div class="card h-100">
                           <img src="<%# Eval("UrlImagen") %>" class="card-img-top" style="max-height: 250px; object-fit: contain;">
                           <div class="card-body">
                               <h5 class="card-title"><%# Eval("Nombre") %></h5>
                               <h4 class="text-primary">$ <%# Eval("Precio") %></h4>
                           </div>
                           <div class="card-footer text-center">
                               <a href="Detalle.aspx?id=<%# Eval("Id") %>" class="btn btn-outline-primary">Ver Detalle</a>
                           </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

</asp:Content>
