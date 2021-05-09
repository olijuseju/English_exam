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
                <asp:Panel ID="TablaClientOfReceptionist" runat="server"></asp:Panel>
                <asp:Button ID="Button3" runat="server" Text="Export Client" OnClick="Button3_Click" />
            </div>
            <div class="col-12">
                <asp:TextBox ID="CliendIdReservation" runat="server"></asp:TextBox>
                <asp:TextBox ID="ArrivalDateReservation" runat="server"></asp:TextBox>
                <asp:TextBox ID="ExitDateReservation" runat="server"></asp:TextBox>
                <asp:TextBox ID="PeopleQuantityReservation" runat="server"></asp:TextBox>
                <asp:TextBox ID="RoomIdReservation" runat="server"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Create reservation" OnClick="Button2_Click" />

                

                <asp:Panel ID="TablaReservations" runat="server"></asp:Panel>

                <asp:TextBox ID="TextBox1" runat="server" Height="215px" Width="328px" TextMode="MultiLine"></asp:TextBox>
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Export Reservation" />
                    <asp:Button ID="Button5" runat="server" Text="Export Rooms" OnClick="Button5_Click" Visible="False" />
                    <asp:Button ID="Button6" runat="server" Text="Export Receptionists" OnClick="Button6_Click" Visible="False" />
            </div>
            <div class="row   mt-5  ">
                <div class="col mt-4  d-flex  flex-column">
                    <asp:Button ID="RemoveClientButton" CssClass="btn btn-danger  btn-lg mb-2 " runat="server" Text="Select a client of the list to remove"  Enabled="False" OnClick="RemoveClientButton_Click" />
                    <asp:ListBox ID="ListsOfClientOfRecepcionist" CssClass="  h-100 " runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListsOfClientOfRecepcionist_SelectedIndexChanged"></asp:ListBox>
                </div>
                 <div class="col  mt-4  d-flex  flex-column">
                     <div class="row">
                         <div class="mb-3 col">
                            <asp:label  CssClass="form-label" runat="server" Text="Name"></asp:label>
                            <asp:TextBox ID="NameClient" type="text" CssClass="form-control"  runat="server"></asp:TextBox>
                        
                         </div>
                            <div class="mb-3 col">
                                <asp:label  CssClass="form-label" runat="server" Text="Lastname"></asp:label>
                                <asp:TextBox ID="LastnameClient" type="text" CssClass="form-control"  runat="server"></asp:TextBox>
                        </div>
                    </div>
                     <div class="row">
                         <div class="mb-3 col">
                            <asp:label  CssClass="form-label" runat="server" Text="CardName"></asp:label>
                            <asp:TextBox ID="CardNumberClient" type="text" CssClass="form-control" TextMode="Number"  runat="server"></asp:TextBox>
                        
                         </div>
                         <div class="mb-3 col">
                                <asp:label  CssClass="form-label" runat="server" Text="Phone"></asp:label>
                                <asp:TextBox ID="PhoneClient" type="text" CssClass="form-control" TextMode="Phone"  runat="server"></asp:TextBox>
                        </div>
                    </div>
                     <div class="row">
                         <div class="mb-3 col">
                            <asp:label  CssClass="form-label" runat="server" Text="Email"></asp:label>
                            <asp:TextBox ID="EmailClient" type="text" CssClass="form-control" TextMode="Email"  runat="server"></asp:TextBox>
                        
                         </div>
                         <div class="mb-3 col">
                                <asp:label  CssClass="form-label" runat="server" Text="Password"></asp:label>
                                <asp:TextBox ID="PasswordClient" TextMode="Password" CssClass="form-control"  runat="server"></asp:TextBox>
                         </div>
                      </div>
                      <asp:Button ID="Button7"  CssClass="btn btn-primary btn-lg " runat="server" Text="Create client" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
        
    </form>
</body>
</html>
