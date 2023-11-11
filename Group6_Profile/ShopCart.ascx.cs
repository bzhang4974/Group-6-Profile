using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class ShopCart : System.Web.UI.UserControl
{
    public static string constr = ConfigurationManager.ConnectionStrings["Shopping_platformConnectionString"].ConnectionString;

    public event EventHandler OnCheckedChanged;  
    public string tempID;  //ProductID
    public double tempPric; 

    public string tempSplus  
    {
        get { return this.TextBox1.Text; }
        set { this.TextBox1.Text = value; }
    }
    public bool IsChecked   
    {
        get { return this.CheckBox1.Checked; }
        set { this.CheckBox1.Checked = value; }
    }
    public void InitShopCart(string ID, string intrduc, string imageUrl, double price, int splu)
    {
        tempPric = price;
        tempID = ID;
        this.Image1.ImageUrl = imageUrl;
        this.Label1.Text = intrduc;
        this.Label2.Text = $"${price:F2}";
        this.TextBox1.Text = splu.ToString();
        this.Label3.Text = $"${splu * price:F2}";
        tempSplus = this.TextBox1.Text.ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //减number
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (int.Parse(this.TextBox1.Text.ToString()) > 1)
        {
            this.TextBox1.Text = (int.Parse(this.TextBox1.Text.ToString()) - 1).ToString();
        }
        else
        {
            this.TextBox1.Text = "1";
        }
        //int temnum = int.Parse(this.TextBox1.Text.ToString());
        tempSplus = this.TextBox1.Text.ToString();
        this.Label3.Text = $"${int.Parse(tempSplus) * tempPric:F2}";
        OnCheckedChanged?.Invoke(sender, e);
    }

    //number
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TextBox1.Text = (int.Parse(this.TextBox1.Text.ToString()) + 1).ToString();
        tempSplus = this.TextBox1.Text.ToString();
        this.Label3.Text = $"${int.Parse(tempSplus) * tempPric:F2}";

        OnCheckedChanged?.Invoke(sender, e);
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        OnCheckedChanged?.Invoke(sender, e);
    }


 
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        string sqldelete = $"delete from [WebCart] where [commID]='{tempID}'";
        SqlCommand sqlcom1 = new SqlCommand(sqldelete, conn);
        int n = sqlcom1.ExecuteNonQuery();
        conn.Close();
        if (n > 0)
        {
            
            Response.Write("<script>alert('Product removed from cart!！');location.href='ShoppingCart.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('Failed to remove the product！');location.href='ShoppingCart.aspx'</script>");
        }
    }
}