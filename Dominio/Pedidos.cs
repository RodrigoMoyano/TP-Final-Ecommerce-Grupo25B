using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedidos
    {
        public int Id { get; set; }
        public Usuarios IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public FormasPago IdFormaPago { get; set; }
        public FormasEnvio IdFormasEnvio { get; set; }
        public Direcciones IdDireccionEnvio { get; set; }
        public EstadoPedido IdEstadoPedido { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }
    }
}
