using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
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
                datos.setearConsulta("Select P.Id, P.Nombre, P.Descripcion, P.Precio, P.Stock, P.UrlImagen, P.Activo, P.IdCategoria, C.Descripcion as CategoriaDesc From Productos P Inner Join Categorias C On P.IdCategoria = C.Id");
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
                    aux.IdCategoria = new Categorias();
                    aux.IdCategoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.IdCategoria.Descripcion = (string)datos.Lector["CategoriaDesc"];

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
    }
}
