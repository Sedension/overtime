using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_admin_project_review : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            databind();
        }
        foreach (Control item in form1.Controls)
        {
            if (item is TextBox)
            {
                ((TextBox)item).Attributes.Add("readonly", "False");
                ((TextBox)item).Attributes.Add("autocomplete", "off");
            }
        }
    }
    public void databind()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        SqlCommand cmd = new SqlCommand("select * from all_project", conn);//访问数据库的SQL语句存到了cmd中
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);//数据适配器 执行cmd
        adp.Fill(dt1);


        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        databind();
    }

    public void databind1()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        SqlCommand cmd = new SqlCommand("select * from all_project where " + DropDownList1.Text + " like '%" + TextBox1.Text.Trim() + "%'", conn);//访问数据库的SQL语句存到了cmd中
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);//数据适配器 执行cmd
        adp.Fill(dt1);


        GridView1.DataSource = dt1;
        GridView1.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        databind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "")
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd = new SqlCommand("select * from all_project where " + DropDownList1.Text + " like '%" + TextBox1.Text.Trim() + "%'", conn);//访问数据库的SQL语句存到了cmd中
            conn.Open();//打开连接
            cmd.ExecuteNonQuery();
            SqlDataReader dr1 = cmd.ExecuteReader();  //创建获取datareader
            if (dr1.Read())  //while
            {
                databind1();
            }
            else
            {
                Response.Write("<script>alert('查询有误或没有查到想要的信息，请重新查询!')</script>");
            }
            conn.Close();//关闭连接
        }
        else
        {
            Response.Write("<script>alert('查询不能为空')</script>");
        }
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>on();</script>");
        string id = GridView1.Rows[e.NewSelectedIndex].Cells[0].Text;
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        SqlCommand cmd = new SqlCommand("select * from all_project where Date_ID=" + id + "", conn);
        conn.Open();//打开连接
        SqlDataReader dr1 = cmd.ExecuteReader();  //创建获取datareader
        if (dr1.Read())  //while
        {
            Label1.Text = dr1["Date_ID"].ToString();
            TextBox3.Text = Convert.ToDateTime(dr1["project_date"]).ToString("yyyy-MM-dd");
            TextBox4.Text = dr1["user_name"].ToString();
            TextBox5.Text = dr1["department"].ToString();
            TextBox6.Text = dr1["start_time"].ToString();
            Label2.Text = dr1["project_time"].ToString() + "分钟";
            TextBox8.Text = dr1["end_time"].ToString();
            TextBox9.Text = dr1["details"].ToString();
            TextBox10.Text = dr1["remarks"].ToString();
        }
        conn.Close();//关闭连接

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        string id = Label1.Text;
        SqlCommand cmd = new SqlCommand("update all_project set review='审批完成' where Date_ID=" + id + "", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        databind();
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>close();</script>");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>close();</script>");
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        string id = Label1.Text;
        SqlCommand cmd = new SqlCommand("update all_project set review='审批失败' where Date_ID=" + id + "", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        databind();
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>close();</script>");
    }
}
