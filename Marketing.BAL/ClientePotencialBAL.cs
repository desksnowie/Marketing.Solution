using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Marketing.BO;
using Marketing.DAL;

namespace Marketing.BAL
{
    /// <summary>
    /// Clase de negocios para las funciones del Cliente Potencial
    /// Desarrollado por: Ing. Manuel Enrique Reyes (MCP/MCPD)
    /// Correo: desksnowie@gmail.com
    /// Sitio web: enenstavia.com
    /// </summary>
    public class ClientePotencialBAL
    {
        #region Listados Clientes Potenciales
        
        // <summary>
        /// Lista los Clientes Potenciales
        /// </summary>
        /// <returns>Lista de Clientes Potenciales</returns>
        public DataTable ListarClientesPotenciales()
        {
            try
            {
                ClientePotencialDAL objDAL = new ClientePotencialDAL();
                return objDAL.ListarClientesPotenciales();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Busca los Clientes Potenciales por Criterio y Valor
        /// </summary>
        /// <returns>Lista de Clientes Potenciales por Criterio y Valor</returns>
        public DataTable BuscarClientesPotenciales(Buscar buscarBO)
        {
            try
            {
                ClientePotencialDAL objDAL = new ClientePotencialDAL();
                return objDAL.BuscarClientesPotenciales(buscarBO);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Lista todos los Criterios de Búsqueda
        /// </summary>
        public DataTable ListarCriteriosBusqueda()
        {
            try
            {
                ClientePotencialDAL objDAL = new ClientePotencialDAL();
                return objDAL.ListarCriteriosBusqueda();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Crea el siguiente ID para un Nuevo Cliente Potencial
        /// </summary>
        public DataTable CrearSiguienteID()
        {
            try
            {
                ClientePotencialDAL objDAL = new ClientePotencialDAL();
                return objDAL.CrearSiguienteID();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region CRUD Clientes Potenciales
        
        /// <summary>
        /// Crea un Nuevo Cliente Potencial en la base de datos Marketing
        /// </summary>
        public void CrearClientePotencial(ClientePotencial clientePotencialBO)
        {
            ClientePotencialDAL objDAL = new ClientePotencialDAL();
            objDAL.CrearClientePotencial(clientePotencialBO);
        }

        /// <summary>
        /// Actualiza a un Cliente Potencial existente en la base de datos Marketing
        /// </summary>
        public void ActualizarClientePotencial(ClientePotencial clientePotencialBO)
        {
            ClientePotencialDAL objDAL = new ClientePotencialDAL();
            objDAL.ActualizarClientePotencial(clientePotencialBO);
        }

        /// <summary>
        /// Borrar a un Cliente Potencial existente en la base de datos Marketing
        /// </summary>
        public void BorrarClientePotencial(ClientePotencial clientePotencialBO)
        {
            ClientePotencialDAL objDAL = new ClientePotencialDAL();
            objDAL.BorrarClientePotencial(clientePotencialBO);
        }

        #endregion
    }
}
