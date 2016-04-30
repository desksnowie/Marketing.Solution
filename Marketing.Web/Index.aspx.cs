using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Marketing.BAL;
using Marketing.BO;

namespace Marketing.Web
{
    /// <summary>
    /// Clase que gestiona las funciones y eventos de un Cliente Potencial
    /// Desarrollado por: Ing. Manuel Enrique Reyes (MCP/MCPD)
    /// Correo: desksnowie@gmail.com
    /// Sitio web: enenstavia.com
    /// </summary>
    public partial class Index : System.Web.UI.Page
    {
        /// <summary>
        /// Carga inicial de la página
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Params</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Parámetros del GridView

            this.MarketingDS.ConnectionString = ConfigurationManager.ConnectionStrings[1].ToString();
            this.MarketingDS.SelectCommand = "SELECT [ID], [Nombre], [Apellido], [Correo], [Edad] FROM [ClientesPotenciales] ORDER BY [ID]";

            #endregion

            #region Carga de Criterios de Búsqueda

            this.ddlCriterios.DataSource = GetCriterios();
            this.ddlCriterios.DataTextField = "Criterio";
            this.ddlCriterios.DataValueField = "ID";
            this.ddlCriterios.DataBind();
            this.ddlCriterios.Items.Insert(0, new ListItem("Seleccione", "0"));

            #endregion
        }

        /// <summary>
        /// Obtiene los Criterios de Búsqueda
        /// </summary>
        /// <returns>Los Criterios de Búsqueda</returns>
        public DataTable GetCriterios()
        {
            ClientePotencialBAL objCriterios = new ClientePotencialBAL();
            return objCriterios.ListarCriteriosBusqueda();
        }

        /// <summary>
        /// Carga los Datos de la columna seleccionada en el GridView
        /// </summary>
        /// <param name="indiceColumna">Indice de la columna seleccionada</param>
        /// <returns>Arreglo de string con los datos del Cliente Potencial seleccionado en el GridView</returns>
        public string[] CargarDatosSeleccion(int indiceColumna)
        {
            #region Cargar Datos de Cliente Seleccionado

            string[] arrayDatosCliente = new string[5];

            // Campos de la columna seleccionada
            string selID = (this.gvClientesPotenciales.GetDataRow(indiceColumna)).ItemArray[0].ToString();
            string selNombre = (this.gvClientesPotenciales.GetDataRow(indiceColumna)).ItemArray[1].ToString();
            string selApellido = (this.gvClientesPotenciales.GetDataRow(indiceColumna)).ItemArray[2].ToString();
            string selCorreo = (this.gvClientesPotenciales.GetDataRow(indiceColumna)).ItemArray[3].ToString();
            string selEdad = (this.gvClientesPotenciales.GetDataRow(indiceColumna)).ItemArray[4].ToString();

            // Datos del Cliente Seleccionado
            arrayDatosCliente[0] = selID;
            arrayDatosCliente[1] = selNombre;
            arrayDatosCliente[2] = selApellido;
            arrayDatosCliente[3] = selCorreo;
            arrayDatosCliente[4] = selEdad;

            #endregion

            return arrayDatosCliente;
        }

        /// <summary>
        /// Refresca el GridView con los nuevos datos buscados
        /// </summary>
        /// <param name="dt"></param>
        public void RefrescarResultados(DataTable dt)
        {
            Session["accionBuscar"] = "buscar";
            this.gvClientesPotenciales.AutoGenerateColumns = true;
            this.gvClientesPotenciales.SettingsBehavior.AllowSelectSingleRowOnly = true;
            this.gvClientesPotenciales.DataSourceID = null;
            this.gvClientesPotenciales.DataSource = dt;
            this.gvClientesPotenciales.DataBind();
        }

        #region Botones Panel de Acciones

        /// <summary>
        /// Evento del botón Buscar
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Params</param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ClientePotencialBAL buscarClientes = new ClientePotencialBAL();
            Buscar busqueda = new Buscar();
            string criterio = string.Empty;
            int criterioValor = 0;
            string criterioBusqueda = string.Empty;
            DataTable dt = new DataTable();

            #region Criterios de Búsqueda

            criterio = this.txtCriterio.Text.Trim();
            criterioValor = int.Parse(this.txtCriterioValor.Text.Trim());
            criterioBusqueda = this.txtBuscar.Text.Trim();

            #endregion

