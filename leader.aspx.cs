using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leader : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        databind();
        if (!IsPostBack)
        {

        }
        foreach (Control item in form1.Controls)
        {
            if (item is TextBox)
            {
                ((TextBox)item).Attributes.Add("autocomplete", "off");
                ((TextBox)item).Attributes.Add("readonly", "True");
            }
        }
    }
    public void databind()
    {

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        string department = Session["department"].ToString();
        SqlCommand cmd = new SqlCommand("select * from all_project where department='" + department + "'", conn);//访问数据库的SQL语句存到了cmd中
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
        string ceshi = Request.Form["ceshi"];
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        string department = Session["department"].ToString();
        SqlCommand cmd = new SqlCommand("select * from all_project where " + DropDownList1.Text + " like '%" + ceshi + "%'and department='" + department + "'", conn);//访问数据库的SQL语句存到了cmd中
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
        string ceshi = Request.Form["ceshi"];
        if (ceshi != "")
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            string department = Session["department"].ToString();
            SqlCommand cmd = new SqlCommand("select * from all_project where " + DropDownList1.Text + " like '%" + ceshi + "%'and department='" + department + "'", conn);//访问数据库的SQL语句存到了cmd中
            conn.Open();//打开连接
            cmd.ExecuteNonQuery();
            SqlDataReader dr1 = cmd.ExecuteReader();  //创建获取datareader
            if (dr1.Read())  //while
            {
                databind1();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('查询有误或没有查到想要的信息，请重新查询!')</script>");
            }
            conn.Close();//关闭连接
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('查询不能为空')</script>");
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
        string pan = Button3.Text.ToString();
        if (pan == "编辑")
        {
            foreach (Control item in form1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Attributes.Remove("readonly");
                }
            }
            Button3.Text = "保存";
            Button4.Text = "取消";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>on();</script>");

        }
        if (pan == "保存")
        {
            foreach (Control item in form1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Attributes.Add("readonly", "True");
                }
            }
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            string id = Label1.Text;
            SqlCommand cmd = new SqlCommand("update all_project set project_date='" + TextBox3.Text.Trim() + "',user_name='" + TextBox4.Text.Trim() + "',department='" + TextBox5.Text.Trim() + "',start_time='" + TextBox6.Text.Trim() + "',end_time='" + TextBox8.Text.Trim() + "',details='" + TextBox9.Text.Trim() + "',remarks='" + TextBox10.Text.Trim() + "'where Date_ID=" + id + "", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            SqlCommand cmd1 = new SqlCommand("select * from all_project where Date_ID=" + id + "", conn);
            conn.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();  //创建获取datareader
            if (dr1.Read())  //while
            {
                Label2.Text = dr1["project_time"].ToString() + "分钟";
            }
            conn.Close();
            databind();
            Button3.Text = "编辑";
            Button4.Text = "关闭";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>on();</script>");
        }

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string pan = Button4.Text.ToString();
        if (pan == "关闭")
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>close();</script>");
        }
        if (pan == "取消")
        {
            foreach (Control item in form1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Attributes.Add("readonly", "True");
                }
            }
            Button3.Text = "编辑";
            Button4.Text = "关闭";
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>on();</script>");
        }
    }
}