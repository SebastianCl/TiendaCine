<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCrearFuncion.aspx.cs" Inherits="prjCinema1.frmFuncionPelicula" %>
<%@ MasterType VirtualPath="~/frmPrincipal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Agregar Función</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <br />
    <div class="row text-center">
        <asp:Label ID="Label1" runat="server" CssClass="h1 Login" Font-Bold="true" Text="Agregar Función" ForeColor="#000066"></asp:Label>
    </div>
    <br />
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label3" runat="server" CssClass="h4 text-center" Text="Fecha:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtFecha" runat="server" CssClass="h4 text-center" TextMode="Date" AutoPostBack="true"></asp:TextBox>
        </div>
    </div>
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label5" runat="server" CssClass="h4 text-left" Text="Pelicula" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtPelicula" runat="server" CssClass="h4 text-center"></asp:TextBox>
        </div>
    </div>
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label15" runat="server" CssClass="h4 text-center" Text="Sucursal" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="h4 text-center" ForeColor="#000066" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row Centrar-Medio">
        <asp:Button ID="btnAgregar" runat="server" CssClass="btn Login" Text="Agregar" ForeColor="White" BackColor="#bb24bb" OnClick="btnAgregar_Click"/>
    </div>
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
