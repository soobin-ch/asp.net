using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PostBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Label1.Text = "처음으로 오셨군요...";
        }else
        {
            Label1.Text = "포스팅백으로 다시 오셨군요...";
        }


    }
}