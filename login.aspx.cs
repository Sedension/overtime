using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "" && TextBox2.Text.Trim() != "")
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd = new SqlCommand("select * from all_user where  user_id='" + TextBox1.Text.Trim() + "'", conn);
            conn.Open();//打开连接
            SqlDataReader dr1 = cmd.ExecuteReader();  //创建获取datareader
            if (dr1.Read())
            {
                if (TextBox2.Text == dr1["user_password"].ToString())
                {
                    Session["user"] = dr1["user_id"].ToString();
                    Session["user_type"] = dr1["user_type"].ToString();
                    string link = Session["user_type"].ToString();
                    Response.Redirect("" + link + "_menu.aspx");
                }
                else
                {
                    Response.Write("<script>alert('密码不正确')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('此帐号未注册，请先注册')</script>");
            }
            conn.Close();//关闭连接
        }
        else
        {
            Response.Write("<script>alert('帐号和密码不能为空，请输入帐密')</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
    }
}