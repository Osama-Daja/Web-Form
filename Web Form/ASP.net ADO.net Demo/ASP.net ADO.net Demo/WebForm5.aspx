<%@ Page Title ="Form5" Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="ASP.net_ADO.net_Demo.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table>
                <tr>
                    <th><asp:Label ID="Label1" runat="server" Text="Employee Name"></asp:Label></th>
                    <th><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></th>
                </tr>

                <tr>
                    <th><asp:Label ID="Label2" runat="server" Text="Gender"></asp:Label></th>
                    <th>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </th>
                </tr>

                <tr>         
                    <th><asp:Label ID="Label3" runat="server" Text="Salary"></asp:Label></th>
                    <th><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></th>
                </tr>
            </table>
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
