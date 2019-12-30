using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class personnel_new : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user_name"] == null)
            {
                Response.Write("<script>alert('请重新登录！');location.href='Login.aspx';</script>");
            }
            else foreach (Control item in form1.Controls)
                {
                    if (item is TextBox)
                    {
                        ((TextBox)item).Attributes.Add("autocomplete", "off");
                    }
                }
            string department = Session["department"].ToString();
            Label1.Text = department;
            string user_id = Session["user_id"].ToString();
            SqlConnection conn1 = new SqlConnection();
            conn1.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd1 = new SqlCommand("select * from all_personnel where user_id='" + user_id + "'", conn1);
            conn1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                Label2.Text = dr1["user_name"].ToString();
            }
            conn1.Close();
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
        if (TextBox1.Text.Trim() != "" && TextBox4.Text.Trim() != "" && TextBox5.Text.Trim() != "" && TextBox6.Text.Trim() != "")
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd = new SqlCommand("insert into all_project(project_date,department,user_name,start_time,end_time,details,remarks,review)values ('" + TextBox1.Text + "','" + Label1.Text + "','" + Label2.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','未审核')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('提交成功')</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('输入信息要完整')</script>");
        }
    }
}