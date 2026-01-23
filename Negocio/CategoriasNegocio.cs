using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriasNegocio
    {
        public List<Categorias> Listar(Categorias categoria)
        {
            List<Categorias> lista = new List<Categorias>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion, Activo From Categorias Where Id = @Id");
                datos.setearParametro("@Id", categoria.Id);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Activo = (bool)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar Categorias" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Categorias BuscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion, Activo From Categorias Where Id = @Id");
                datos.setearParametro("@Id", id);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();

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

        public void Agregar( Categorias categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            //El admin puede agregar categorias
            try
            {
                datos.setearConsulta("Insert Categorias Into (Descripcion, Activo) values(@Descripcion, 1)");
                datos.setearParametro("@Descripcion", categoria.Descripcion);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar agregar categoria" + ex.Message);
            }
        }
        //El admin puede modificar el estado categorias
        public void Modificar( Categorias categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Categorias Set Activo = @Activo Where Id = @Id");
                datos.setearParametro("@Activo", categoria.Activo);
                datos.setearParametro("@Id", categoria.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar estdo de categoria" + ex.Message);
            }
        }
        public void Eliminar(Categorias categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Categorias Set Activo = 0 Where Id = @Id");
                datos.setearParametro("@Id", categoria.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al eliminar Categoria" + ex.Message);
            }
        }
    }
}
