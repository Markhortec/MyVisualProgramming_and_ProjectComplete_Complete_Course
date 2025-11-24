<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Doctor.aspx.cs" Inherits="MasterPageProject.Doctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">LINQ To JSON(Doctor)</h1>
<form runat="server" id="DoctorForm" class="w-75 mx-auto">
  <div class="mb-3">
    <asp:Label runat="server" ID="LabId" Text="ID" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtId"   CssClass="form-control"></asp:TextBox>
  </div>
  <div class="mb-3">
    <asp:Label runat="server" ID="LabName" Text="Name" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtName"  CssClass="form-control"></asp:TextBox>
  </div>
  <div class="mb-3">
    <asp:Label runat="server" ID="LabSpecialty" Text="Specialty" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtSpecialty"  CssClass="form-control"></asp:TextBox>
  </div>
  <div class="mb-3">
    <asp:Label runat="server" ID="LabAge" Text="Age" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtAge"  CssClass="form-control"></asp:TextBox>
  </div>
  <div class="mb-3">
    <asp:Label runat="server" ID="LabEmail" Text="Email" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtEmail"  CssClass="form-control"></asp:TextBox>
  </div>
  <div class="mb-3">
    <asp:Label runat="server" ID="LabPhone" Text="Phone Number" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtPhone" CssClass="form-control"></asp:TextBox>
  </div>
  <div class="mb-3">
    <asp:Label runat="server" ID="LabExperience" Text="Experience" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtExperience"  CssClass="form-control"></asp:TextBox>
  </div>
  <div class="mb-3">
    <asp:Label runat="server" ID="LabHospital" Text="Hospital" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtHospital"  CssClass="form-control"></asp:TextBox>
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
