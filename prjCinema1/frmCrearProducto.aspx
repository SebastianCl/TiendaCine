<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCrearProducto.aspx.cs" Inherits="prjCinema1.frmCrearProdcutoaspx" %>
<%@ MasterType VirtualPath="~/frmPrincipal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Crear Producto</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row text-center">
        <asp:Label ID="Label1" runat="server" CssClass="h1 Login" Font-Bold="true" Text="Crear Producto" ForeColor="#000066"></asp:Label>
    </div>
    <br />
    <br />
    
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label2" runat="server" CssClass="h4 text-left" Text="Código:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtCodigoProducto" runat="server" CssClass="h4 text-center"></asp:TextBox>
        </div>
    </div>
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label3" runat="server" CssClass="h4 text-center" Text="Nombre:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtNombre" runat="server" CssClass="h4 text-center"></asp:TextBox>
        </div>
    </div>
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label5" runat="server" CssClass="h4 text-left" Text="Precio:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="h4 text-center"></asp:TextBox>
        </div>
    </div>    
    <br />
    <div class="row Centrar-Medio">
        <asp:Button ID="btnAgregar" runat="server" CssClass="btn Login" Text="Agregar" ForeColor="White" BackColor="#bb24bb" OnClick="btnAgregar_Click" />        
    </div>
    <br />
    <br />
    <div class="row">
        <asp:Panel ID="pnlAlerta" runat="server" Visible="false">
            <div class="col-md-12">
                <div class="alert alert-warning">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="h3 text-center" ForeColor="#8B8787"></asp:Label>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
