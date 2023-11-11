using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Account_Security : System.Web.UI.Page
{
    public static string constr = ConfigurationManager.ConnectionStrings["Shopping_platformConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Delete account
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        string sqldelete = $"delete from [user_table] where [userID]=" + "'" + Request.Cookies["UID"].Value.Trim() + "'";
        SqlCommand sqlcom1 = new SqlCommand(sqldelete, conn);
        int n = sqlcom1.ExecuteNonQuery();
        conn.Close();
        if (n > 0)
        {
            //location.href='your.aspx'
            Response.Write("<script>alert('Your account has been deleted successfully!！');location.href='login.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('Failed to delete！');location.href='Account_Security.aspx'</script>");
        }
    }

    //Register new account
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("registert.aspx");
    }
}