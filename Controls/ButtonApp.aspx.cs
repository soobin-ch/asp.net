using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ButtonApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        lblOutput.Text = "표준 버튼을 클릭하셨군요.";
    }


    protected void lbtnOk_Click(object sender, EventArgs e)
    {
        lblOutput.Text = "링크 버튼을 클릭하셨군요.";
    }


    protected void ibtnOk_Click(object sender, ImageClickEventArgs e)
    {
        lblOutput.Text = "이미지 버튼을 클릭하셨군요.";
    }
}