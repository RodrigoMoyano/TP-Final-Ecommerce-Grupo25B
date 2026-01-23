using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //Leer lector desde fuera
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            string cadena = ConfigurationManager.ConnectionStrings["EcommerceDB"].ConnectionString;
            conexion = new SqlConnection(cadena);
            comando = new SqlCommand();
        }
        //Configuro consulta de texto
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;

            comando.Parameters.Clear();
        }
        //Configura procedimiento almacenado
        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }
        //Agrego parametros y evito inyeccion SQL
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor); 
        }
        //Ejecuto lecturas, me trae los Selects
        public void ejecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Ejecuto accion para los update, insert, delete
        public void ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Sevuelve un solo valor
        public int EjecutarAccionEscalar()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                object resultado = comando.ExecuteScalar();
                return resultado != null ? Convert.ToInt32(resultado) : 0;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al ejecutar accion escalar." + ex.Message, ex);
            }
            finally
            {
                cerrarConexion();
            }
        }
        //Cierro la conexion
        public void cerrarConexion()
        {
            if(lector != null)
            {
                lector.Close();
            }
            if(conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
