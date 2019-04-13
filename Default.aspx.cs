using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            {
                databind();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Write("<script>function on(){ document.getElementById('light').style.display='block';}</script>");
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>on();</script>");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "onclick", "<script>on();</script>");
    }
}