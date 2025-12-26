using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direcciones
    {
        public int Id { get; set; }
        public Usuarios IdUsuario { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public bool Activo { get; set; }
    }
}
