using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_personnel_insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('请重新登录！');location ='login.aspx';</script>");
        }
        foreach (Control item in form1.Controls)
        {
            if (item is TextBox)
            {
                ((TextBox)item).Attributes.Add("autocomplete", "off");
            }
        }

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        foreach (Control item in form1.Controls)
        {
            if (item is TextBox)
            {
                ((TextBox)item).Text = "";
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "" && TextBox2.Text.Trim() != "" &&  TextBox3.Text.Trim() != "" && TextBox4.Text.Trim() != "" &&  TextBox5.Text.Trim() != "")
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd = new SqlCommand("insert into all_personnel values ('" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + DropDownList3.Text + "')", conn);
            SqlCommand cmd1 = new SqlCommand("insert into all_user values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList3.Text + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            conn.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('添加成功')</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('输入信息要完整')</script>");
        }
    }
}