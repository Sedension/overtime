﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_personnel_insert : System.Web.UI.Page
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
        SqlCommand cmd = new SqlCommand("insert into all_personnel values ('" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + DropDownList3.Text + "')", conn);
        SqlCommand cmd1 = new SqlCommand("insert into all_user values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList3.Text + "')", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        conn.Close();
        Response.Write("<script>alert('添加成功')</script>");
    }
}