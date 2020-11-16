<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ASP.net_SQL.Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID ="hfContactID" runat ="server" />

            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label" runat ="server" Text ="Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TXTName" runat ="server"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="Label1" runat ="server" Text ="Mobile"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxTMobile" runat ="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label2" runat ="server" Text ="Address"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TxtAddress" runat ="server" Text="MultiLine"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                          <asp:Button ID="BTNSAVE" runat="server" Text="Save" />
                          <asp:Button ID="BTNDELETE" runat="server" Text="Delete" />
                          <asp:Button ID="BTNCLEAR" runat="server" Text="Clear" OnClick="BTNCLEAR_Click" />
                    </td>
                </tr>

                <tr>
                    <td>
                    </td>
                    <td colspan="2">

                    </td>
                </tr>

                <tr>
                    <td>
                           <asp:Label ID="lblSucssesMassage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                    <td colspan="2">
                           <asp:Label ID="lblErrorMassage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>

            <br />

            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LNKView" runat="server" CommandArgument ='<%# Eval("ContactI") %>'>View</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
                </Columns>
            </asp:GridView>


        </div>
    </form>
</body>
</html>
