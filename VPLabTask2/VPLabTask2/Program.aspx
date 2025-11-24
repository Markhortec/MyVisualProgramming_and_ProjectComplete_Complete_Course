<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program.aspx.cs" Inherits="VPLabTask2.Program" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    <h1>
                        Program Info
                    </h1>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="resultlab" Text="" runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="pname" Text="Name" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="pdepartment" Text="Department" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdept" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="pbuilding" Text="Building" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbuild" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="addbtn" runat="server" Text="ADD" OnClick="addbtn_Click" />
                </td>
                <td>
                    <asp:Button ID="updatebtn" runat="server" Text="Update" OnClick="updatebtn_Click" />
                </td>
            </tr>

        </table>
    </form>
</body>
</html>
