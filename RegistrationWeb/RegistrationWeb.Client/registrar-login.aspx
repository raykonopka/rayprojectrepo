<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrar-login.aspx.cs" Inherits="RegistrationWeb.Client.registrar_login" MasterPageFile="~/Site.master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainSection" runat="server" >

<div style="text-align:center;">
    <h2>Registrar Login</h2>
    <form runat="server">
        <asp:Label runat="server">Username:</asp:Label>
        <asp:TextBox runat="server" ID="Username"></asp:TextBox>
        <br />

        <asp:Label runat="server">Password:</asp:Label>
        <asp:TextBox runat="server" ID="Password" TextMode ="Password"></asp:TextBox>
        <br />

        <asp:Button runat="server" ID="LoginClick" OnClick ="Login_Click" Text="Submit"/>
        <br />

        <asp:Label ID="Message" runat="server"></asp:Label>
    </form>
</div>

</asp:Content>

