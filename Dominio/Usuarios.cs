using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public TiposUsuario TiposUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
        public Usuarios()
        {
            TiposUsuario = new TiposUsuario();
        }
    }
}
