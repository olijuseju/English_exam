<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceptionistPage.aspx.cs" Inherits="WebLogic.ReceptionistPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="NameClient" runat="server" Text="name" ></asp:TextBox>
            <asp:TextBox ID="LastnameClient" runat="server" Text="lastname"></asp:TextBox>
            <asp:TextBox ID="CardNumberClient" runat="server" Text="cardNumber" TextMode="Number" ></asp:TextBox>
            <asp:TextBox ID="PhoneClient" runat="server" Text="phone" TextMode="Phone"></asp:TextBox>
            <asp:TextBox ID="EmailClient" runat="server" Text="email" TextMode="Email"></asp:TextBox>
            <asp:TextBox ID="PasswordClient" runat="server" Text="password" TextMode="Password"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Create client" OnClick="Button1_Click" />


            <asp:ListBox ID="ListBox1" runat="server" Height="129px" Width="172px"></asp:ListBox>
        </div>
    </form>
</body>
</html>
