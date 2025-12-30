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
            ProductosNegocio negocio = new ProductosNegocio();

            dgvProductos.DataSource = negocio.Listar();
            dgvProductos.DataBind();
        }
    }
}