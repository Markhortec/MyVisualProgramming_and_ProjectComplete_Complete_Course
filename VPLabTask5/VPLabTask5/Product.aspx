<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="VPLabTask5.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <table>
           <tr>
               <td colspan="3">
                   <h1>
                       Product Management System
                   </h1>
               </td>
           </tr>
           <tr>
               <td colspan="3">
                   <asp:Label ID="labresult" runat="server" Text=""></asp:Label>
               </td>
           </tr>
           <tr>
               <td>
                   <asp:Label ID="pid" runat="server" Text="ID:"></asp:Label>
               </td>
               <td>
                   <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
               </td>
               <td>
                   <asp:Button ID="btnsearch" Text="Search" runat="server" OnClick="btnsearch_Click" />
               </td>
           </tr>
            <tr>
               <td>
                   <asp:Label ID="pname" runat="server" Text="Name:"></asp:Label>
               </td>
               <td>
                   <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
               </td>
                <td>
                    <asp:Button ID="btninsert" Text="Save " runat="server" OnClick="btninsert_Click" />
               </td>
           </tr>
           <tr>
               <td>
                   <asp:Label ID="pcategory" runat="server" Text="Category:"></asp:Label>
               </td>
               <td>
                  <asp:DropDownList ID="ddlcategory" runat="server">
                      <asp:ListItem Text="-Select the Category-"  Selected="True" runat="server"></asp:ListItem>
                      <asp:ListItem Text="Garments" runat="server"></asp:ListItem>
                      <asp:ListItem Text="Electronics" runst="server"></asp:ListItem>
                      <asp:ListItem Text="Grocery" runat="server"></asp:ListItem>
                  </asp:DropDownList>
               </td>
               <td>
                   <asp:Button ID="btnupdate" Text="Update" runat="server" OnClick="btnupdate_Click" />
               </td>
           </tr>
           <tr>
               <td>
                   <asp:Label ID="pprice" runat="server" Text="Price:"></asp:Label>
               </td>
               <td>
                   <asp:TextBox ID="txtprice" runat="server"></asp:TextBox>
               </td>
               <td>
                   <asp:Button ID="btndelete" Text="Delete" runat="server" OnClick="btndelete_Click" />
               </td>
           </tr>
           <tr>
               <td>
                   <asp:Label ID="pquantity" runat="server" Text="Quantity:"></asp:Label>
               </td>
               <td>
                   <asp:TextBox ID="txtquantity" runat="server"></asp:TextBox>
               </td>
               <td>
                   <asp:Button ID="btnclear" runat="server" Text="Clear" OnClick="btnclear_Click" />
               </td>
           </tr>
           <tr>
               <td colspan="3">
                   <asp:GridView  ID="pgrid" runat="server"></asp:GridView>
               </td>
           </tr>
       </table>
    </form>
</body>
</html>
