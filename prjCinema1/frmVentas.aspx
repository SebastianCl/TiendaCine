<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmVentas.aspx.cs" Inherits="prjCinema1.frmVentas" %>
<%@ MasterType VirtualPath="~/frmPrincipal.Master" %>
<%--Esto es para indicar que se usara un componente de la Master Page--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ventas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <br />
    <div class="row text-center">
        <asp:Label ID="lblTitulo" runat="server" CssClass="h1" Text="Registrar Venta de Productos" ForeColor="#000066"></asp:Label>
    </div>
    <br />
    <div class="row Centrar-Medio">
        <div class="col-md-6">
            <asp:Label ID="label1" runat="server" CssClass="h2 text-left" ForeColor="#000066" Text="Documento"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtDocumento" runat="server" CssClass="h2 text-center"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnContinuar" runat="server" CssClass="btn btn-primary" Text="Continuar" OnClick="btnContinuar_Click" />
        </div>
    </div>
    <div class="row Centrar-Medio">
        <asp:Panel ID="pnlVenta" runat="server" Visible="false">
            <div class="container-fluid">
                <div class="row Centrar-Medio">
                    <div class="col-md-3">
                        <asp:Label ID="Label5" runat="server" CssClass="h4 text-left" Text="Nombre" ForeColor="#000066"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="h4 text-center" ReadOnly="false"></asp:TextBox>
                    </div>
                </div>
                <div class="row Centrar-Medio">
                    <div class="col-md-3">
                        <asp:Label ID="Label2" runat="server" CssClass="h4 text-left" Text="Fecha de la función" ForeColor="#000066"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="h4 text-center" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
                <div class="row Centrar-Medio">
                    <div class="col-md-3">
                        <asp:Label ID="label3" runat="server" CssClass="h4 text-left" ForeColor="#000066" Text="Producto"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlProducto" runat="server" CssClass="h4 text-center" ForeColor="#000066" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row Centrar-Medio">
                    <div class="col-md-3">
                        <asp:Label ID="label4" runat="server" CssClass="h4 text-left" ForeColor="#000066" Text="Cantidad"></asp:Label>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="h4 text-center" Width="150px"></asp:TextBox>
                    </div>                    
                </div>
                <div class="row Centrar-Medio">
                    <div class="col-md-2">
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registar" OnClick="btnRegistrar_Click" />
                    </div>
                </div>
                <br />
                <div class="row Centrar-Medio">
                    <div class="col-md-2">
                        <asp:Button ID="btnRegistarCompra" runat="server" CssClass="btn btn-success Login" Text="Registar Compra" OnClick="btnRegistarCompra_Click"/>
                    </div>
                </div>
            </div>            
        </asp:Panel>
    </div>      
    <asp:GridView ID="gvVenta" runat="server" CssClass="table table-responsive table-condensed table-hover"></asp:GridView>
    
    <div class="row">
        <asp:Panel ID="pnlAlerta" runat="server" Visible="true">
            <div class="col-md-12">
                <div class="alert alert-warning">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="h3 text-center" ForeColor="#8B8787"></asp:Label>
                </div>
            </div>
        </asp:Panel>
    </div>
    
    <div class="col-md-4">
        <asp:Panel ID = "pnlBotones" runat="server" Visible="false">
            <div class="row">
                <div class="col-md-4">
                    <asp:Button ID = "btnCrearCliente" runat="server" CssClass="btn btn-success Login" Text="Registrar Cliente" OnClick="btnSi_Click" />
                </div>
            </div>            
        </asp:Panel>
    </div>
</asp:Content>
