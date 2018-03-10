<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="prjCinema1.frmCrearCliente"%>
<%@ MasterType VirtualPath="~/frmPrincipal.Master" %>
<%--Esto es para indicar que se usara un componente de la Master Page--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Crear Cliente</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row text-center">
        <asp:Label ID="Label1" runat="server" CssClass="h1 Login" Font-Bold="true" Text="Crear Cliente" ForeColor="#000066"></asp:Label>
    </div>
    <br />
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label2" runat="server" CssClass="h4 text-left" Text="Documento:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtDocumento" runat="server" CssClass="h4 text-center"></asp:TextBox>
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
            <asp:Label ID="Label5" runat="server" CssClass="h4 text-left" Text="E-mail:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="h4 text-center"></asp:TextBox>
        </div>
    </div>    
    <br />
    <div class="row Centrar-Medio">   
        <div class="col-md-3">
            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn Login" Text="Registrar" ForeColor="White" BackColor="#bb24bb" OnClick="btnRegistrar_Click"/>
        </div>     
        <div class="col-md-3">
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn Login" Text="Buscar" ForeColor="White" BackColor="#bb24bb" OnClick="btnBuscar_Click"/>
        </div> 
        <div class="col-md-3">
            <asp:Button ID="btnLimpiar" runat="server" CssClass="btn Login" Text="Limpiar" ForeColor="White" BackColor="#bb24bb" OnClick="btnLimpiar_Click"/>
        </div>        
        
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
