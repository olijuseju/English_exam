<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebLogic.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
            <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"/>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        </div>
    </form>
</body>
</html>
