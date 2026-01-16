using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DireccionesNegocio
    {
        //Listado de Direcciones para el Cliente
        public List<Direcciones> ListarPorId(int idUsuario)
        {
            List<Direcciones> lista = new List<Direcciones>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select D.Id, D.IdUsuario, U.Nombre, U.Apellido, D.Calle, D.Numero, D.Localidad, D.CodigoPostal, D.Activo From Direcciones D Inner Join Usuarios U On D.IdUsuario = U.Id Where D.IdUsuario = @IdUsuario");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Direcciones aux = new Direcciones();
                    aux.Id = (int)datos.Lector["Id"];

                    aux.IdUsuario = new Usuarios();
                    aux.IdUsuario.Id = (int)datos.Lector["IdUsuario"];
                    aux.IdUsuario.Nombre = (string)datos.Lector["Nombre"];
                    aux.IdUsuario.Apellido = (string)datos.Lector["Apellido"];

                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.CodigoPostal = (string)datos.Lector["CodigoPostal"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar Direcciones" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Direcciones BuscarPorId(int id, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, IdUsuario, Calle, Numero, Localidad, CodigoPostal, Activo From Direcciones Where Id = @Id and IdUsuario = @IdUsuario");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@IdUsuario", idUsuario);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Direcciones aux = new Direcciones();

                    aux.Id = (int)datos.Lector["Id"];

                    aux.IdUsuario = new Usuarios();
                    aux.IdUsuario.Id = (int)datos.Lector["IdUsuario"];
                    
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.CodigoPostal = (string)datos.Lector["CodigoPostal"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    return aux;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al buscar Usuario" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //El cliente va apoder agregar direcciones
        public void Agregar(Direcciones direccion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert Direcciones Into(IdUsuario, Calle, Numero, Localidad, CodigoPostal, Activo) Values(@IdUsuario, @Calle, @Numero, @Localidad, @CodigoPostal, 1)");
                datos.setearParametro("@IdUsuario", direccion.IdUsuario);
                datos.setearParametro("@Calle", direccion.Calle);
                datos.setearParametro("@Numero", direccion.Numero);
                datos.setearParametro("@Localidad", direccion.Localidad);
                datos.setearParametro("@CodigoPostal", direccion.CodigoPostal);
                datos.setearParametro("@Id", direccion.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar Direccion" + ex.Message);
            }
        }
        //El cliente va a poder modificar Direcciones
        public void Modificar(Direcciones direccion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Direcciones Set " +
                    "Calle = @Calle, " +
                    "Numero = @Numero, " +
                    "Localidad = @Localidad, " +
                    "CodigoPostal = @CodigoPostal Where Id = @Id");
                datos.setearParametro("@Calle", direccion.Calle);
                datos.setearParametro("@Numero", direccion.Numero);
                datos.setearParametro("@Localidad", direccion.Localidad);
                datos.setearParametro("@CodigoPostal", direccion.CodigoPostal);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar direccion" + ex.Message);
            }
        }
        //El Cliente va a poder eliminar sus direcciones
        public void EliminarLogico(Direcciones direccion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Direcciones Set Activo = 0 Where Id = @Id");
                datos.setearParametro("@Id", direccion.IdUsuario);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Dirreccion" + ex.Message);
            }
        }
    }
}
