<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<%--Register--%>
<%@ Register Src="~/ShopCart.ascx" TagPrefix="uc1" TagName="ShopCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        * {
            box-sizing: border-box;
        }
        .panel1{
            position:relative;
            top:-25px;
        }
        ul {
            position: relative;
            width: 1012px;
            height: 30px;
            top: -16px;
            background-color: white;
        }

            ul > li {
                position: relative;
                float: left;
                width: 130px;
                height: 30px;
                left: -40px;
                right: -50px;
                margin-right: 0px;
                padding: 0px;
                list-style: none;
                font-family: Microsoft Yahei;
                font-size: 20px;
                font-weight: 500;
                text-align: center;
                background-color: white;
                border-right: 2px solid black;
            }

        li:nth-child(1) {
            width: 75px;
        }

        li:nth-child(2) {
            width: 410px;
        }

        li:nth-child(4) {
            width: 130px;
        }

        li:nth-child(6) {
            width: 110px;
            margin-right: -50px;
            right: -20px;
            border-right: 2px solid transparent;
        }
        .purch{
            position:relative;
            width:50px;
            height:30px;
            top:-43px;
            left:750px;
            font-size:20px;
            background-color:orange;
            border: 1px solid transparent;
        }
        .totalP{
            position:relative;
            top:-40px;
            left:20px;
            font-size:25px;
            color:red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="headLine">
        <ul>
            <li>
                <span>
                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" />Select all
                </span>
            </li>
            <li>description</li>
            <li>price</li>
            <li>quantity</li>
            <li>total price</li>
            <li>operation</li>
        </ul>
    </div>
    <asp:Panel ID="Panel1" runat="server" Height="440px" ScrollBars="Vertical" Width="1012px" CssClass="panel1">
        <%--<uc1:ShopCart runat="server" id="ShopCart" />--%>
    </asp:Panel>
    <p>
        <asp:Label ID="Label1" runat="server" Text="total price:0.00 CAD" CssClass="totalP"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Purchase" CssClass="purch" OnClick="Button1_Click" />
    </p>
</asp:Content>

