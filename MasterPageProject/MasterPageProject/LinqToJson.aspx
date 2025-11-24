<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="LinqToJson.aspx.cs" Inherits="MasterPageProject.LinqToJson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    LINQ TO JSON
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">LINQ To JSON</h1>
    <form runat="server" id="linqformwithjson" class="w-75 mx-auto">
        <div class="mb-3">
            <asp:label runat="server" ID="LabName" Text="Please Enter Your Name" CssClass="form-label"></asp:label>
            <asp:TextBox runat="server" ID="TxtName" CssClass="form-control"></asp:TextBox>
        </div>   
        <div class="mb-3">
            <asp:label runat="server" ID="LabEmail" Text="Please Enter Your Email" CssClass="form-label"></asp:label>
            <asp:TextBox runat="server" ID="TxtEmail" CssClass="form-control"></asp:TextBox>
        </div>   
        <div class="mb-3">
            <asp:label runat="server" ID="LabCNIC" Text="Please Enter Your CNIC" CssClass="form-label"></asp:label>
            <asp:TextBox runat="server" ID="TxtCNIC" CssClass="form-control"></asp:TextBox>
        </div>     
        <div class="mb-3">
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary mx-auto " OnClick="btnSave_Click" />
            <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btn btn-primary mx-auto " onClick="btnUpdate_Click" />
            <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary mx-auto " onClick="btnSearch_Click" />
            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-primary mx-auto " onClick="btnDelete_Click" />
        </div>
        <div class="mb-3">
            <asp:GridView ID="GridUser" runat="server"></asp:GridView>
        </div>
    </form> 
</asp:Content>
