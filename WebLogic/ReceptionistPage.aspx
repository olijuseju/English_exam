<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceptionistPage.aspx.cs" Inherits="WebLogic.ReceptionistPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous">
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div>
                <asp:TextBox ID="NameClient" runat="server" Text="name" ></asp:TextBox>
                <asp:TextBox ID="LastnameClient" runat="server" Text="lastname"></asp:TextBox>
                <asp:TextBox ID="CardNumberClient" runat="server" Text="cardNumber" TextMode="Number" ></asp:TextBox>
                <asp:TextBox ID="PhoneClient" runat="server" Text="phone" TextMode="Phone"></asp:TextBox>
                <asp:TextBox ID="EmailClient" runat="server"  TextMode="Email"></asp:TextBox>
                <asp:TextBox ID="PasswordClient" runat="server" Text="password" TextMode="Password"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Create client" OnClick="Button1_Click" />

                <asp:Panel ID="TablaClientOfReceptionist" runat="server"></asp:Panel>
                
            </div>
            <div class="col-12">
                <asp:TextBox ID="CliendIdReservation" runat="server"></asp:TextBox>
                <asp:TextBox ID="ArrivalDateReservation" runat="server"></asp:TextBox>
                <asp:TextBox ID="ExitDateReservation" runat="server"></asp:TextBox>
                <asp:TextBox ID="PeopleQuantityReservation" runat="server"></asp:TextBox>
                <asp:TextBox ID="RoomIdReservation" runat="server"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Create reservation" OnClick="Button2_Click" />

                

                <asp:Panel ID="TablaReservations" runat="server"></asp:Panel>
            </div>
        </div>
        
    </form>
</body>
</html>
