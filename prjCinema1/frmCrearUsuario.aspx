<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmCrearUsuario.aspx.cs" Inherits="prjCinema1.frmCrearUsuario" %>
<%@ MasterType VirtualPath="~/frmPrincipal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Crear Usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row text-center">
        <asp:Label ID="Label1" runat="server" CssClass="h1 Login" Font-Bold="true" Text="Crear Usuario" ForeColor="#000066"></asp:Label>
    </div>
    <br />
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label2" runat="server" CssClass="h4 text-left" Text="Nombre de Usuario:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtNomUsuario" runat="server" CssClass="h4 text-center"></asp:TextBox>
        </div>
    </div>

    <br />
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label3" runat="server" CssClass="h4 text-left" Text="Contraseña:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtContrasena" runat="server" CssClass="h4 text-center"></asp:TextBox>
        </div>
    </div>

    <br />
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label4" runat="server" CssClass="h4 text-left" Text="Nombre:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtNombre" runat="server" CssClass="h4 text-center"></asp:TextBox>
        </div>
    </div>

    <br />
    <div class="row Centrar-Medio">
        <div class="col-md-2">
            <asp:Label ID="Label5" runat="server" CssClass="h4 text-left" Text="Cedula:" ForeColor="#000066"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtCedula" runat="server" CssClass="h4 text-center"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row Centrar-Medio">
        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn Login" Text="Registrar" ForeColor="White" BackColor="#bb24bb" OnClick="btnRegistrar_Click"/>
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
