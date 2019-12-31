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
            if (Session["user_name"] == null)
            {
                Response.Write("<script>alert('请重新登录！');location.href='Login.aspx';</script>");
            }
            else Databind();
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
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        SqlCommand cmd = new SqlCommand("select * from all_project where " + DropDownList1.Text + " like +'%'  + @UserName +'%'", conn);
        cmd.Parameters.Add(new SqlParameter("@UserName", input.Text.Trim()));
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
        Databind();
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>close();</script>");
        input.Attributes.Remove("readonly");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>close();</script>");
        input.Attributes.Remove("readonly");
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
        Databind();
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>close();</script>");
        input.Attributes.Remove("readonly");
    }
}
