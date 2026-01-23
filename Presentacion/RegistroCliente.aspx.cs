using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            try
            {
                Page.Validate();
                if(!Page.IsValid)
                {
                    return;
                }

                Usuarios client = new Usuarios();

                client.Email = txtEmail.Text;
                client.Clave = txtPassword.Text;
                client.Nombre = txtNombre.Text;
                client.Apellido = txtApellido.Text;
                client.Telefono = txtTelefono.Text;

                UsuariosNegocio negocio = new UsuariosNegocio();
                if(negocio.ExisteEmail(client.Email))
                {
                    lblMensaje.Text = "Error: El usuario ya fue registro.";
                    return;
                }
                
                negocio.AgregarCliente(client);
                Response.Redirect("Inicio.aspx?msg=registrado", false);
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                lblMensaje.Text = "Error al registrar Cliente: " + msg;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}