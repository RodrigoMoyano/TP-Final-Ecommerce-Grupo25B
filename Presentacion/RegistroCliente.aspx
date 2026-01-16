<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="Presentacion.RegistroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="row">
        <div class="col-md-6 offset-md-3">
            <h2>Crear Cuenta</h2>
            <hr />

            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarme" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
            </div>

            <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="text-danger"></asp:Label>
        </div>
    </div>

</asp:Content>
