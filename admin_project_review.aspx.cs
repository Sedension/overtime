using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class admin_book : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                 databind();
            }
    }

    public void databind()
    {
        SqlConnection conn = new SqlConnection("SERVER=47.100.164.196;DATABASE=overtime1;PWD=1;UID=sa;");  //创建一个数据库连接
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

}