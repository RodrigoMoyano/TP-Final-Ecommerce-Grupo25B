using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductosNegocio
    {
        public List<Productos> Listar()
        {
            List<Productos> lista = new List<Productos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"Select P.Id, P.Nombre, P.Descripcion, P.Precio, P.Stock, P.UrlImagen, P.Activo, P.IdSubCategoria, SC.Descripcion as SubCategoriaDesc From Productos P Inner Join SubCategorias SC On P.IdSubCategoria = SC.Id");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Productos aux = new Productos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    //Valido precio
                    if (!(datos.Lector["Precio"] is DBNull)){
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    }

                    //Valido stock
                    if (!(datos.Lector["Stock"] is DBNull))
                    {
                        aux.Stock = (int)datos.Lector["Stock"];
                    }

                    //Valido Imagen, puede ser null en la db
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    }

                    aux.Activo = (bool)datos.Lector["Activo"];

                    //Instancio Categoria dentro de productos, por la composicion en la clase Producto en Dominio
                    aux.IdSubCategoria = new SubCategorias();
                    aux.IdSubCategoria.Id = (int)datos.Lector["IdSubCategoria"];
                    aux.IdSubCategoria.Descripcion = (string)datos.Lector["SubCategoriaDesc"];

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

        public List<Productos> BuscarPorNombre(string busqueda)
        {
            List<Productos> lista = new List<Productos>();
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("Select P.Id, P.IdSubCategoria, SC.Descripcion as SubCategoria, P.Nombre, P.Descripcion, P.Precio, P.Stock, P.UrlImagen, P.Activo From Productos P Inner Join SubCategorias SC On P.IdSubCategoria = SC.Id Where P.Nombre LIKE @Busqueda AND P.Activo = 1");
            datos.setearParametro("@Busqueda", "%" +  busqueda + "%");

            datos.ejecutarLectura();
            try
            {
                while(datos.Lector.Read())
                {
                    Productos producto = new Productos();

                    producto.Id = (int)datos.Lector["Id"];

                    producto.IdSubCategoria = new SubCategorias();
                    producto.IdSubCategoria.Id = (int)datos.Lector["IdSubCategoria"];
                    producto.IdSubCategoria.Descripcion = (string)datos.Lector["SubCategoria"];

                    producto.Nombre = (string)datos.Lector["Nombre"];
                    producto.Descripcion = (string)datos.Lector["Descripcion"];
                    producto.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["Stock"] is DBNull))
                    producto.Stock = (int)datos.Lector["Stock"];
                    
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        producto.UrlImagen = (string)datos.Lector["UrlImagen"];

                    producto.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(producto);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al buscar Producto" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Agregar(string producto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //datos.setearConsulta()
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar Producto" + ex.Message);
            }
        }
    }
}
