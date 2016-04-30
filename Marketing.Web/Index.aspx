<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Marketing.Web.Index" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clientes Potenciales :: Dpto. de Marketing</title>
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
    <form id="frmClientesPotenciales" runat="server" class="full-page-container text-center block" style="top:70px;">
    <h1 class="text-light"><i class="gi gi-address_book"></i> Lista de Clientes Potenciales</h1>
        <!-- Mensaje de Inserción -->
        <asp:Panel ID="pnlMensajeBorrado" runat="server" Visible="false">
            <div class="alert alert-success" style="padding: 2px;">
                <h3><i class="fa fa-check"></i> <strong>Cliente Borrado</strong></h3>
            </div>
        </asp:Panel>
        <div class="form-group">
            <div class="col-md-3 text-left" style="margin-left:35px;">
                <div class="input-group">
                    <asp:DropDownList ID="ddlCriterios" runat="server" onchange="MostrarTextoCriterio()"  class="btn btn-success dropdown-toggle"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-5 text-left" style="margin-left:79px;">
                <div class="input-group">
                    <div class="input-group-btn">
                        <asp:TextBox ID="txtBuscar" runat="server" style="display: none" CssClass="form-control" placeholder="Escriba el criterio a buscar" onkeypress='return ValidarCriterio(event)'></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div id="seleccion-criterios-busqueda" class="text-left">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-success" OnClick="btnBuscar_Click" style="display: none"/>
        </div>
        <div class="text-center" style="width:600px;margin-left:auto;margin-right:auto;">
            <dx:ASPxGridView ID="gvClientesPotenciales" 
                runat="server" 
                AutoGenerateColumns="False" 
                DataSourceID="MarketingDS" 
                EnableTheming="True" 
                KeyFieldName="ID" 
                Theme="Youthful" 
                CssClass="text-center" 
                Width="600px" >
                <Settings ShowHeaderFilterBlankItems="False" />
                <SettingsBehavior 
                    AllowFocusedRow="True" 
                    AllowSelectByRowClick="false" 
                    AllowSelectSingleRowOnly="True" 
                    ProcessSelectionChangedOnServer="True" 
                    ProcessFocusedRowChangedOnServer="true"  />
                <SettingsDataSecurity 
                    AllowDelete="False" 
                    AllowEdit="False" 
                    AllowInsert="False" />
                <Columns>
                    <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Nombre" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Apellido" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Correo" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Edad" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="MarketingDS" runat="server"></asp:SqlDataSource> 
        </div>
        <asp:Button ID="btnInsertar" runat="server" Text="Insertar" class="btn btn-sm btn-success" OnClick="btnInsertar_Click"/>
        <asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle" class="btn btn-sm btn-success" OnClick="btnVerDetalle_Click"/>
        <asp:Button ID="btnBorrar" runat="server" Text="Borrar" class="btn btn-sm btn-danger" OnClick="btnBorrar_Click"/>
        <asp:TextBox ID="txtCriterio" runat="server" style="display:none;"></asp:TextBox>
        <asp:TextBox ID="txtCriterioValor" runat="server" style="display:none;"></asp:TextBox>
    </form>
    
    <script type="text/javascript">

        /// <summary>
        /// Muestra/Oculta el TextBox para las Búsquedas
        /// </summary>
        function MostrarTextoCriterio() {
            var ddlCriterios = document.getElementById("ddlCriterios");
            var valorCriterio = ddlCriterios.value;
            var criterio = $("option:selected", ddlCriterios).text();
            var txtCriterio = document.getElementById("txtCriterio");
            var txtCriterioValor = document.getElementById("txtCriterioValor");
            var txtBuscar = document.getElementById("txtBuscar");
            var btnBuscar = document.getElementById("btnBuscar");

            // Seleccionador de Criterios de Búsqueda
            if ((valorCriterio == "1") || (valorCriterio == "2") ||
                (valorCriterio == "3") || (valorCriterio == "4") ||
                (valorCriterio == "5"))
            {
                txtBuscar.style.display = "block";
                btnBuscar.style.display = "block";
                txtCriterio.value = criterio;
                txtCriterioValor.value = valorCriterio;
                txtBuscar.value = "";
                txtBuscar.focus();
            }
            else
            {
                txtBuscar.style.display = "none";
                btnBuscar.style.display = "none";
                txtBuscar.value = "";
            }
        }

        /// <summary>
        /// Valida los Criterios de Búsqueda para que acepte 
        /// sólo númericos en los campos de búsqueda: ID y Edad
        /// </summary>
        function ValidarCriterio(e)
        {
            var ddlCriterios = document.getElementById("ddlCriterios");
            var valorCriterio = ddlCriterios.value;
            var txtBuscar = document.getElementById("txtBuscar");

            // Validar Criterios de Búsqueda: Sólo Núméricos
            // ID y Edad
            if ((valorCriterio == "1") || (valorCriterio == "5"))
            {
                return event.charCode >= 48 && event.charCode <= 57;
            }
        }

    </script>
    <!-- jQuery, Bootstrap.js, jQuery plugins and Custom JS code -->
    <script src="Content/js/vendor/jquery-1.12.0.min.js"></script>
    <script src="Content/js/vendor/bootstrap.min.js"></script>
    <script src="Content/js/plugins.js"></script>
    <script src="Content/js/app.js"></script>
</body>
</html>
