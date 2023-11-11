using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class registert : System.Web.UI.Page
{
    public static string con = ConfigurationManager.ConnectionStrings["Shopping_platformConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  
        {
           
        }
    }


    //Cancel
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    //login
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    //Confirm change 
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            string SqlID = $"select [userTell] from [user_table] where userID='{TextBox1.Text.Trim()}'";
            SqlDataAdapter tempData = new SqlDataAdapter(SqlID, conn);
            DataTable tempTable = new DataTable();
            tempData.Fill(tempTable);
            string temptel = tempTable.Rows[0]["userTell"].ToString();
            if (TextBox2.Text == temptel.Trim())
            {
                string sqlUpate = $"update [user_table] set [userPwd]='{TextBox4.Text.Trim()}' where [userID]='" + TextBox1.Text.Trim() + "'";
                SqlCommand sqlcom1 = new SqlCommand(sqlUpate, conn);
                sqlcom1.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('change successfully！');location.href='modifyPWD.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('invalid phone number！');location.href='modifyPWD.aspx'</script>");
            }
        }
        catch (SqlException sqlex)
        {
            Response.Write("<script>alert('Invalid account！');location.href='modifyPWD.aspx'</script>");
            if (sqlex.ErrorCode.ToString() != "")
            {
                Response.Write("<script>alert('" + sqlex.Message.ToString() + "');location.href='modifyPWD.aspx'</script>");
            }
        }
    }
}