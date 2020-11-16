<%@ Page Title="Form11" Language="C#" AutoEventWireup="true" CodeBehind="WebForm11.aspx.cs" Inherits="ASP.net_ADO.net_Demo.WebForm11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    <asp:Label ID="Label6" runat="server" Text="StudentID"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="Load" OnClick="Button3_Click" />
            <hr />
                    <asp:Label ID="Label7" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <hr />
            <asp:Label ID="Label8" runat="server" Text="Gender"></asp:Label>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
            <hr />
                    <asp:Label ID="Label9" runat="server" Text="Total Marks"></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <hr />
                    <asp:Button ID="Button4" runat="server" Text="Update" OnClick="Button4_Click" />
            <hr />
                    <asp:Label ID="Label10" runat="server" Text="LBLStatus"></asp:Label>
            <hr />
            <hr />
                    <asp:Label ID="Label1" runat="server" Text="Command Row"></asp:Label>
            <hr />
        </div>
    </form>
</body>
</html>
