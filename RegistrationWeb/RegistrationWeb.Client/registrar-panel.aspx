<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrar-panel.aspx.cs" Inherits="RegistrationWeb.Client.registrar_panel" MasterPageFile="~/Site.master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainSection" runat="server" >

<div style="text-align:left; margin-left:20px;">
    <h1>Registrar Panel</h1>
    <form runat="server">
        
        <h2>Courses</h2>
        <h4>Add Course</h4>
        <p>Course Name: <asp:TextBox runat="server" ID="CourseName"></asp:TextBox>
        Department ID: <asp:TextBox runat="server" ID="DepartmentID"></asp:TextBox>
        Credit Hours: <asp:TextBox runat="server" ID="CreditHours"></asp:TextBox></p>
        <asp:Button runat="server" ID="AddCourse" OnClick ="AddCourse_Click" Text="Add Course"/>
        <br />
        <asp:label runat="server" ID="courseAddMsg"></asp:label>
        <br />


        <h4>Remove Course</h4>
        <p>Course Id: <asp:TextBox runat="server" ID="CourseID"></asp:TextBox></p>
        <asp:Button runat="server" ID="RemoveCourse" OnClick ="RemoveCourse_Click" Text="Remove Course"/>
        <br />
        <asp:label runat="server" ID="courseRemoveMsg"></asp:label>
        <br />
        <div style="margin-bottom:28px;"></div>

        <h2>Course Sessions</h2>
        <h4>View Enrollment For A Session</h4>
        <p>Session ID: <asp:TextBox runat="server" ID="SessionForEnrollment"></asp:TextBox></p>
        <asp:Button runat="server" ID="GetEnrollment" OnClick ="GetEnrollment_Click" Text="Get Class Enrollment"/>
        <br />
        <asp:label runat="server" ID="enrollmentMsg"></asp:label>
        <br />
        <asp:DropDownList ID="sessionEnrollmentDrop" runat="server"></asp:DropDownList>
        <div style="margin-bottom:28px;"></div>


        <h2>Students</h2>
        <h4>Add A Student</h4>
        <p>Student Name: <asp:TextBox runat="server" ID="StudentName"></asp:TextBox>
           Major ID: <asp:TextBox runat="server" ID="MajorID"></asp:TextBox></p>
        <asp:Button runat="server" ID="AddStudent" OnClick ="AddStudent_Click" Text="Add Student"/>
        <br />
        <asp:label runat="server" ID="AddStMsg"></asp:label>
        <br />

        <h4>Remove A Student</h4>
        <p>Student ID: <asp:TextBox runat="server" ID="StudentID"></asp:TextBox></p>
        <asp:Button runat="server" ID="RemoveStudent" OnClick ="RemoveStudent_Click" Text="Remove Student"/>
        <br />
        <asp:label runat="server" ID="RemoveStMsg"></asp:label>
        <br />

        <h4>List Student Schedule</h4>
        <p>Student ID: <asp:TextBox runat="server" ID="StudentIDSch"></asp:TextBox></p>
        <asp:Button runat="server" ID="GetSchedule" OnClick ="GetSchedule_Click" Text="Get Student Schedule"/>
        <br />
        <asp:label runat="server" ID="SchMsg"></asp:label>
        <br />
        <asp:DropDownList ID="studentScheduleDrop" runat="server"></asp:DropDownList>

    </form>
</div>

</asp:Content>
