using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leader_release : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
        if (!IsPostBack)
        {
            string department = Session["department"].ToString();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd = new SqlCommand("select distinct user_name from all_project where department='" + department + "'", conn);
            Label1.Text = department;
            DataTable dt1 = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt1);
            DropDownList2.DataSource = dt1;
            DropDownList2.DataValueField = "user_name";
            DropDownList2.DataBind();
            this.DropDownList2.Items.Insert(0, new ListItem("-请选择-", "0"));
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
        if (TextBox1.Text.Trim() != "" && DropDownList2.Text.Trim() != "0" && TextBox4.Text.Trim() != "" && TextBox5.Text.Trim() != "" && TextBox6.Text.Trim() != "" && TextBox7.Text.Trim() != "")
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd = new SqlCommand("insert into all_project(project_date,department,user_name,start_time,end_time,details,remarks,review)values ('" + TextBox1.Text + "','" + Label1.Text + "','" + DropDownList2.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','一级审批完成')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('发布成功')</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('输入信息要完整')</script>");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        SqlCommand cmd = new SqlCommand("select distinct user_name from all_personnel where department='" + Label1.Text + "'", conn);
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt1);
        DropDownList2.DataSource = dt1;
        DropDownList2.DataValueField = "user_name";
        DropDownList2.DataBind();
        this.DropDownList2.Items.Insert(0, new ListItem("-请选择-", "0"));
    }
}