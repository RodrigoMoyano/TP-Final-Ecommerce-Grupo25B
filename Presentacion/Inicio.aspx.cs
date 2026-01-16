using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Presentacion
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack){

                ProductosNegocio negocio = new ProductosNegocio();
                List<Productos> lista;

                if (Request.QueryString["buscar"] != null)
                {
                    string filtro = Request.QueryString["buscar"];

                    lista = negocio.BuscarPorNombre(filtro);
                }
                else
                {
                    lista = negocio.Listar();
                }

                if(lista.Count == 0) 
                {
                    lblMensaje.Text = "No se encontraron productos para tu busqueda.";
                    lblMensaje.Visible = true;
                }

                repProductos.DataSource = lista;
                repProductos.DataBind();
            }
        }
    }
}