using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FormasPagoNegocio
    {
        public List<FormasPago> Listar()
        {
            List<FormasPago> lista = new List<FormasPago>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion, Activo From FormasPago");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    FormasPago aux = new FormasPago();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar Formas de Pago" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public FormasPago BuscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion, Activo From FormasPago Where Id = @Id");
                datos.setearParametro("@Id", id);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    FormasPago aux = new FormasPago();

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
            finally { datos.cerrarConexion();}
        }
        public void Agregar(FormasPago formasPago)
        {
            AccesoDatos datos =new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert FormasPago Into(Descripcion, Activo) Values(@Descripcion, 1)");
                datos.setearParametro("@Descripcion", formasPago.Descripcion);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar Forma de Pago"+ ex.Message);
            }
        }
        public void Modificar(FormasPago formasPago)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update FormasPago Set Descripcion = @Descripcion Where Id = @Id");
                datos.setearParametro("@Descripcion", formasPago.Descripcion);
                datos.setearParametro("@Id", formasPago.Id);
                
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al modficar Formas de Pago" + ex.Message);
            }
        }
        public void EliminarLogico(FormasPago formasPago)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update FormasPago Set Activo = @Activo Where Id = @Id"); 
                datos.setearParametro("@Activo", formasPago.Activo);
                datos.setearParametro("@Id", formasPago.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo eliminar la Forma de Pago" + ex.Message);
            }
        }
    }
}