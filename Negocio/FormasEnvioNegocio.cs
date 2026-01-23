using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FormasEnvioNegocio
    {
        public List<FormasEnvio> Listar()
        {
            List<FormasEnvio> lista = new List<FormasEnvio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion, Activo From FormasEnvio");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    FormasEnvio aux = new FormasEnvio();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar Formas de Envio" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public FormasEnvio BuscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion, Activo From FormasPago Where Id = @Id");
                datos.setearParametro("@Id", id);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    FormasEnvio aux = new FormasEnvio();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    return aux;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al buscar Forma de Pago" + ex.Message);
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
