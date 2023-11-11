using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class UFavorite : System.Web.UI.UserControl
{
    public static string constr = ConfigurationManager.ConnectionStrings["Shopping_platformConnectionString"].ConnectionString;

    public string tempID;  //ProductID
    public double tempPric;  //Product价格
    public string tempIntrduce;  //Product简介
    public string tempURL;  //图片路径

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    public void InitFavour(string ID, string intrduc, string imageUrl, double price)
    {
        tempPric = price;
        tempID = ID;
        tempIntrduce = intrduc;
        tempURL = imageUrl;
        this.Image1.ImageUrl = imageUrl;
        this.Label1.Text = $"${price:F2}";
        this.Label2.Text = intrduc;
    }

   
    void addShoppingCart(string comID, double price, string introduce, string imageUrl)
    {
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        
        string SqlStr1 = $"select [comName] from [WebCart] where [commID]='{comID}'";
        SqlDataAdapter data1 = new SqlDataAdapter(SqlStr1, conn);
        DataTable dataTable = new DataTable();
        data1.Fill(dataTable);
        
        if (dataTable.Rows.Count <= 0) 
        {
            string Sqlname = $"select [comName] from [commodity_table] where [comID]='{comID}'";
            SqlDataAdapter tempData = new SqlDataAdapter(Sqlname, conn);
            DataTable tempTable = new DataTable();
            tempData.Fill(tempTable);
            string cname = tempTable.Rows[0]["comName"].ToString();
            string sqlInsert = $"insert into [WebCart]([commID],[comName],[comIntroduction],[comPrice],[comSurplus],[imgUrl]) values('" + comID + "','" + cname + "','" + introduce + "','" + price + "','" + 1 + "','" + imageUrl + "')";
            SqlCommand sqlcom1 = new SqlCommand(sqlInsert, conn);
            sqlcom1.ExecuteNonQuery();
        }
        else if (dataTable.Rows.Count > 0)  
        {
            string Sqlname = $"select [comSurplus] from [WebCart] where [commID]='{comID}'";
            SqlDataAdapter tempData = new SqlDataAdapter(Sqlname, conn);
            DataTable tempTable = new DataTable();
            tempData.Fill(tempTable);

            int splus = int.Parse(tempTable.Rows[0]["comSurplus"].ToString()) + 1;
            //string cname = dataTable.Rows[0]["comName"].ToString();
            string sqlInsert = $"update [WebCart] set [comSurplus]={splus} where [commID]='" + comID + "'";
            SqlCommand sqlcom1 = new SqlCommand(sqlInsert, conn);
            sqlcom1.ExecuteNonQuery();
        }
        conn.Close();
    }

    //wishlist Cart
    protected void Button1_Click(object sender, EventArgs e)
    {
        addShoppingCart(tempID, tempPric, tempIntrduce, tempURL);
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        string sqldelete = $"delete from [Favoury] where [commID]='{tempID}'";
        SqlCommand sqlcom1 = new SqlCommand(sqldelete, conn);
        int n = sqlcom1.ExecuteNonQuery();
        conn.Close();
        if (n > 0)
        {
            Response.Write("<script>alert('Item has been added！');location.href='UserFavorite.aspx'</script>");

        }
        else
        {
            Response.Write("<script>alert('Failed to add！');location.href='UserFavorite.aspx'</script>");
        }
    }

    
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        string sqldelete = $"delete from [Favoury] where [commID]='{tempID}'";
        SqlCommand sqlcom1 = new SqlCommand(sqldelete, conn);
        int n = sqlcom1.ExecuteNonQuery();
        conn.Close();
        if (n > 0)
        {
            
            Response.Write("<script>alert('Product removed from wishlist!！');location.href='UserFavorite.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('Failed to remove the item！');location.href='UserFavorite.aspx'</script>");
        }
    }
}