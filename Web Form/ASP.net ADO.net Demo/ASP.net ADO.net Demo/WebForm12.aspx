<%@ Page Title ="Form12" Language="C#" AutoEventWireup="true" CodeBehind="WebForm12.aspx.cs" Inherits="ASP.net_ADO.net_Demo.WebForm12" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Get Data From Cache" OnClick="Button1_Click" />
            <asp:Button ID="Button3" runat="server" Text="UnDone Change" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="Accept Change" OnClick="Button4_Click" />
            <hr />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="TotalMarks" HeaderText="TotalMarks" SortExpression="TotalMarks" />
                </Columns>
            </asp:GridView>
            <hr />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <hr />
            <asp:Button ID="Button2" runat="server" Text="Set Data To DataBase" OnClick="Button2_Click" />
            <hr />
        </div>
    </form>
</body>
</html>
