<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="UsingDoubleDropdownAndGrid.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DdlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlCountry_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <asp:DropDownList ID="DdlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlCity_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
