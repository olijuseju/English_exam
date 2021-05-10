<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebLogic.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
            <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"/>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        </div>
</asp:Content>
