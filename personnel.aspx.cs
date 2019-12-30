using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class personnel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["user_name"] == null && Session["department"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('请重新登录！');location ='login.aspx';</script>");
            }
            else
            {
                {
                    Label3.Text = Session["user_name"].ToString();
                    Label4.Text = Session["department"].ToString();
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                    SqlCommand cmd = new SqlCommand("select sum (project_time) as project_time from all_project where user_name='" + Label3.Text + "'and department='" + Label4.Text + "'", conn);
                    conn.Open();
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.Read())
                    {
                        string time = dr1["project_time"].ToString();
                        double time1 = Convert.ToDouble(time);
                        Label5.Text = Math.Round(time1 / 60, 1).ToString();
                        Label6.Text = Math.Round(time1 / 60 / 8, 1).ToString();
                    }
                    conn.Close();
                    Databind();
                }

            }
            foreach (Control item in form1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Attributes.Add("autocomplete", "off");
                    ((TextBox)item).Attributes.Add("readonly", "True");
                    input.Attributes.Remove("readonly");
                }
            }
        }
    }
    public void Databind()
    {
        if (Session["user_name"] == null)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('请重新登录！');location ='login.aspx';</script>");
        }
        else
        {
            string user_name = Session["user_name"].ToString();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlCommand cmd = new SqlCommand("select * from all_project where " + DropDownList1.Text + " like '%" + input.Text.Trim() + "%'and user_name='" + user_name + "'", conn);
            conn.Open();
            SqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                conn.Close();
                DataTable dt1 = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }
            else
            {
                input.Text = "";
                Databind();
                ClientScript.RegisterStartupScript(this.GetType(), "js", "<script>alert('查询有误或没有查到想要的信息，请重新查询!')</script>");
            }
        }
    }
    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Databind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (input.Text.Trim() != "")
        {
            Databind();
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
        conn.Open();
        SqlDataReader dr1 = cmd.ExecuteReader();
        if (dr1.Read())
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
        conn.Close();
        foreach (Control item in form1.Controls)
        {
            if (item is TextBox)
            {
                ((TextBox)item).Attributes.Add("readonly", "False");
            }
        }
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
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                Label2.Text = dr1["project_time"].ToString() + "分钟";
            }
            conn.Close();
            Databind();
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