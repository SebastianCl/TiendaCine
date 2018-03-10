<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmFactura.aspx.cs" Inherits="prjCinema1.Factura" %>
<%@ MasterType VirtualPath="~/frmPrincipal.Master" %>
<%--Esto es para indicar que se usara un componente de la Master Page--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Factura</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row text-center">
        <asp:Label ID="Label1" runat="server" CssClass="h1" Text="Factura - Atu Waku Cinemas" ForeColor="#000066"></asp:Label>
    </div>
    <br />
    <br />
    <div class="row text-center">
        <asp:Label ID="lblSucursal" runat="server" CssClass="h1" ForeColor="#000066" Text="Nombre sucursal"></asp:Label>
    </div>
    <br /> 
    <div class="row Centrar-Medio">
        <div class="col-md-4">
            <asp:Label ID="Label2" runat="server" CssClass="h4 text-left" Text="Número de factura:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtNFactura" runat="server" CssClass="h4 text-center" ReadOnly="true" Width="60px"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="Label3" runat="server" CssClass="h4 text-left" Text="Fecha de venta:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="txtFecha" runat="server" CssClass="h4 text-center" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label4" runat="server" CssClass="h4 text-left" Text="Cliente:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="txtCliente" runat="server" CssClass="h4 text-center" ReadOnly="true" Width="179px"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="Label5" runat="server" CssClass="h4 text-left" Text="Documento:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="txtDocumento" runat="server" CssClass="h4 text-center" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label6" runat="server" CssClass="h4 text-left" Text="Codigo:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="h4 text-center" ReadOnly="true" Width="60px"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:Label ID="Label7" runat="server" CssClass="h4 text-left" Text="Vendedor:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="txtVendedor" runat="server" CssClass="h4 text-center" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <%--esto puede ser solo temporal, se puede hacer con una datagrid--%>
    <div class="row Centrar-Medio">
        <asp:Panel ID="pnlDetalleFactura" runat="server">
            <asp:Table ID="tblDetalle" runat="server" BorderStyle="Solid" BorderColor="#808080">
                <asp:TableHeaderRow runat="server" CssClass="h1 text-center" ForeColor="#000066">
                    <asp:TableCell runat="server" Text="Detalle de Factura" ColumnSpan="6"></asp:TableCell>
                </asp:TableHeaderRow>
                <asp:TableRow runat="server" CssClass="h4 text-center" ForeColor="#000066" BorderStyle="Solid">
                    <asp:TableCell runat="server" Text="Id Producto" Width="100px" BorderStyle="Solid"></asp:TableCell>
                    <asp:TableCell runat="server" Text="Nombre" Width="100px" BorderStyle="Solid"></asp:TableCell>
                    <asp:TableCell runat="server" Text="Cantidad" Width="100px" BorderStyle="Solid"></asp:TableCell>
                    <asp:TableCell runat="server" Text="Precio" Width="100px" BorderStyle="Solid"></asp:TableCell>
                    <asp:TableCell runat="server" Text="Iva" Width="100px" BorderStyle="Solid"></asp:TableCell>
                    <asp:TableCell runat="server" Text="Subtotal" Width="100px" BorderStyle="Solid"></asp:TableCell>
                </asp:TableRow>
                <asp:TableFooterRow runat="server">
                    <asp:TableCell runat="server" Text="Total" HorizontalAlign="Right" ColumnSpan="5"></asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Center">
                        <asp:Label ID="lblTotal" runat="server" CssClass="h4" ForeColor="#000066"></asp:Label>
                    </asp:TableCell> 
                </asp:TableFooterRow>
            </asp:Table>
        </asp:Panel>
    </div>
</asp:Content>
