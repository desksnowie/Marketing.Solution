using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.BO
{
    /// <summary>
    /// Clase de negocio para los datos del Cliente Potencial
    /// Desarrollado por: Ing. Manuel Enrique Reyes (MCP/MCPD)
    /// Correo: desksnowie@gmail.com
    /// Sitio web: enenstavia.com
    /// </summary>
    public class ClientePotencial
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
    }
}
