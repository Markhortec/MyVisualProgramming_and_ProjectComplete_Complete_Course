<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="MasterPageProject.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">LINQ To JSON(Student)</h1>
<form runat="server" id="StudentForm" class="w-75 mx-auto">
    <div class="mb-3">
        <asp:Label runat="server" ID="LabRollNo" Text="Please Enter Your Roll No" CssClass="form-label"></asp:Label>
        <asp:TextBox runat="server" ID="TxtRollNo" CssClass="form-control"></asp:TextBox>
    </div>   
    <div class="mb-3">
        <asp:Label runat="server" ID="LabName" Text="Please Enter Your Name" CssClass="form-label"></asp:Label>
        <asp:TextBox runat="server" ID="TxtName" CssClass="form-control"></asp:TextBox>
    </div>   
        <div class="mb-3">
        <asp:Label runat="server" ID="LabAge" Text="Please Enter Your Age" CssClass="form-label"></asp:Label>
        <asp:TextBox runat="server" ID="TxtAge" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label runat="server" ID="LabProgram" Text="Please Enter Your Program" CssClass="form-label"></asp:Label>
        <asp:TextBox runat="server" ID="TxtProgram" CssClass="form-control"></asp:TextBox>
    </div> 
    <div class="mb-3">
        <asp:Label runat="server" ID="LabSemester" Text="Please Enter Your Semester" CssClass="form-label"></asp:Label>
        <asp:TextBox runat="server" ID="TxtSemester" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label runat="server" ID="LabDepartment" Text="Please Enter Your Department" CssClass="form-label"></asp:Label>
        <asp:TextBox runat="server" ID="TxtDepartment" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <asp:Label runat="server" ID="LabEmail" Text="Please Enter Your Email" CssClass="form-label"></asp:Label>
        <asp:TextBox runat="server" ID="TxtEmail" CssClass="form-control"></asp:TextBox>
    </div> 
    <div class="mb-3">
        <asp:Label runat="server" ID="LabCGPA" Text="Please Enter Your CGPA" CssClass="form-label"></asp:Label>
        <asp:TextBox runat="server" ID="TxtCGPA" CssClass="form-control"></asp:TextBox>
    </div>    
    <div class="mb-3">
        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary mx-auto" OnClick="btnSave_Click" />
        <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btn btn-primary mx-auto" OnClick="btnUpdate_Click" />
        <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary mx-auto" OnClick="btnSearch_Click" />
        <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-primary mx-auto" OnClick="btnDelete_Click" />
    </div>
    <div class="mb-3">
        <asp:GridView ID="GridUser" runat="server"></asp:GridView>
    </div>
</form>
 
</asp:Content>
