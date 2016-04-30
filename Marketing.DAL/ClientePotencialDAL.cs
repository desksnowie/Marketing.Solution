using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing.BO;

namespace Marketing.DAL
{
    /// <summary>
    /// Clase de datos para las funciones del Cliente Potencial
    /// Desarrollado por: Ing. Manuel Enrique Reyes (MCP/MCPD)
    /// Correo: desksnowie@gmail.com
    /// Sitio web: enenstavia.com
    /// </summary>
    public class ClientePotencialDAL
    {

        #region Configuración de la Capa

        public string cnnStr = ConfigurationManager.ConnectionStrings[1].ToString();
        SqlConnection cnn = new SqlConnection();
        DataTable dt = new DataTable();
        ClientePotencial clientePotencialBO = new ClientePotencial();
        Buscar buscarBO = new Buscar();

        #endregion

        #region Listados Clientes Potenciales

        /// <summary>
        /// Lista los Clientes Potenciales
        /// </summary>
        /// <returns>Lista de Clientes Potenciales</returns>
        public DataTable ListarClientesPotenciales()
        {
            cnn.ConnectionString = cnnStr;
            if (ConnectionState.Closed == cnn.State)
            {
                cnn.Open();
            }

            SqlCommand cmd = new SqlCommand("spListarClientesPotenciales", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", clientePotencialBO.ID);
            cmd.Parameters.AddWithValue("@Nombre", clientePotencialBO.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", clientePotencialBO.Apellido);
            cmd.Parameters.AddWithValue("@Correo", clientePotencialBO.Correo);
            cmd.Parameters.AddWithValue("@Edad", clientePotencialBO.Edad);

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseAll(cmd, cnn);
            }
        }

        /// <summary>
        /// Busca los Clientes Potenciales por Criterio y Valor
        /// </summary>
        /// <returns>Lista de Clientes Potenciales por Criterio y Valor</returns>
        public DataTable BuscarClientesPotenciales(Buscar buscarBO)
        {
            cnn.ConnectionString = cnnStr;
            if (ConnectionState.Closed == cnn.State)
            {
                cnn.Open();
            }

            SqlCommand cmd = new SqlCommand("spBuscarClientesPotenciales", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Criterio", buscarBO.Criterio);
            cmd.Parameters.AddWithValue("@Valor", buscarBO.Valor);

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseAll(cmd, cnn);
            }
        }

        /// <summary>
        /// Lista todos los Criterios de Búsqueda
        /// </summary>
        public DataTable ListarCriteriosBusqueda()
        {
            cnn.ConnectionString = cnnStr;
            if (ConnectionState.Closed == cnn.State)
            {
                cnn.Open();
            }

            SqlCommand cmd = new SqlCommand("spListarCriteriosBusqueda", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseAll(cmd, cnn);
            }
        }

        /// <summary>
        /// Crea el siguiente ID para un Nuevo Cliente Potencial
        /// </summary>
        public DataTable CrearSiguienteID()
        {
            cnn.ConnectionString = cnnStr;
            if (ConnectionState.Closed == cnn.State)
            {
                cnn.Open();
            }

            SqlCommand cmd = new SqlCommand("spCrearSiguienteID", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseAll(cmd, cnn);
            }
        }

        #endregion

        #region CRUD Clientes Potenciales
        
        /// <summary>
        /// Crea un Nuevo Cliente Potencial en la base de datos Marketing
        /// </summary>
        public void CrearClientePotencial(ClientePotencial clientePotencialBO)
        {
            cnn.ConnectionString = cnnStr;
            if (ConnectionState.Closed == cnn.State)
            {
                cnn.Open();
            }


            SqlCommand cmd = new SqlCommand("spCrearClientePotencial", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", clientePotencialBO.ID);
            cmd.Parameters.AddWithValue("@Nombre", clientePotencialBO.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", clientePotencialBO.Apellido);
            cmd.Parameters.AddWithValue("@Correo", clientePotencialBO.Correo);
            cmd.Parameters.AddWithValue("@Edad", clientePotencialBO.Edad);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseAll(cmd, cnn);
            }
        }

        /// <summary>
        /// Actualiza a un Cliente Potencial existente en la base de datos Marketing
        /// </summary>
        public void ActualizarClientePotencial(ClientePotencial clientePotencialBO)
        {
            cnn.ConnectionString = cnnStr;
            if (ConnectionState.Closed == cnn.State)
            {
                cnn.Open();
            }


            SqlCommand cmd = new SqlCommand("spActualizarClientePotencial", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", clientePotencialBO.ID);
            cmd.Parameters.AddWithValue("@Nombre", clientePotencialBO.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", clientePotencialBO.Apellido);
            cmd.Parameters.AddWithValue("@Correo", clientePotencialBO.Correo);
            cmd.Parameters.AddWithValue("@Edad", clientePotencialBO.Edad);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseAll(cmd, cnn);
            }
        }

        /// <summary>
        /// Borrar a un Cliente Potencial existente en la base de datos Marketing
        /// </summary>
        public void BorrarClientePotencial(ClientePotencial clientePotencialBO)
        {
            cnn.ConnectionString = cnnStr;
            if (ConnectionState.Closed == cnn.State)
            {
                cnn.Open();
            }


            SqlCommand cmd = new SqlCommand("spBorrarClientePotencial", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", clientePotencialBO.ID);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseAll(cmd, cnn);
            }
        }

        /// <summary>
        /// Cierra todas las conexiones y desecha los comandos hacia la base de datos Marketing
        /// </summary>
        public void CloseAll(SqlCommand cmd, SqlConnection cnn)
        {
            cmd.Dispose();
            cnn.Close();
        }

        #endregion
    }
}
