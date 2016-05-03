using Marketing.BAL;
using Marketing.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Marketing.Web
{
    /// <summary>
    /// Clase que gestiona las funciones y eventos 
    /// la Creación y Edición de los datos de un Cliente Potencial
    /// Desarrollado por: Ing. Manuel Enrique Reyes (MCP/MCPD)
    /// Correo: desksnowie@gmail.com
    /// Sitio web: enenstavia.com
    /// </summary>
    public partial class InsertarVer : System.Web.UI.Page
    {
        // <summary>
        /// Carga inicial de la página
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Params</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = Session["TituloPagina"].ToString();
            this.txtNombres.Focus();
            string accionPagina = string.Empty;
            string[] arrayDatosCliente = new string[5];

            if (!Page.IsPostBack)
            {
                accionPagina = Session["AccionPagina"].ToString();

                // Insertar
                if (accionPagina == "insertar")
                {
                    #region Cargar Nuevo ID

                    int siguienteID = GetSiguienteID();
                    this.txtID.Text = siguienteID.ToString();

                    #endregion
                }
                else
                {
                    // Ver Detalle
                    #region Carga de Datos del Cliente

                    arrayDatosCliente = ((string[])Session["DatosCliente"]);
                    this.txtID.Text = arrayDatosCliente[0].ToString();
                    this.txtNombres.Text = arrayDatosCliente[1].ToString();
                    this.txtApellidos.Text = arrayDatosCliente[2].ToString();
                    this.txtCorreo.Text = arrayDatosCliente[3].ToString();
                    this.txtEdad.Text = arrayDatosCliente[4].ToString();

                    #endregion
                }
            }
        }

        /// <summary>
        /// Obtiene el siguiente ID para el nuevo Cliente Potencial
        /// </summary>
        /// <returns>El ID para el nuevo Cliente Potencial</returns>
        public int GetSiguienteID()
        {
            ClientePotencialBAL objSiguienteID = new ClientePotencialBAL();
            DataTable dt = objSiguienteID.CrearSiguienteID();
            int sigID = int.Parse(dt.Rows[0].ItemArray[0].ToString());

            return sigID;
        }

        /// <summary>
        /// Calcula la Edad del Cliente Potencial basado en su Fecha de Nacimiento
        /// </summary>
        /// <param name="FDN">Fecha de Nacimiento del Cliente Potencial</param>
        /// <returns>La Edad del Cliente Potencial</returns>
        public int CalcularEdadCliente(DateTime FDN)
        {
            DateTime PresentYear = DateTime.Now;
            DateTime edadCliente = new DateTime(PresentYear.Subtract(FDN).Ticks);

            return int.Parse(edadCliente.Year.ToString());
        }

        /// <summary>
        /// Valida el formato del Correo del Cliente Potencial
        /// </summary>
        /// <param name="correo">Correo escrito en el formulario</param>
        /// <returns>Validación del Correo del Cliente Potencial</returns>
        public static bool ValidarCorreo(string correo)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(correo, expresion))
            {
                if (Regex.Replace(correo, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Valida los Datos escritos del Cliente Potencial en el formulario
        /// </summary>
        /// <returns>Validación de los Datos del Cliente Potencial</returns>
        public bool ValidarDatos()
        {
            string nombresCliente = this.txtNombres.Text;
            string apellidosCliente = this.txtApellidos.Text;
            string correoCliente = this.txtCorreo.Text;
            string[] arrayDatosCliente = new string[5];
            bool correoValido = false;
            bool datosValidos = false;

            #region Validación

            #region Correo

            correoValido = ValidarCorreo(correoCliente);
            if ((correoCliente == string.Empty) || (correoValido == false))
            {
                // Mostrar Error
                this.lblErrorCorreo.Visible = true;
                this.txtCorreo.Focus();
                datosValidos = false;
            }
            else
            {
                // Quitar Error
                this.lblErrorCorreo.Visible = false;
                this.txtCorreo.Focus();
                datosValidos = true;
            }

            #endregion

            #region Acción Página

            string accionPagina = Session["AccionPagina"].ToString();

            if (accionPagina == "insertar")
            {
                #region Cargar Nuevo ID

                int siguienteID = GetSiguienteID();
                this.txtID.Text = siguienteID.ToString();
    
                #endregion
            }
            else
            {
                arrayDatosCliente = ((string[])Session["DatosCliente"]);
                this.txtID.Text = arrayDatosCliente[0].ToString();
            }

            #endregion

            return datosValidos;

            #endregion
        }

        // <summary>
        /// Evento del botón Guardar
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Params</param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool datosValidos = ValidarDatos();
            if (datosValidos == true)
            {
                #region Deshabilitar TextBoxes y Botones de Acción

                this.txtNombres.CssClass = "form-control disabled";
                this.txtNombres.Enabled = false;
                this.txtApellidos.CssClass = "form-control disabled";
                this.txtApellidos.Enabled = false;
                this.txtCorreo.CssClass = "form-control disabled";
                this.txtCorreo.Enabled = false;
                this.txtEdad.CssClass = "form-control disabled";
                this.txtEdad.Enabled = false;

                // Botones
                this.btnGuardar.CssClass = "btn btn-sm btn-success disabled";
                this.btnGuardar.Enabled = false;
                this.btnBorrar.CssClass = "btn btn-sm btn-danger disabled";
                this.btnBorrar.Enabled = false;

                #endregion

                #region Acción Página

                string accionPagina = Session["AccionPagina"].ToString();

                #endregion

                #region Datos Cliente Potencial

                ClientePotencialBAL crearCliente = new ClientePotencialBAL();
                ClientePotencial cliente = new ClientePotencial();

                cliente.ID = int.Parse(this.txtID.Text.Trim());
                cliente.Nombre = this.txtNombres.Text.Trim();
                cliente.Apellido = this.txtApellidos.Text.Trim();

                #region Calcular la Edad del Cliente

                string formatoEdad = this.txtEdad.Text.Trim();

                // Validar el formato de la fecha de nacimiento del Cliente Potencial
                if (formatoEdad.Contains('-'))
                {
                    DateTime edadActual = Convert.ToDateTime(formatoEdad);

                    // Edad Calculada
                    int calculoEdad = CalcularEdadCliente(edadActual);
                    cliente.Edad = calculoEdad; // Edad Calculada
                    this.txtEdad.Text = calculoEdad.ToString();
                }
                else
                {
                    // Edad actual sin cambios
                    cliente.Edad = int.Parse(this.txtEdad.Text.Trim());
                }

                #endregion

                cliente.Correo = this.txtCorreo.Text.Trim();

                #endregion

                // Acción del Usuario
                if (accionPagina == "insertar")
                {
                    #region Guardar Datos Cliente Potencial Nuevo

                    crearCliente.CrearClientePotencial(cliente);

                    #region Mensaje de Inserción Exitosa

                    this.pnlMensajeActualizacion.Visible = false;
                    this.pnlMensajeInsercion.Visible = true;

                    #endregion

                    #endregion
                }
                else
                {
                    #region Actualizar Datos Cliente Potencial

                    crearCliente.ActualizarClientePotencial(cliente);

                    #region Mensaje de Actualización Exitosa

                    this.pnlMensajeInsercion.Visible = false;
                    this.pnlMensajeActualizacion.Visible = true;

                    #endregion

                    #endregion
                }

            }
        }

        // <summary>
        /// Evento del botón Salir
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Params</param>
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            bool datosValidos = ValidarDatos();
            if (datosValidos == true)
            {
                Response.Redirect("Index.aspx");
            }
        }
    }
}