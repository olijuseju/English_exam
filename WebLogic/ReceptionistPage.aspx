﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceptionistPage.aspx.cs" Inherits="WebLogic.ReceptionistPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Text="name"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" Text="lastname"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" Text="cardNumber"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" Text="phone"></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server" Text="email"></asp:TextBox>
            <asp:TextBox ID="TextBox6" runat="server" Text="password"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Create client" OnClick="Button1_Click" />


            <asp:ListBox ID="ListBox1" runat="server" Height="129px" Width="172px"></asp:ListBox>
        </div>
    </form>
</body>
</html>