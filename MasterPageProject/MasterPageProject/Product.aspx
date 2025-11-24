<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="MasterPageProject.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">LINQ To JSON(Product)</h1>
  <form runat="server" id="ProductForm" class="w-75 mx-auto">
  <h2>Product</h2>

  <div class="mb-3">
    <asp:Label runat="server" ID="LabProductId" Text="Product ID" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtProductId" CssClass="form-control"></asp:TextBox>
  </div>

  <div class="mb-3">
    <asp:Label runat="server" ID="LabProductName" Text="Product Name" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtProductName" CssClass="form-control"></asp:TextBox>
  </div>

  <div class="mb-3">
    <asp:Label runat="server" ID="LabProductDescription" Text="Description" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtProductDescription" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
  </div>

  <div class="mb-3">
    <asp:Label runat="server" ID="LabProductPrice" Text="Price" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtProductPrice" CssClass="form-control"></asp:TextBox>
  </div>

  <div class="mb-3">
    <asp:Label ID="LabProductQuantity" runat="server" Text="Quantity:" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtQuantity" CssClass="form-control"></asp:TextBox>
  </div>

  <div class="mb-3">
    <asp:Label runat="server" ID="LabProductCategory" Text="Category" CssClass="form-label"></asp:Label>
      <asp:TextBox runat="server" ID="TxtProductCategory" CssClass="form-control" ></asp:TextBox>
  </div>

   <div class="mb-3">
    <asp:Label runat="server" ID="LabProductBrand" Text="Brand" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtProductBrand" CssClass="form-control"></asp:TextBox>
  </div>

  <div class="mb-3">
    <asp:Label runat="server" ID="LabProductDiscount" Text="Discount (%)" CssClass="form-label"></asp:Label>
    <asp:TextBox runat="server" ID="TxtProductDiscount" CssClass="form-control"></asp:TextBox>
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
