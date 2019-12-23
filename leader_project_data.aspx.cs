using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leader_project_data : System.Web.UI.Page
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
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        string department = Session["department"].ToString();
        SqlCommand cmd = new SqlCommand("select sum (project_time) as project_time from all_project where user_name='" + this.DropDownList2.SelectedValue + "'and department='" + department + "'", conn);
        conn.Open();
        SqlDataReader dr1 = cmd.ExecuteReader();
        if (dr1.Read())
        {
            string time = dr1["project_time"].ToString();
            double time1 = Convert.ToDouble(time);
            TextBox4.Text = Math.Round(time1 / 60, 1).ToString();
            TextBox5.Text = Math.Round(time1 / 60 / 8, 1).ToString();
        }
        conn.Close();
    }

}