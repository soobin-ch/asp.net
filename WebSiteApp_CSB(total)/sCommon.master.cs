using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sCommon : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ibtnProfile_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("profile.aspx");
    }

    protected void ibtnNotice_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("UnderConstruction.aspx");
    }


    protected void ibtnMap_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("UnderConstruction.aspx");
    }
}
