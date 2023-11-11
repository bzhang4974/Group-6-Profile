using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ShoppingCart : System.Web.UI.Page
{
    public static string constr = ConfigurationManager.ConnectionStrings["Shopping_platformConnectionString"].ConnectionString;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        string SqlStr1 = $"select * from [WebCart]";
        SqlDataAdapter data1 = new SqlDataAdapter(SqlStr1, conn);
        DataTable dataTable = new DataTable();
        data1.Fill(dataTable);
        conn.Close();


        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            string CID = dataTable.Rows[i]["commID"].ToString();
            string information = dataTable.Rows[i]["comIntroduction"].ToString();
            string imgURL = dataTable.Rows[i]["imgUrl"].ToString();
            string temp = $"{dataTable.Rows[i]["comPrice"]:F2}";
            double Cprice = double.Parse(temp);
            int splus = int.Parse(dataTable.Rows[i]["comSurplus"].ToString());

            //ShopCart shopCart = (ShopCart)LoadControl("~/ShopCart.ascx");
            ShopCart shopCart = (ShopCart)this.Page.LoadControl("~/ShopCart.ascx");
            shopCart.ID = "shopCart" + i.ToString();
            shopCart.OnCheckedChanged += ShopCart_OnCheckedChanged;  
            shopCart.InitShopCart(CID, information, imgURL, Cprice, splus);  
            this.Panel1.Controls.Add(shopCart);
        }
    }

    //Select all
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        //AutoPostBack="True"
        foreach (var ctl in Panel1.Controls)
        {
            if (ctl is ShopCart clst)
                clst.IsChecked = this.CheckBox1.Checked;
        }
        ShopCart_OnCheckedChanged(sender, e);
    }

    //total price
    private void ShopCart_OnCheckedChanged(object sender, EventArgs e)
    {
        double total = 0;
        foreach (var ctl in Panel1.Controls)
        {
            if (ctl is ShopCart clst && clst.IsChecked)
            {
                total += Convert.ToDouble(clst.tempPric) * int.Parse(clst.tempSplus);
            }
        }
        Label1.Text = $"Total price:{total:F2}CAD";
    }

    //Purchase
    protected void Button1_Click(object sender, EventArgs e)
    {
        double totalPrice = 0.0;
        //List<string> tempID = new List<string>();
        //Dictionary<string, int> tempSplus = new Dictionary<string, int>();
        foreach (var ctl in Panel1.Controls)
        {
            if (ctl is ShopCart clst && clst.IsChecked)
            {
                totalPrice += Convert.ToDouble(clst.tempPric) * int.Parse(clst.tempSplus);
            }
        }

        Random ran = new Random();
        string newOrder = DateTime.Now.ToString("yyyyMMddhhmmss") + ran.Next(1000, 9999).ToString();
        string paydate = DateTime.Now.ToString("yyyy-MM-dd");
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        string SqlStr1 = $"select [shipAddress] from [user_table] where userID='{Request.Cookies["UID"].Value}'";
        SqlDataAdapter data1 = new SqlDataAdapter(SqlStr1, conn);
        DataTable dataTable = new DataTable();
        data1.Fill(dataTable);
        string tempaddress = dataTable.Rows[0]["shipAddress"].ToString();
        string sqlInsert = $"insert into [new_order]([orderID],[userID],[shopID],[orderTotalPrice],[shipAddress],[payMethod],[payDate],[tranStatus]) values('" + newOrder + "','" + Request.Cookies["UID"].Value + "','" + 1001 + "','" + totalPrice + "','" + tempaddress + "', '" + "online payment" + "', '" + paydate + "', '" + "wait for shipping" + "' )";

        SqlCommand sqlcom1 = new SqlCommand(sqlInsert, conn);
        sqlcom1.ExecuteNonQuery();

        List<string> tempID = new List<string>();
        foreach (var ctl in Panel1.Controls)
        {
            if (ctl is ShopCart clst && clst.IsChecked)
            {
                tempID.Add(clst.tempID);
                totalPrice += Convert.ToDouble(clst.tempPric) * int.Parse(clst.tempSplus);
            }
        }
        foreach (var item in tempID)
        {
            string sqldelete = $"delete from [WebCart] where [commID]='{item}'";
            SqlCommand sqlde = new SqlCommand(sqldelete, conn);
            sqlde.ExecuteNonQuery();
        }
        
        //int n = sqlde.ExecuteNonQuery();
        Response.Write("<script>alert('Purchasesuccessfully！');location.href='ShoppingCart.aspx'</script>");
    }
}