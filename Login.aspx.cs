using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
        foreach (Control item in form1.Controls)
        {
            if (item is TextBox)
            {
                ((TextBox)item).Attributes.Add("autocomplete", "off");

            }
        }
        TextBox1.Attributes.Add("onkeyup", "if(isNaN(value))execCommand('undo')");
        TextBox1.Attributes.Add("onfocus", "if (value =='请输入数字账号'){value =''}");
        TextBox1.Attributes.Add("onblur", "if (value ==''){value='请输入数字账号'}");
        TextBox2.Attributes.Add("value", "请输入密码");
        TextBox2.Attributes.Add("onfocus", "if(this.value=='请输入密码'){this.type='password';this.value=''}");
        TextBox2.Attributes.Add("onblur", "if(this.value==''){this.type='text';this.value='请输入密码'}");
    }
    public void passwoererror()
    {
        this.TextBox2.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim()== "请输入数字账号")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('请输入账号！')</script>");
            passwoererror();
        }
        if (TextBox1.Text.Trim() != "" && TextBox2.Text.Trim() != "")
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd = new SqlCommand("select * from all_user where  user_id='" + TextBox1.Text.Trim() + "'", conn);
            SqlCommand cmd1 = new SqlCommand("select * from all_personnel where user_id='" + TextBox1.Text.Trim() + "'", conn);
            conn.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                Session["department"] = dr1["department"].ToString();
                Session["user_name"] = dr1["user_name"].ToString();
            }
            conn.Close();
            conn.Open();
            SqlDataReader dr2 = cmd.ExecuteReader();
            if (dr2.Read())
            {
                if (TextBox2.Text == dr2["user_password"].ToString())
                {
                    Session["user_id"] = TextBox1.Text.Trim();
                    Session["user_type"] = dr2["user_type"].ToString();
                    string link = Session["user_type"].ToString();
                    Response.Redirect("" + link + "_menu.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('密码不正确')</script>");
                    passwoererror();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('此帐号不存在，请检查输入或者联系工作人员')</script>");
                passwoererror();
            }
            conn.Close();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('帐号和密码不能为空，请正确输入帐密')</script>");
        }
        TextBox2.Attributes.Add("onblur", "if(this.value==''){this.type='text';this.value='请输入密码'}");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TextBox1.Text = "";
        passwoererror();
    }
}