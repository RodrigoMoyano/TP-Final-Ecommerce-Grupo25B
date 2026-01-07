using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuariosNegocio
    {
        public List<Usuarios> Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Email, Clave, Nombre, Apellido, Telefono, TipoUsuario, FechaRegistro From Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuarios aux = new Usuarios();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Clave = (string)datos.Lector["Clave"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.TiposUsuario = new TiposUsuario();
                    aux.TiposUsuario.Id = (int)datos.Lector["IdTipo"];
                    aux.TiposUsuario.Descripcion = (string)datos.Lector["Description"];
                    aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void AgregarCliente(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert Into Usuarios (Email, Clave, Nombre, Apellido, Telefono, TipoUsuario, FechaRegistro) Values (@Email, @Clave, @Nombre, @Apellido, @Telefono, 2, @FechaRegistro)");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Clave", usuario.Clave);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Telefono", usuario.Telefono);
                datos.setearParametro("@FechaRegistro", usuario.FechaRegistro);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar usuario." + ex.Message);
            }
        }
        public void AgregarAdmin(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert Into Usuarios (Email, Clave, Nombre, Apellido, Telefono, TipoUsuario, FechaRegistro) Values (@Email, @Clave, @Nombre, @Apellido, @Telefono, 1, @FechaRegistro)");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Clave", usuario.Clave);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Telefono", usuario.Telefono);
                datos.setearParametro("@FechaRegistro", usuario.FechaRegistro);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar usuario." + ex.Message);
            }
        }
    }
}
