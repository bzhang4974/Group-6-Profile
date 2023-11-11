<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBusiness.master" AutoEventWireup="true" CodeFile="BusinessHome.aspx.cs" Inherits="BusinessHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        *{
            box-sizing: border-box;
        }
        .auto-style6 {
            width: 100%;
            height: 100%;
/*            border:2px solid red;*/

        }
        .auto-style7 {
            height: 280px;
/*            background-color:chartreuse*/
        }
        .auto-style8 {
            height: 38px;
/*            background-color:aquamarine;*/
        }
        .auto-style9 {
            width: 75%;
            height: 90px;
/*            background-color:blueviolet;*/
        }
        .auto-style10 {
            /*height: 215px;
            width: 373px;*/
            background-color:#dddcdc;
            background-repeat: no-repeat; 
            border:28px solid transparent;
            border-image: url("/images/border.png") 30 30 round;
/*            border:28px solid blue;*/
        }
        .auto-style11 {
            width: 20%;
            height: 280px;
        }
        .auto-style12 {
            width: 40%;
/*            background-color:cyan;*/
            padding-left:20px;
            height:  280px;
        }
         .auto-style13 {
             border-left:4px solid #999999;
            height:  280px;
        }
         .lab1{
             width:100%;
             height:80%;
             font-size:25px;
             text-align:center;
             background-color:aqua;
             margin-top:0px;
             margin-left:15px;
             padding-top:15px;
         }
         .lab2{
             width:80%;
             height:80%;
             font-size:25px;
             text-align:center;
             background-color:springgreen;
             margin-top:0px;
             margin-left:25px;
             padding-top:15px;
         }
         .lab3{
             width:100%;
             height:80%;
             font-size:25px;
             text-align:center;
             background-color:crimson;
             margin-top:0px;
             margin-left:15px;
             padding-top:15px;
         }
         .lab4{
             width:80%;
             height:80%;
             font-size:25px;
             text-align:center;
             background-color:coral;
             margin-top:0px;
             margin-left:25px;
             padding-top:15px;
         }
         .textlab{
             padding-bottom:10px;
         }
         .tip{
             width:25%;
             padding-left:90px;
         }
        .auto-style14 {
            width: 25%;
            padding-left: 90px;
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%; height: 625px; background-color: white;padding-left:10px;margin-left:5px;">
        <table class="auto-style6">
            <tr>
                <td class="auto-style9">
                    <table style="border: 3px solid #FF0000; width:100%; height:100px">
                        <tr>
                            <td class="auto-style11">
                                <asp:Image ID="Image1" runat="server"   ImageUrl="~/images/Profile.jpg" Width="100%" />
                            </td>
                            <td class="auto-style12">
                                <asp:Label ID="Label2" runat="server" Font-Size="Smaller" Text="shopID:XXXXXXXXX"></asp:Label>
                                <br />
                                <asp:Label ID="Label3" runat="server" Font-Size="Smaller" Text="shop name:Amzon"></asp:Label>
                                <br />
                                <asp:Label ID="Label4" runat="server" Font-Size="Smaller" Text="Last login:2023 Nov 4th"></asp:Label>
                                <br />
                                <asp:Label ID="Label5" runat="server" Font-Size="Smaller" Text="Shipping address:"></asp:Label>
                                <br />
                                <asp:Label ID="Label6" runat="server" Font-Size="Smaller" Text="XXXXXXXXXXXXXXXX"></asp:Label>
                            </td>
                            <td class="auto-style13">
                                <table style="width: 100%; height: 90%">
                                    <tr>
                                        <td>
                                            <div class="lab1">
                                                Visiter:
                                                <br />
                                                <asp:Label ID="Label7" runat="server" Text="123" ForeColor="White"></asp:Label>

                                            </div>
                                        </td>
                                        <td>
                                            <div class="lab2">Today's trade:
                                                <br />
                                                <asp:Label ID="Label8" runat="server" Text="123" ForeColor="White"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="lab3">Today's Order:
                                                <br />
                                                <asp:Label ID="Label9" runat="server" Text="123" ForeColor="White"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="lab4">Revenue:
                                                <br />
                                                <asp:Label ID="Label10" runat="server" Text="123" ForeColor="White"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
               
            </tr>
            <tr>
                <td class="auto-style8" colspan="2">
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="Image2" runat="server" Height="32px" ImageUrl="~/images/Notification.png" Width="44px" /></td>
                            <td class="textlab">
                                <asp:Label ID="Label11" runat="server" Text="Notification" ForeColor="#0099FF"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style10" colspan="2">
                    <table style="width:93%;height:100%;padding-left:60px">
                        <tr>
                            <td class="tip">
                                <asp:Label ID="Label12" runat="server" Font-Size="X-Large" Text="Order &amp;Product"></asp:Label>
                            </td>
                            <td class="tip">
                                <asp:Label ID="Label13" runat="server" Font-Size="X-Large" Text=""></asp:Label>
                            </td>
                            <td class="tip">
                                <asp:Label ID="Label14" runat="server" Font-Size="X-Large" Text=""></asp:Label>
                            </td>
                            <td class="tip">
                                <asp:Label ID="Label15" runat="server" Font-Size="X-Large" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="tip">
                                <asp:Label ID="Label16" runat="server" Font-Size="Large" Text="Pending payment (2)"></asp:Label>
                            </td>
                            <td class="tip">
                                <asp:Label ID="Label17" runat="server" Font-Size="Large" Text=""></asp:Label>
                            </td>
                            <td class="tip">
                                <asp:Label ID="Label18" runat="server" Font-Size="Large" Text=""></asp:Label>
                            </td>
                            <td class="tip">
                                <asp:Label ID="Label19" runat="server" Font-Size="Large" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="tip">
                                <asp:Label ID="Label20" runat="server" Font-Size="Large" Text="Pending Order (2)"></asp:Label>
                            </td>
                            <td class="tip">
                                <asp:Label ID="Label21" runat="server" Font-Size="Large" Text=""></asp:Label>
                            </td>
                            <td class="tip">
                                <asp:Label ID="Label22" runat="server" Font-Size="Large" Text=""></asp:Label>
                            </td>
                            <td class="tip">
                                <asp:Label ID="Label23" runat="server" Font-Size="Large" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:Label ID="Label24" runat="server" Font-Size="Large" Text="Sold Product(2)"></asp:Label>
                            </td>
                            <td class="auto-style14">
                                <asp:Label ID="Label25" runat="server" Font-Size="Large" Text=""></asp:Label>
                            </td>
                            <td class="auto-style14">
                                <asp:Label ID="Label26" runat="server" Font-Size="Large" Text=""></asp:Label>
                            </td>
                            <td class="auto-style14">
                                <asp:Label ID="Label27" runat="server" Font-Size="Large" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

