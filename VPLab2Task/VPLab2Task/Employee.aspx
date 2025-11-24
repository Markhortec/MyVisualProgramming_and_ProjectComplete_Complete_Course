<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="VPLab2Task.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table id="empTabel" runat="server">
            <tr>
                <td colspan="2">
                    <h1>Employee </h1>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="resultlab" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
        <td>
            <asp:Label ID="empid" runat="server" Text="Employee ID"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
        </td>   
    </tr>
    <tr>
        <td>
            <asp:Label ID="empname" runat="server" Text="Employee Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="empage" runat="server" Text="Employee Age"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtage" runat="server"></asp:TextBox>
        </td>
    </tr>
            <tr>
    <td>
        <asp:Label ID="empsalary" runat="server" Text="Employee Salary"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtsalary" runat="server"></asp:TextBox>
    </td>
</tr>
    <tr>
        <td>
            <asp:Label ID="empcnic" runat="server" Text="Employee CNIC"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtcnic" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="empcontact" runat="server" Text="Employee Contact"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtcontact" runat="server"></asp:TextBox>
        </td>
    </tr>
            <tr>
                <td>
                <asp:Label ID="deptId" runat="server" Text="Deparment ID:"></asp:Label>                    
                </td>
                <td>
                    <asp:DropDownList ID="ddldept" runat="server" ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="savebtn" runat="server" Text="Save" OnClick="savebtn_Click" />
                </td>
                <td>
                    <asp:Button ID="updatebtn" runat="server" Text="Update" OnClick="updatebtn_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="deletebtn" runat="server" Text="Delete" OnClick="deletebtn_Click" />
                </td>
                <td>
                    <asp:Button ID="searchbtn" runat="server" Text="Search" OnClick="searchbtn_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="clearbtn" runat="server" Text="Clear" OnClick="clearbtn_Click" />
                </td>
            </tr>

        </table>
    </form>
</body>
</html>
