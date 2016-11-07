<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student-registration.aspx.cs" Inherits="RegistrationWeb.Client.student_registration" MasterPageFile="~/Site.master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainSection" runat="server" >

<div style="text-align:center;">
    <h1>Student Registration</h1>
    <form runat="server">
        <h2>Registration Status</h2>
        <asp:Button runat="server" ID="RegStatusClick" OnClick ="RegistrationStatus_Click" Text="View Registration Status"/>
        <br />
        <div style="margin-bottom:28px;"></div>

        <h2>Select Course:</h2>
        <asp:DropDownList ID="courseList" runat="server"></asp:DropDownList>
        <asp:Button runat="server" ID="CourseClick" OnClick ="CourseSelect_Click" Text="Find Classes"/>
        <br />

        <asp:Label runat="server" ID="errorCourses" Visible="false"></asp:Label>
        <br />
        <div style="margin-bottom:16px;"></div>

        <h2>Classes Available:</h2>
        <p>Session ID: <asp:DropDownList ID="classList" runat="server" Visible="false"></asp:DropDownList></p>
        <asp:Table ID="classTable" runat="server" Visible="false"></asp:Table>
        <asp:Button runat="server" ID="ClassClick1" OnClick ="ClassRegister_Click" Text="Register" Visible="false"/>
        <asp:Button runat="server" ID="ClassClick2" OnClick ="ClassBookmark_Click" Text="Bookmark" Visible="false"/>
        <br />

        <asp:Label runat="server" ID="Status" Visible="false"></asp:Label>
    </form>
</div>

</asp:Content>