            // Criterio Seleccionado
            if (criterioValor != 0)
            {
                busqueda.Criterio = criterio;
                busqueda.Valor = criterioBusqueda;
                dt = buscarClientes.BuscarClientesPotenciales(busqueda);
                Session["accionBuscar"] = "buscar";
                Session["dt"] = dt;

                // Refrescar el GridView
                RefrescarResultados(dt);
            }
        }

        // <summary>
        /// Evento del botón Insertar
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Params</param>
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Session["TituloPagina"] = "Insertar Nuevo Cliente Potencial :: Dpto. de Marketing";
            Session["AccionPagina"] = "insertar";
            Response.Redirect("InsertarVer.aspx");
        }

        // <summary>
        /// Evento del botón VerDetalle
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Params</param>
        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            string[] arrayDatosCliente = new string[5];
            int indiceColumna = gvClientesPotenciales.FocusedRowIndex;
            string accionBuscar = Session["accionBuscar"].ToString();

            if (accionBuscar != "buscar")
            {
                if (indiceColumna != -1)
                {
                    // Título y Acción de la Página
                    Session["TituloPagina"] = "Actualizar Cliente Potencial :: Dpto. de Marketing";
                    Session["AccionPagina"] = "actualizar";
                    Session["accionBuscar"] = "nobuscar";

                    // Carga de Datos del Cliente Seleccionado
                    arrayDatosCliente = CargarDatosSeleccion(indiceColumna);
                    Session["DatosCliente"] = arrayDatosCliente;

                    Response.Redirect("InsertarVer.aspx");
                }
            }
            else
            {
                // Persisto el Estado de la Acción del Usuario
                Session["accionBuscar"] = "buscar";

                #region Cargo los Datos del Cliente Seleccionado

                indiceColumna = gvClientesPotenciales.FocusedRowIndex;
                object objID = this.gvClientesPotenciales.GetRowValues(indiceColumna, "ID");
                object objNombre = this.gvClientesPotenciales.GetRowValues(indiceColumna, "Nombre");
                object objApellido = this.gvClientesPotenciales.GetRowValues(indiceColumna, "Apellido");
                object objCorreo = this.gvClientesPotenciales.GetRowValues(indiceColumna, "Correo");
                object objEdad = this.gvClientesPotenciales.GetRowValues(indiceColumna, "Edad");

                #endregion

                // Campos de la columna seleccionada
                string selID = objID.ToString();
                string selNombre = objNombre.ToString();
                string selApellido = objApellido.ToString();
                string selCorreo = objCorreo.ToString();
                string selEdad = objEdad.ToString();

                // Datos del Cliente Seleccionado
                arrayDatosCliente[0] = selID;
                arrayDatosCliente[1] = selNombre;
                arrayDatosCliente[2] = selApellido;
                arrayDatosCliente[3] = selCorreo;
                arrayDatosCliente[4] = selEdad;

                // Envío Datos del Cliente Seleccionado
                Session["DatosCliente"] = arrayDatosCliente;

                // Título y Acción de la Página
                Session["TituloPagina"] = "Actualizar Cliente Potencial :: Dpto. de Marketing";
                Session["AccionPagina"] = "actualizar";
                Response.Redirect("InsertarVer.aspx");
            }
        }

        // <summary>
        /// Evento del botón Borrar
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Params</param>
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            string[] arrayDatosCliente = new string[5];
            int idCliente = 0;

            #region Carga Datos de las Columna Seleccionada

            int indiceColumna = gvClientesPotenciales.FocusedRowIndex;
            if (indiceColumna != -1)
            {
                arrayDatosCliente = CargarDatosSeleccion(indiceColumna);
            }

            idCliente = int.Parse(arrayDatosCliente[0]);

            #endregion

            #region Borrar Cliente Seleccionado

            BorrarCliente(idCliente);

            #endregion

            // Mensaje de Borrado
            this.pnlMensajeBorrado.Visible = true;

            // Refrescar el GridView
            this.gvClientesPotenciales.DataBind();            
        }
        /// <summary>
        /// Realiza el borrado del Cliente Potencial seleccionado en el GridView
        /// </summary>
        /// <param name="idCliente">ID del Cliente Potencial seleccionado</param>
        public void BorrarCliente(int idCliente)
        {
            #region Datos Cliente Potencial

            ClientePotencialBAL borrarCliente = new ClientePotencialBAL();
            ClientePotencial cliente = new ClientePotencial();

            cliente.ID = idCliente;

            #endregion

            #region Borrar Cliente Seleccionado

            borrarCliente.BorrarClientePotencial(cliente);
            
            #endregion
        }

        #endregion
    }
}