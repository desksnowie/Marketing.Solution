<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarVer.aspx.cs" Inherits="Marketing.Web.InsertarVer" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Datos Cliente Potencial || Dpto. de Marketing</title>
    <!-- Stylesheets -->
    <!-- Bootstrap is included in its original form, unaltered -->
    <link rel="stylesheet" href="Content/css/bootstrap.min.css"/>

    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="Content/css/plugins.css"/>

    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="Content/css/main.css"/>

    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->

    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
    <link rel="stylesheet" href="Content/css/themes.css"/>
    <!-- END Stylesheets -->

    <!-- Modernizr (browser feature detection library) & Respond.js (enables responsive CSS code on browsers that don't support it, eg IE8) -->
    <script src="Content/js/vendor/modernizr-respond.min.js"></script>
</head>
<body>
    <div>
        <ol class="breadcrumb" style="background-color:#333333;">
            <li data-toggle="tooltip" data-placement="right" title="" data-original-title="Regresar"><a href="Index.aspx"><i class="fa fa-home" style="font-size:25px;"></i></a></li>
        </ol>
    </div>
    <form id="frmInsertar" runat="server" class="full-page-container text-center block" style="top:70px;">
        <h1 class="text-light"><i class="gi gi-user"></i> Datos de Cliente Potencial</h1>
        <!-- Mensaje de Inserción -->
        <asp:Panel ID="pnlMensajeInsercion" runat="server" Visible="false">
            <div class="alert alert-success" style="padding: 2px;">
                <h3><i class="fa fa-check"></i> <strong>Cliente Guardado</strong></h3>
            </div>
        </asp:Panel>
        <!-- Mensaje de Actualización -->
        <asp:Panel ID="pnlMensajeActualizacion" runat="server" Visible="false">
            <div class="alert alert-success" style="padding: 2px;">
                <h3><i class="fa fa-check"></i> <strong>Cliente Actualizado</strong></h3>
            </div>
        </asp:Panel>
        <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h3 class="modal-title text-center">Insertar Cliente</h3>
                    </div>
                    <div class="modal-body">
                        <!-- Formulario Datos del Cliente Potencial -->
                        <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">ID</span>
                            <asp:TextBox ID="txtID" runat="server" class="form-control" disabled="disabled"></asp:TextBox>
                            <span class="input-group-addon"><i class="gi gi-barcode"></i></span>
                        </div>
                    </div>
                    <div class="form-group" data-toggle="tooltip" data-placement="top" title="" data-original-title="Requerido">
                        <div class="input-group">
                            <span class="input-group-addon">Nombres:</span>
                            <asp:TextBox ID="txtNombres" runat="server" class="form-control"></asp:TextBox>
                            <span class="input-group-addon"><i class="gi gi-user"></i></span>
                        </div>
                    </div>
                    <div class="form-group" data-toggle="tooltip" data-placement="top" title="" data-original-title="Requerido">
                        <div class="input-group">
                            <span class="input-group-addon">Apellidos:</span>
                            <asp:TextBox ID="txtApellidos" runat="server" class="form-control"></asp:TextBox>
                            <span class="input-group-addon"><i class="gi gi-user"></i></span>
                        </div>
                    </div>
                    <div class="form-group" data-toggle="tooltip" data-placement="top" title="" data-original-title="Requerido">
                        <div class="input-group">
                            <span class="input-group-addon">Edad:</span>
                            <asp:TextBox ID="txtEdad" runat="server" class="form-control input-datepicker" data-date-format="dd-mm-yyyy" placeholder="dd/mm/yyyy"></asp:TextBox>
                            <span class="input-group-addon"><i class="gi gi-birthday_cake"></i></span>
                        </div>
                    </div>
                    <div class="form-group" data-toggle="tooltip" data-placement="top" title="" data-original-title="Opcional">
                        <div class="input-group">
                            <span class="input-group-addon">Email:</span>
                            <asp:TextBox ID="txtCorreo" runat="server" class="form-control"></asp:TextBox>
                            <asp:Label ID="lblErrorCorreo" runat="server" CssClass="has-error" Text="Escriba un correo válido" Visible="false"></asp:Label>
                            <span class="input-group-addon"><i class="gi gi-envelope"></i></span>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-sm btn-success" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnSalir" runat="server" Text="Salir" class="btn btn-sm btn-warning" OnClick="btnSalir_Click" />
                        <asp:Button ID="btnBorrar" runat="server" Text="Borrar" class="btn btn-sm btn-danger" OnClientClick="BorrarFormulario();" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">

        /// <summary>
        /// Borra los datos ingresados en el formulario por el usuario 
        /// </summary>
        function BorrarFormulario()
        {
            // Datos ingresados en el formulario por el usuario
            var txtNombre = document.getElementById("txtNombres");
            var txtApellido = document.getElementById("txtApellidos");
            var txtCorreo = document.getElementById("txtCorreo");
            var txtEdad = document.getElementById("txtEdad");

            // Borrado general
            txtNombre.value = "";
            txtApellido.value = "";
            txtCorreo.value = "";
            txtEdad.value = "";

            // Focus en Nombre
            txtNombre.focus();
        }

    </script>
    <!-- jQuery, Bootstrap.js, jQuery plugins and Custom JS code -->
    <script src="Content/js/vendor/jquery-1.12.0.min.js"></script>
    <script src="Content/js/vendor/bootstrap.min.js"></script>
    <script src="Content/js/plugins.js"></script>
    <script src="Content/js/app.js"></script>
</body>
</html>