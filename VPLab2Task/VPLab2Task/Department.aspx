<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="VPLab2Task.Department" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table id="deptTable" runat="server">
            <tr>
                <td colspan="2">
                   <h1>Department</h1> 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="resultLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="deptId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtId" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="deptName" runat="server" Text="Name : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="deptStatus" runat="server" Text="Status"></asp:Label>
                </td>
                <td>
                    <asp:RadioButton ID="r1" runat="server" Text="Active" GroupName="Status" />
                    <asp:RadioButton ID="r2" runat="server" Text="Inactive" GroupName="Status" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="addbtn" runat="server" Text="ADD" OnClick="addbtn_Click" />
                </td>
                <td>
                    <asp:Button ID="updatebtn" runat="server" Text="Update" OnClick="updatebtn_Click" />
                </td>
                <td>
                    <asp:Button ID="searchbtn" runat="server" Text="Search" OnClick="searchbtn_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
