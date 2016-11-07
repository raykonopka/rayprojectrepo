<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RegistrationWeb.Client._default" MasterPageFile="~/Site.master"%>


<asp:Content ID="MainContent" ContentPlaceHolderID="MainSection" runat="server">

    <div style="text-align:center;">
        <h2>Login</h2>
        <form runat="server">
            <asp:Button runat="server" ID="StudentLogin" OnClick ="StudentLogin_Click" Text="Student Login"/>
            <div style="margin-bottom:20px;"></div>
            <asp:Button runat="server" ID="RegistrarLogin" OnClick ="RegistrarLogin_Click" Text="Registrar Login"/>
        </form>
    </div>

</asp:Content>


