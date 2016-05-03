using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Marketing.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Variable de Sesión para gestionar las acciones de Búsqueda
            Session.Add("accionBuscar", string.Empty);
            Session.Add("TituloPagina", string.Empty);
            Session.Add("AccionPagina", string.Empty);
            Session.Add("DatosCliente", string.Empty);
            Session.Add("dt", string.Empty);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}