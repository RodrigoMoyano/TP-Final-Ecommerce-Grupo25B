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
        //Lista de Usuarios
        public List<Usuarios> Listar()
        {
            List<Usuarios> lista = new List<Usuarios>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select U.Id, U.Email, U.Nombre, U.Apellido, U.Telefono, U.TipoUsuario, U.FechaRegistro TP.Descripcion, U.Activo From Usuarios U Inner Join TiposUsuario TP ON U.TipoUsuario = TP.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuarios aux = new Usuarios();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.TiposUsuario = new TiposUsuario();
                    aux.TiposUsuario.Id = (int)datos.Lector["IdTipo"];
                    aux.TiposUsuario.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];
                    aux.Activo = (bool)datos.Lector["Activo"];

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

        //Buscar Usuario por ID
        public Usuarios BuscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select U.Id, U.Email, U.Nombre, U.Apellido, U.Telefono, TP.Id as IdTipo, TP.Descripcion, U.FechaRegistro, U.Activo From Usuarios U Inner Join TiposUsuario TP ON U.TipoUsuario = TP.Id Where U.Id = @Id");
                datos.setearParametro("@Id", id);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuarios aux = new Usuarios();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    aux.TiposUsuario = new TiposUsuario();
                    aux.TiposUsuario.Id = (int)datos.Lector["IdTipo"];
                    aux.TiposUsuario.Descripcion = (string)datos.Lector["Descripcion"];
                    
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

        //El Registro para el Cliente
        public void AgregarCliente(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert Into Usuarios (Email, Clave, Nombre, Apellido, Telefono, TipoUsuario, FechaRegistro, Activo) Values (@Email, @Clave, @Nombre, @Apellido, @Telefono, 2, GETDATE(), 1)");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Clave", usuario.Clave);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Telefono", usuario.Telefono);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar usuario." + ex.Message, ex);
            }
        }
        //Con usuario Administrador, puedo generar tanto un usuario cliente, como un usuario admin, eligiendo el tipousuario
        public void AgregarGeneral(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert Into Usuarios (Email, Clave, Nombre, Apellido, Telefono, TipoUsuario, FechaRegistro, Activo) Values (@Email, @Clave, @Nombre, @Apellido, @Telefono, @TipoUsuario, GETDATE(), 1)");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Clave", usuario.Clave);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Telefono", usuario.Telefono);
                datos.setearParametro("@TipoUsuario", usuario.TiposUsuario);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar usuario." + ex.Message);
            }
        }
        //Eliminar Admin o Cliente
        public void EliminarLogico(int idCliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Usuarios Set Activo = 0 Where Id = @Id");
                datos.setearParametro("@Id", idCliente);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Cliente" + ex.Message);
            }
        }
        //Modificar General
        public void Modificar(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Usuarios Set " +
                  "Email = @Email," +
                  "Clave = @Clave," +
                  "Nombre = @Nombre," +
                  "Apellido = @Apellido," +
                  "Telefono = @Telefono " + 
                  "Where Id = @Id");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Clave", usuario.Clave);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Telefono", usuario.Telefono);
                datos.setearParametro("@Id", usuario.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar Cliente" + ex.Message);
            }
        }
        public bool LogIn(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select U.Id, U.Nombre, U.Apellido, TP.Id as IdTipo, Tp.Descripcion From Usuarios U Inner Join TiposUsuario TP On U.TipoUsuario = TP.Id Where U.Email = @Email and U.Clave = @Clave and U.Activo = 1");

                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Clave", usuario.Clave);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuarios aux = new Usuarios();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.TiposUsuario = new TiposUsuario();
                    aux.TiposUsuario.Id = (int)datos.Lector["IdTipo"];
                    aux.TiposUsuario.Descripcion = (string)datos.Lector["Descripcion"];

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Iniciar Sesion" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
