using System;
using System.Web.Security;

public partial class leader_menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            Response.Write("<script>alert('请重新登录！');location.href='Login.aspx';</script>");
        }
        else
        {
            Label1.Text = Session["user_name"].ToString();
        }

    }
    protected void loginOut(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("~/login.aspx");
    }
}