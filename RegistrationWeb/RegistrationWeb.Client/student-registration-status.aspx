<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student-registration-status.aspx.cs" Inherits="RegistrationWeb.Client.student_registration_status" MasterPageFile="~/Site.master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainSection" runat="server" >

<div style="text-align:center;">
    <h1>Student Registration Status</h1>
    <form runat="server">
        <h2>Registered Courses:</h2>
        <p>Course Session ID: <asp:DropDownList ID="registeredList" runat="server"></asp:DropDownList></p>
        <asp:Button runat="server" ID="DropCourse" OnClick ="DropCourse_Click" Text="Drop Selected Course"/>
        <br />
        <asp:Label runat="server" ID="RegMsg" Visible="false"></asp:Label>
        <div style="margin-bottom:28px;"></div>

        <h2>Bookmarked Courses:</h2>
        <p>Course Session ID: <asp:DropDownList ID="bookmarkedList" runat="server"></asp:DropDownList></p>
        <asp:Button runat="server" ID="RegisterBookmark" OnClick ="RegisterBookmark_Click" Text="Register Selected Bookmark"/>
        <asp:Button runat="server" ID="RemoveBookmark" OnClick ="RemoveBookmark_Click" Text="Remove Selected Bookmark"/>
        <br />
        <asp:Label runat="server" ID="BkMsg" Visible="false"></asp:Label>

        <asp:Label runat="server" ID="ErrorMessage" Visible="false"></asp:Label>
    </form>
</div>

</asp:Content>

