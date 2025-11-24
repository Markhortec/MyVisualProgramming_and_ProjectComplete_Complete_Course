<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="VPLab2Task.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <tabel id="detailtabel" runat="server">
            <tr>
                <td>
                    <asp:Button ID="Empbtn" runat="server" Text="Employee" OnClick="Empbtn_Click" />
                </td>
                <td>
                    <asp:Button ID="Deptbtn" runat="server" Text="Department" OnClick="Deptbtn_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="detail" runat="server"></asp:GridView> 
                </td>
            </tr>
        </tabel>
    </form>
</body>
</html>
