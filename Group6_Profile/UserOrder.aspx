<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.master" AutoEventWireup="true" CodeFile="UserOrder.aspx.cs" Inherits="UserOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        * {
            box-sizing: border-box;
        }

        .orderbody {
            position: relative;
            width: 100%;
            height: 100%;
            /*background-color: aqua;*/
            border: 1px solid transparent;
        }

        .menuDIV {
            position: relative;
            width: 100%;
            height: 31px;
            color: black;
            font-size: 25px;
            background-color: #CCCCCC;
        }

        .menuCSS {
            position: absolute;
            top: -1px;
            color: black;
        }

        .gridview {
            position: relative;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="orderbody">
        <div class="menuDIV">
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" RenderingMode="Table" StaticEnableDefaultPopOutImage="False" CssClass="menuCSS" ForeColor="Black" OnMenuItemClick="Menu1_MenuItemClick">
                <Items>
                    <asp:MenuItem Text="All Order " Value="All Order " Selected="True"></asp:MenuItem>
                    <asp:MenuItem Text="Pending payment" Value="Pending payment"></asp:MenuItem>
                    <asp:MenuItem Text="Pending " Value="Pending "></asp:MenuItem>
                    <asp:MenuItem Text="Processing Refund" Value="Processing Refund"></asp:MenuItem>
                    <asp:MenuItem Text="Completed" Value="Completed"></asp:MenuItem>
                    <asp:MenuItem Text="Canceled" Value="Canceled"></asp:MenuItem>
                    <asp:MenuItem Text="Refunded" Value="Refunded"></asp:MenuItem>
                </Items>
                <StaticMenuItemStyle HorizontalPadding="8px" />
                <StaticMenuStyle Width="150px" />
                <StaticSelectedStyle BackColor="White" />
            </asp:Menu>
        </div>
        <div class="gridview">
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" Width="1010px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" PageSize="7" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <%--<asp:CommandField ShowDeleteButton="True">
                            <ControlStyle Width="40px" />
                        </asp:CommandField>--%>
                        <asp:BoundField DataField="orderID" HeaderText="Order number">
                            <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="userID" HeaderText="User ID" />
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID" />
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price" />
                        <asp:BoundField DataField="shipAddress" HeaderText="Address" />
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method" />
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date" />
                        <asp:BoundField DataField="signDate" HeaderText="Delivery Date" />
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" PageSize="7" OnPageIndexChanging="GridView2_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="orderID" HeaderText="Order number">
                            <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="userID" HeaderText="User ID" />
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID" />
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price" />
                        <asp:BoundField DataField="shipAddress" HeaderText="Address" />
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method" />
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date" />
                        <asp:BoundField DataField="signDate" HeaderText="Delivery Date" />
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" PageSize="7" OnPageIndexChanging="GridView3_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="orderID" HeaderText="Order number">
                            <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="userID" HeaderText="User ID" />
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID" />
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price" />
                        <asp:BoundField DataField="shipAddress" HeaderText="Address" />
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method" />
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date" />
                        <asp:BoundField DataField="signDate" HeaderText="Delivery Date" />
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" PageSize="7" OnPageIndexChanging="GridView4_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="orderID" HeaderText="Order number">
                            <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="userID" HeaderText="User ID" />
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID" />
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price" />
                        <asp:BoundField DataField="shipAddress" HeaderText="Address" />
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method" />
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date" />
                        <asp:BoundField DataField="signDate" HeaderText="Delivery Date" />
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" PageSize="7">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="orderID" HeaderText="Order number">
                            <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="userID" HeaderText="User ID" />
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID" />
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price" />
                        <asp:BoundField DataField="shipAddress" HeaderText="Address" />
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method" />
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date" />
                        <asp:BoundField DataField="signDate" HeaderText="Delivery Date" />
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" PageSize="7" OnPageIndexChanging="GridView6_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="orderID" HeaderText="Order number">
                            <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="userID" HeaderText="User ID" />
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID" />
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price" />
                        <asp:BoundField DataField="shipAddress" HeaderText="Address" />
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method" />
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date" />
                        <asp:BoundField DataField="signDate" HeaderText="Delivery Date" />
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" PageSize="7" OnPageIndexChanging="GridView7_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="orderID" HeaderText="Order number">
                            <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="userID" HeaderText="User ID" />
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID" />
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price" />
                        <asp:BoundField DataField="shipAddress" HeaderText="Address" />
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method" />
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date" />
                        <asp:BoundField DataField="signDate" HeaderText="Delivery Date" />
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

