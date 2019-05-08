using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class release : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (Control item in form1.Controls)
        {
            if (item is TextBox)
            {
                ((TextBox)item).Attributes.Add("autocomplete", "off");
            }
        }

        if (!IsPostBack)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd = new SqlCommand("select distinct department from all_personnel", conn);//访问数据库的SQL语句存到了cmd中
            DataTable dt1 = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);//数据适配器 执行cmd
            adp.Fill(dt1);
            DropDownList1.DataSource = dt1;
            DropDownList1.DataValueField = "department";
            DropDownList1.DataBind();
            this.DropDownList1.Items.Insert(0, new ListItem("-请选择-", "0"));
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
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        SqlCommand cmd = new SqlCommand("insert into all_project(project_date,department,user_name,start_time,end_time,details,remarks,review)values ('" + TextBox1.Text + "','" + DropDownList1.Text + "','" + DropDownList2.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','审批完成')", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Write("<script>alert('发布成功')</script>");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        SqlCommand cmd = new SqlCommand("select distinct user_name from all_personnel where department='" + DropDownList1.SelectedValue + "'", conn);
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);//数据适配器 执行cmd
        adp.Fill(dt1);
        DropDownList2.DataSource = dt1;
        DropDownList2.DataValueField = "user_name";
        DropDownList2.DataBind();
        this.DropDownList2.Items.Insert(0, new ListItem("-请选择-", "0"));
    }
}