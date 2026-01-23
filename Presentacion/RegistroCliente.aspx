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
                <asp:RequiredFieldValidator ErrorMessage="Ingrese su correo electronico" Display="Dynamic" runat="server" CssClass="text-danger" ControlToValidate="txtEmail"/>
                <asp:RegularExpressionValidator CssClass="text-danger" ErrorMessage="Formato email, invalido" Display="Dynamic" ControlToValidate="txtEmail" runat="server" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"/>
            </div>

            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Ingrese una contraseña" Display="Dynamic" ControlToValidate="txtPassword" runat="server" />
                <asp:RegularExpressionValidator ID="revPassword" CssClass="text-danger" ErrorMessage="Minimo 8 caracteres" Display="Dynamic" ControlToValidate="txtPassword" ValidationExpression="^.{8,}$" runat="server" />
            </div>

            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Ingrese su nombre" ControlToValidate="txtNombre" runat="server" />
            </div>

            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Ingrese su apellido" ControlToValidate="txtApellido" runat="server" />
            </div>

            <div class="mb-3">
                <label class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger" Display="Dynamic" ErrorMessage="Ingrese su numero de telefono" ControlToValidate="txtTelefono" runat="server" />
                <asp:RegularExpressionValidator CssClass="text-danger" ErrorMessage="Ingrese un numero valido" ValidationExpression="^\d{8,10}$" ControlToValidate="txtTelefono" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarme" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
                <asp:Button ID="btnCancelar" runat="server" CausesValidation="false" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
            </div>

            <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="text-danger"></asp:Label>
        </div>
    </div>

</asp:Content>
