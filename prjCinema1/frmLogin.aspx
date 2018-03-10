<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="prjCinema1.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="row Centrar-Medio">
        <div class="col-md-3">
            <asp:Label ID="label1" runat="server" CssClass="h4 Login" Text="Usuario:" ForeColor="#0066cc"></asp:Label>
        </div> 
        <div class="col-md-6">
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="h4 Login"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row Centrar-Medio">
        <div class=" col-md-3">
            <asp:Label ID="label2" runat="server" CssClass="h4 Login" Text="Contraseña:" ForeColor="#0066cc"></asp:Label>
        </div>
            
        <div class="col-md-6">
            <asp:TextBox ID="txtContrasena" runat="server" CssClass="h4 Login" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row Centrar-Medio">
        <asp:Button ID="btnEntrar" runat="server" CssClass="btn btn-success Login" Text="Entrar"  OnClick="btnEntrar_Click"/>             
    </div>
    <br />
    <br />
    <div class="row">
        <asp:Panel ID="pnlAlerta" runat="server">
            <div class="col-md-12">
                <div class="alert alert-warning">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="h3 text-center" ForeColor="#8B8787"></asp:Label>
                </div>
            </div>
        </asp:Panel>
    </div>
    
</asp:Content>
