<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="VPLabTask2.Student" %>

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
                       <h1> Student Info</h1>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="relab" Text="" runat="server"></asp:Label>
                    </td>
                </tr>
            <tr>
                <td>
                    <asp:Label ID ="Lname" runat="server" Text="Name" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID ="Lrollno" runat="server" Text="Roll No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRollNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID ="Lgender" runat="server" Text="Gender"></asp:Label>
                </td>  
                <td>
                    <asp:RadioButton ID="r1" Text="Male" runat="server" GroupName="Gender"/>
                    <asp:RadioButton ID="r2" Text="Female" runat="server" GroupName="Gender"  />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID ="Lprogram" runat="server" Text="Program"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlprogram" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlprogram_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID ="Lsemester" runat="server" Text="Semester"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlsemester" runat="server">
                        <asp:ListItem Text="select semester : " Selected="True" ></asp:ListItem>
                        <asp:ListItem Text="1" ></asp:ListItem>
                        <asp:ListItem Text="2" ></asp:ListItem>
                        <asp:ListItem Text="3" ></asp:ListItem>
                        <asp:ListItem Text="4" ></asp:ListItem>
                        <asp:ListItem Text="5" ></asp:ListItem>
                        <asp:ListItem Text="6" ></asp:ListItem>
                        <asp:ListItem Text="7" ></asp:ListItem>
                        <asp:ListItem Text="8" ></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID ="Ldepartment" runat="server" Text="Department"></asp:Label>
                </td>  
                <td>
                    <asp:TextBox ID="txtdept" runat="server"  Enabled="false"></asp:TextBox>
                </td>
            </tr>
          <tr>
                <td>
                    <asp:Label ID ="Lbuilding" runat="server" Text="Building"></asp:Label>
                </td>  
                <td>
                     <asp:TextBox ID="txtbuild" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
                <tr>
                <td>
                    <asp:Label ID ="Lcgpa" runat="server" Text="CGPA"></asp:Label>
                </td>  
                <td>
                     <asp:TextBox ID="txtcgpa" runat="server"></asp:TextBox>
                </td>
            </tr>
                <tr>
                    <td>
                        <asp:Button ID="addbtn" runat="server" Text="Add" OnClick="addbtn_Click" />
                    </td>
                    <td>
                        <asp:Button ID="updatbtn" runat="server" Text="Update" OnClick="updatbtn_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="deletebtn" runat="server" Text="Delete" OnClick="deletebtn_Click" />
                    </td>
                    <td>
                        <asp:Button ID="selectbtn" runat="server" Text="Search" OnClick="selectbtn_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID ="gridstu" runat="server"></asp:GridView>
                    </td>
                </tr>
        </table>
    </form>
</body>
</html>
