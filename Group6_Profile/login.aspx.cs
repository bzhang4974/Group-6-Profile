using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class login : System.Web.UI.Page
{
    public static string con = ConfigurationManager.ConnectionStrings["Shopping_platformConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  
        {

        }
    }

    //reset
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
    }

    //register
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.RequiredFieldValidator1.Enabled = false;
        this.RequiredFieldValidator2.Enabled = false;
        Response.Redirect("registert.aspx");
    }

    //forgot password
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("modifyPWD.aspx");
        //Response.Write("<script>alert('Please contact the admin for the account recovery！')</script>");
    }

    //login screen
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue.ToString() == "Normal User")
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                SqlConnection conn = new SqlConnection(con);
                conn.Open();
                string SqlID = $"select [userName],[imageURL],[shipAddress] from [user_table] where userID='{TextBox1.Text.Trim()}'";
                SqlDataAdapter tempData = new SqlDataAdapter(SqlID, conn);
                DataTable tempTable = new DataTable();
                tempData.Fill(tempTable);
                if (tempTable.Rows.Count>0)
                {
                    string url = tempTable.Rows[0]["imageURL"].ToString();
                    string tempname = tempTable.Rows[0]["userName"].ToString();

                    System.Text.Encoding enc = System.Text.Encoding.GetEncoding("gb2312");
                    //create HttpCokie object,use cookie to save users credentials
                    HttpCookie cookie = new HttpCookie("UID");
                    HttpCookie cookieURL = new HttpCookie("imgURL");
                    HttpCookie cookieName = new HttpCookie("Uname");
                    HttpCookie cookieAddress = new HttpCookie("address");
                    //set cookie's value property
                    cookie.Value = TextBox1.Text.ToString();
                    cookieURL.Value = url;
                    cookieURL.Value = HttpUtility.UrlEncode(url, enc);
                    cookieName.Value= HttpUtility.UrlEncode(tempname, enc);
                    cookieAddress.Value= HttpUtility.UrlEncode(tempTable.Rows[0]["shipAddress"].ToString(), enc);
                   
                    Response.Cookies.Add(cookie);
                    Response.Cookies.Add(cookieURL);
                    Response.Cookies.Add(cookieName);

                    Response.Redirect("home.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Wrong username or password!!!')</script>");
                }
                conn.Close();
            }
        }else if (RadioButtonList1.SelectedValue.ToString() == "Seller")
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                SqlConnection conn = new SqlConnection(con);
                conn.Open();
                string SqlID = $"select [lpersonName] from [shop_table] where shopID='{TextBox1.Text.Trim()}'";
                SqlDataAdapter tempData = new SqlDataAdapter(SqlID, conn);
                DataTable tempTable = new DataTable();
                tempData.Fill(tempTable);
                if (tempTable.Rows.Count > 0)
                {
                    //string url = tempTable.Rows[0]["imageURL"].ToString();
                    string tempname = tempTable.Rows[0]["lpersonName"].ToString();

                    //System.Text.Encoding enc = System.Text.Encoding.GetEncoding("gb2312");
                    //create HttpCokie object,use cookie save user credentials
                    HttpCookie cookie = new HttpCookie("UID");
                    //HttpCookie cookieURL = new HttpCookie("imgURL");
                    HttpCookie cookieName = new HttpCookie("Uname");
                    //set cookie value property
                    cookie.Value = TextBox1.Text.ToString();
                    //cookieURL.Value = url;
                    //cookieURL.Value = HttpUtility.UrlEncode(url, enc);
                    //cookieName.Value = HttpUtility.UrlEncode(tempname, enc);
                    cookieName.Value = tempname;
                    Response.Cookies.Add(cookie);
                    //Response.Cookies.Add(cookieURL);
                    Response.Cookies.Add(cookieName);

                    Response.Redirect("BusinessHome.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Wrong username or password!!!')</script>");
                }
                conn.Close();
            }
            //Response.Write("<script>alert('under development!!!')</script>");
        }
    }
}