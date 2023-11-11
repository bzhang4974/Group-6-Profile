<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBusiness.master" AutoEventWireup="true" CodeFile="OrderManage.aspx.cs" Inherits="OrderManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        * {
            box-sizing: border-box;
        }

        .menuborder {
            position:relative;
            top:-30px;
            border: 0px;
            outline: none;
            cursor: pointer;
            border-color: transparent;
            border: none;
        }

        .data {
            margin-top: 10px;
            margin-left: 20px;
            font-size: 15px;
        }

        .addButton {
            position: relative;
            right: 180px;
            outline: none;
        }

        #addrcord {
            position: relative;
            left: 50px;
            width: 92%;
            height: 500px;
            background-color: aqua;
        }
        .threebutton{
            position:relative;
            left:220px;
            margin-top:50px;
            margin-right:170px;
        }
        .auto-style7 {
            height: 60px;
        }
        .auto-style8 {
            height: 60px;
        }
        .orderfont{
            font-size:20px;
        }
        .searbutton{
            width: 65px; 
            height: 40px; 
            vertical-align: bottom; 
            margin: auto; 
            background-color: #5da7fb; 
            outline: none; 
            border: none; 
            font-family: 宋体; 
            font-size: x-large; 
            position: relative; 
            right: 7px;
        }
        .searTextbox{
            border: 2px solid #FF0000; 
            width: 500px; 
            height: 40px; 
            margin: auto; 
            outline: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 101%; height: 600px; background-color: white; position: relative; left: 0px;">
        <div style="background-color: #CCCCCC;height:31px;">
            <asp:Menu ID="Menu1" runat="server" BackColor="#CCCCCC" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" DisappearAfter="200" Orientation="Horizontal" RenderingMode="Table" Width="500px" CssClass="menuborder" ForeColor="#333333" OnMenuItemClick="Menu1_MenuItemClick">
                <Items>
                    <asp:MenuItem Text="All Order " Value="0" Selected="True"></asp:MenuItem>
                    <asp:MenuItem Text="Pending paymentOrder " Value="1"></asp:MenuItem>
                    <asp:MenuItem Text="Pending Order " Value="2"></asp:MenuItem>
                    <asp:MenuItem Text="Processing Refund" Value="3"></asp:MenuItem>
                    <asp:MenuItem Text="Completed" Value="4"></asp:MenuItem>
                    <asp:MenuItem Text="Canceled" Value="5"></asp:MenuItem>
                    <asp:MenuItem Text="Refunded" Value="6"></asp:MenuItem>
                </Items>
                <StaticHoverStyle Width="50px" />
                <StaticMenuItemStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" HorizontalPadding="20px" Width="20px" />
                <StaticMenuStyle BackColor="#CCCCCC" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" Width="20px" HorizontalPadding="0px" />
                <StaticSelectedStyle BackColor="White" BorderColor="White" BorderStyle="None" />
            </asp:Menu>
        </div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div style="padding: 7px; text-align: center; vertical-align: middle; padding-right: 200px">
                    <asp:Button ID="Button3" runat="server" BackColor="#FF6600" BorderColor="White" Height="35px" Text="New" Width="65px" CssClass="addButton" OnClick="Button3_Click" />
                    <asp:Label runat="server" Text="Please select" Font-Size="Smaller"></asp:Label>
                    <asp:DropDownList runat="server" Font-Size="Medium" ID="DropDownList8" AutoPostBack="True">
                        <asp:ListItem>Order number</asp:ListItem>
                        <asp:ListItem>User ID</asp:ListItem>
                    </asp:DropDownList>
                    <%--<input id="Text1" type="text" placeholder="Enter keywords...." style="border: 2px solid #FF0000; width: 500px; height: 40px; margin: auto; outline: none;" />--%>
                    <asp:TextBox ID="TextBox8" runat="server" AutoPostBack="True" CssClass="searTextbox"></asp:TextBox>
                    <%--<input id="Button1" type="button" value="search" style="width: 60px; height: 40px; vertical-align: bottom; margin: auto; background-color: #5da7fb; outline: none; border: none; font-family: 宋体; font-size: x-large; position: relative; right: 7px;" />--%>
                    <asp:Button ID="Button18" runat="server" Text="search" CssClass="searbutton" OnClick="Button18_Click" />
                </div>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Font-Size="Large" CssClass="data" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="orderID" HeaderText="Order number" />
                        <asp:BoundField DataField="userID" HeaderText="User ID">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price">
                            <ControlStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shipAddress" HeaderText="Shipping Address">
                            <ControlStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="signDate" HeaderText="Delievered Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tranStatus" HeaderText="Shipping Status">
                            <ControlStyle Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" Wrap="False" />
                    <EmptyDataRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" Wrap="False" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Font-Size="Large" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Width="50px" Wrap="False" />
                    <RowStyle ForeColor="#000066" Font-Size="Medium" Wrap="False" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Shopping_platformConnectionString %>" SelectCommand="SELECT * FROM [order_table]"></asp:SqlDataSource>
                <div id="addrcord" runat="server" style="background-color: #75ecf4;font-size:large;font-weight:200;position:relative;width:80%;margin:20px auto;padding:40px;border:2px double black;">
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style7">Order number:&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="250px" CssClass="orderfont"></asp:TextBox>
                            </td>
                            <td class="auto-style7">User ID:&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="250px" CssClass="orderfont"></asp:TextBox>
                            </td>
                            <td class="auto-style7">Shop ID:&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="TextBox3" runat="server" Height="30px" Width="250px" CssClass="orderfont"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">Order Total Price:
                                <asp:TextBox ID="TextBox4" runat="server" Height="30px" Width="250px" CssClass="orderfont"></asp:TextBox>
                            </td>
                             <td colspan="2" class="auto-style7">Payment Method:
                                <%--<asp:TextBox ID="TextBox5" runat="server" Height="30px" Width="250px"></asp:TextBox>--%>
                                 <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="250px" CssClass="orderfont">
                                     <asp:ListItem Value="Online Payment">Online Payment</asp:ListItem>
                                     <asp:ListItem Value="Cash to Deliver">Cash to Deliver</asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                            
                        </tr>
                        <tr>
                           <td class="auto-style7">Payment Status:
                                <%--<asp:TextBox ID="TextBox5" runat="server" Height="30px" Width="250px"></asp:TextBox>--%>
                               <asp:DropDownList ID="DropDownList4" runat="server" Height="30px" Width="250px" CssClass="orderfont">
                                     <asp:ListItem Value="Unpaid">Unpaid</asp:ListItem>
                                     <asp:ListItem Value="Paid">Paid</asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                            <td colspan="2" class="auto-style7">Payment Date:
                                <asp:TextBox ID="TextBox5" runat="server" Height="30px" Width="250px" CssClass="orderfont"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style8">Order Status:
                                <%--<asp:TextBox ID="TextBox8" runat="server" Height="30px" Width="250px"></asp:TextBox>--%>
                                <asp:DropDownList ID="DropDownList3" runat="server" Height="30px" Width="250px" CssClass="orderfont">
                                     <asp:ListItem Value="Delievering">Delievering</asp:ListItem>
                                     <asp:ListItem Value="Delievered">Delievered</asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                            <td class="auto-style8">Delevery Date:
                                <asp:TextBox ID="TextBox6" runat="server" Height="30px" Width="250px" CssClass="orderfont"></asp:TextBox>
                            </td>
                             <td class="auto-style8">Order Status:
                                <%--<asp:TextBox ID="TextBox10" runat="server" Height="30px" Width="250px"></asp:TextBox>--%>
                                 <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" Width="250px" CssClass="orderfont">
                                     <asp:ListItem Value="Pending payment">Pending payment</asp:ListItem>
                                     <asp:ListItem Value="Pending ">Pending </asp:ListItem>
                                     <asp:ListItem Value="Refund">Refund</asp:ListItem>
                                     <asp:ListItem Value="Completed">Completed</asp:ListItem>
                                     <asp:ListItem Value="Canceled">Canceled</asp:ListItem>
                                     <asp:ListItem Value="Refunded">Refunded</asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                           <td colspan="3" class="auto-style7">Address:
                                <asp:TextBox ID="TextBox7" runat="server" Height="50px" Width="620px" CssClass="orderfont"></asp:TextBox>
                            </td>
                            
                        </tr>
                    </table>
                    <asp:Button ID="Button15" runat="server" Text="Clear" BackColor="Lime" BorderColor="#66FF99" Height="38px" Width="73px" CssClass="threebutton" OnClick="Button15_Click" />
                    <asp:Button ID="Button16" runat="server" Text="Cancel" BackColor="Lime" BorderColor="#66FF99" Height="38px" Width="73px" CssClass="threebutton" OnClick="Button16_Click" />
                    <asp:Button ID="Button17" runat="server" Text="Add" BackColor="Lime" BorderColor="#66FF99" Height="38px" Width="73px" CssClass="threebutton" OnClick="Button17_Click" />
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div style="padding: 7px; text-align: center; vertical-align: middle; padding-right: 200px">
                    <asp:Button ID="Button2" runat="server" BackColor="#FF6600" BorderColor="White" Height="35px" Text="New" Width="65px" CssClass="addButton" />
                    <asp:Label runat="server" Text="Please select" Font-Size="Smaller"></asp:Label>
                    <asp:DropDownList runat="server" Font-Size="Medium" CssClass="">
                        <asp:ListItem>Order number</asp:ListItem>
                        <asp:ListItem>User ID</asp:ListItem>
                    </asp:DropDownList>
                    <input id="Text2" type="text" placeholder="Enter keywords...." style="border: 2px solid #FF0000; width: 500px; height: 40px; margin: auto; outline: none;" />
                    <input id="Button4" type="button" value="search" style="width: 60px; height: 40px; vertical-align: bottom; margin: auto; background-color: #5da7fb; outline: none; border: none; font-family: 宋体; font-size: x-large; position: relative; right: 7px;" />
                </div>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Shopping_platformConnectionString %>" SelectCommand="SELECT * FROM [order_table] WHERE ([tranStatus] = @tranStatus)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="tranStatus" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="data" Font-Size="Large" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" PageSize="15" OnRowDeleting="GridView2_RowDeleting">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="orderID" HeaderText="Order number" />
                        <asp:BoundField DataField="userID" HeaderText="User ID">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price">
                            <ControlStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shipAddress" HeaderText="Address">
                            <ControlStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="signDate" HeaderText="Delievery Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status">
                            <ControlStyle Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" Wrap="False" />
                    <EmptyDataRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" Wrap="False" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Size="Large" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Width="50px" Wrap="False" />
                    <RowStyle Font-Size="Medium" ForeColor="#000066" Wrap="False" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div style="padding: 7px; text-align: center; vertical-align: middle; padding-right: 200px">
                    <asp:Button ID="Button5" runat="server" BackColor="#FF6600" BorderColor="White" Height="35px" Text="New" Width="65px" CssClass="addButton" />
                    <asp:Label runat="server" Text="Please select" Font-Size="Smaller"></asp:Label>
                    <asp:DropDownList runat="server" Font-Size="Medium">
                        <asp:ListItem>Order number</asp:ListItem>
                        <asp:ListItem>User ID</asp:ListItem>
                    </asp:DropDownList>
                    <input id="Text3" type="text" placeholder="Enter keywords...." style="border: 2px solid #FF0000; width: 500px; height: 40px; margin: auto; outline: none;" />
                    <input id="Button6" type="button" value="search" style="width: 60px; height: 40px; vertical-align: bottom; margin: auto; background-color: #5da7fb; outline: none; border: none; font-family: 宋体; font-size: x-large; position: relative; right: 7px;" />
                </div>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Shopping_platformConnectionString %>" SelectCommand="SELECT * FROM [order_table] WHERE ([tranStatus] = @tranStatus)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="tranStatus" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="data" Font-Size="Large" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" PageSize="15">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="orderID" HeaderText="Order number" />
                        <asp:BoundField DataField="userID" HeaderText="User ID">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price">
                            <ControlStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shipAddress" HeaderText="Address">
                            <ControlStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="signDate" HeaderText="Delievery Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status">
                            <ControlStyle Width="100px" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" Wrap="False" />
                    <EmptyDataRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" Wrap="False" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Size="Large" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Width="50px" Wrap="False" />
                    <RowStyle Font-Size="Medium" ForeColor="#000066" Wrap="False" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <div style="padding: 7px; text-align: center; vertical-align: middle; padding-right: 200px">
                    <asp:Button ID="Button7" runat="server" BackColor="#FF6600" BorderColor="White" Height="35px" Text="New" Width="65px" CssClass="addButton" />
                    <asp:Label runat="server" Text="Please select" Font-Size="Smaller"></asp:Label>
                    <asp:DropDownList runat="server" Font-Size="Medium">
                        <asp:ListItem>Order number</asp:ListItem>
                        <asp:ListItem>User ID</asp:ListItem>
                    </asp:DropDownList>
                    <input id="Text4" type="text" placeholder="Enter keywords...." style="border: 2px solid #FF0000; width: 500px; height: 40px; margin: auto; outline: none;" />
                    <input id="Button8" type="button" value="search" style="width: 60px; height: 40px; vertical-align: bottom; margin: auto; background-color: #5da7fb; outline: none; border: none; font-family: 宋体; font-size: x-large; position: relative; right: 7px;" />
                    <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="data" Font-Size="Large" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="15">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="orderID" HeaderText="Order number" />
                            <asp:BoundField DataField="userID" HeaderText="User ID">
                                <ControlStyle Width="80px" />
                            </asp:BoundField>
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price">
                            <ControlStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shipAddress" HeaderText="Address">
                            <ControlStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="signDate" HeaderText="Delievery Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status">
                                <ControlStyle Width="100px" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" Wrap="False" />
                        <EmptyDataRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" Wrap="False" />
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Size="Large" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Width="50px" Wrap="False" />
                        <RowStyle Font-Size="Medium" ForeColor="#000066" Wrap="False" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <div style="padding: 7px; text-align: center; vertical-align: middle; padding-right: 200px">
                    <asp:Button ID="Button9" runat="server" BackColor="#FF6600" BorderColor="White" Height="35px" Text="New" Width="65px" CssClass="addButton" />
                    <asp:Label runat="server" Text="Please select" Font-Size="Smaller"></asp:Label>
                    <asp:DropDownList runat="server" Font-Size="Medium">
                        <asp:ListItem>Order number</asp:ListItem>
                        <asp:ListItem>User ID</asp:ListItem>
                    </asp:DropDownList>
                    <input id="Text5" type="text" placeholder="Enter keywords...." style="border: 2px solid #FF0000; width: 500px; height: 40px; margin: auto; outline: none;" />
                    <input id="Button10" type="button" value="search" style="width: 60px; height: 40px; vertical-align: bottom; margin: auto; background-color: #5da7fb; outline: none; border: none; font-family: 宋体; font-size: x-large; position: relative; right: 7px;" />
                    <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="data" Font-Size="Large" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" PageSize="15">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="orderID" HeaderText="Order number" />
                            <asp:BoundField DataField="userID" HeaderText="User ID">
                                <ControlStyle Width="80px" />
                            </asp:BoundField>
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price">
                            <ControlStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shipAddress" HeaderText="Address">
                            <ControlStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="signDate" HeaderText="Delievery Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status">
                                <ControlStyle Width="100px" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" Wrap="False" />
                        <EmptyDataRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" Wrap="False" />
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Size="Large" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Width="50px" Wrap="False" />
                        <RowStyle Font-Size="Medium" ForeColor="#000066" Wrap="False" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="View6" runat="server">
                <div style="padding: 7px; text-align: center; vertical-align: middle; padding-right: 200px">
                    <asp:Button ID="Button11" runat="server" BackColor="#FF6600" BorderColor="White" Height="35px" Text="New" Width="65px" CssClass="addButton" />
                    <asp:Label runat="server" Text="Please select" Font-Size="Smaller"></asp:Label>
                    <asp:DropDownList runat="server" Font-Size="Medium">
                        <asp:ListItem>Order number</asp:ListItem>
                        <asp:ListItem>User ID</asp:ListItem>
                    </asp:DropDownList>
                    <input id="Text6" type="text" placeholder="Enter keywords...." style="border: 2px solid #FF0000; width: 500px; height: 40px; margin: auto; outline: none;" />
                    <input id="Button12" type="button" value="search" style="width: 60px; height: 40px; vertical-align: bottom; margin: auto; background-color: #5da7fb; outline: none; border: none; font-family: 宋体; font-size: x-large; position: relative; right: 7px;" />
                    <asp:GridView ID="GridView6" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="data" Font-Size="Large" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" PageSize="15">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="orderID" HeaderText="Order number" />
                            <asp:BoundField DataField="userID" HeaderText="User ID">
                                <ControlStyle Width="80px" />
                            </asp:BoundField>
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price">
                            <ControlStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shipAddress" HeaderText="Address">
                            <ControlStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="signDate" HeaderText="Delievery Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status">
                                <ControlStyle Width="100px" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" Wrap="False" />
                        <EmptyDataRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" Wrap="False" />
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Size="Large" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Width="50px" Wrap="False" />
                        <RowStyle Font-Size="Medium" ForeColor="#000066" Wrap="False" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="View7" runat="server">
                <div style="padding: 7px; text-align: center; vertical-align: middle; padding-right: 200px">
                    <asp:Button ID="Button13" runat="server" BackColor="#FF6600" BorderColor="White" Height="35px" Text="New" Width="65px" CssClass="addButton" />
                    <asp:Label runat="server" Text="Please select" Font-Size="Smaller"></asp:Label>
                    <asp:DropDownList runat="server" Font-Size="Medium">
                        <asp:ListItem>Order number</asp:ListItem>
                        <asp:ListItem>User ID</asp:ListItem>
                    </asp:DropDownList>
                    <input id="Text7" type="text" placeholder="Enter keywords...." style="border: 2px solid #FF0000; width: 500px; height: 40px; margin: auto; outline: none;" />
                    <input id="Button14" type="button" value="search" style="width: 60px; height: 40px; vertical-align: bottom; margin: auto; background-color: #5da7fb; outline: none; border: none; font-family: 宋体; font-size: x-large; position: relative; right: 7px;" />
                    <asp:GridView ID="GridView7" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="data" Font-Size="Large" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" PageSize="15">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="orderID" HeaderText="Order number" />
                            <asp:BoundField DataField="userID" HeaderText="User ID">
                                <ControlStyle Width="80px" />
                            </asp:BoundField>
                        <asp:BoundField DataField="shopID" HeaderText="Shop ID">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="Order Total Price">
                            <ControlStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shipAddress" HeaderText="Address">
                            <ControlStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payMethod" HeaderText="Payment Method">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="payDate" HeaderText="Payment Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="signDate" HeaderText="Delievery Date">
                            <ControlStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tranStatus" HeaderText="Order Status">
                                <ControlStyle Width="100px" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" Wrap="False" />
                        <EmptyDataRowStyle Font-Size="Medium" Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" Wrap="False" />
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Size="Large" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Width="50px" Wrap="False" />
                        <RowStyle Font-Size="Medium" ForeColor="#000066" Wrap="False" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>


