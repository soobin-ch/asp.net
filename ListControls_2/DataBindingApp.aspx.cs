using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataBindingApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string[] arr = { "1. ASP", "2.C/C++/C#", "3.VB.NET" };
            ListBox1.DataSource = arr;
            ListBox1.DataBind();
        }
    }

    protected void brnOk_Click(object sender, EventArgs e)
    {
        lblResult.Text = "선택항목 : " + ListBox1.SelectedItem.Value;
    }
}