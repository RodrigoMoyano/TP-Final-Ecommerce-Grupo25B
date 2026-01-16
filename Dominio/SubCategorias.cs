using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class SubCategorias
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; } 
        public bool Activo { get; set; }
    }
}
