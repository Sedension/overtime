using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class leader_personnel : System.Web.UI.Page
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
        }
    }
    public void Databind()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        string department = Session["department"].ToString();
        SqlCommand cmd = new SqlCommand("select * from all_personnel where " + DropDownList1.Text + " like +'%'  + @UserName +'%' and department='" + department + "'", conn);
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
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Databind();
    }
    protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;  //GridView编辑项索引等于单击行的索引
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
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        string user_id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string user_name = (GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox).Text.Trim();
        string position = (GridView1.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox).Text.Trim();
        string department = (GridView1.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox).Text.Trim();
        SqlCommand cmd = new SqlCommand("update all_personnel set user_name='" + user_name + "',position='" + position + "', department='" + department + "'where user_id=" + user_id + "", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        GridView1.EditIndex = -1;
        Databind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        string user_id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        SqlCommand cmd = new SqlCommand("delete from all_personnel where user_id=" + user_id + " delete from all_user where user_id= " + user_id + "", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Databind();
    }
}