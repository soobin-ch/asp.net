using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ImageMenuApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ibtnMenu_Click(object sender, ImageClickEventArgs e)
    {
        string msg = String.Format("좌표: ({0},{1}) / 메뉴 : ", e.X, e.Y);

        if (e.X < 97)
            msg += "[대학소개]";
        else if (e.X < 185)
            msg += "[입학안내]";
        else if (e.X < 270)
            msg += "[학과안내]";
        else if (e.X < 357)
            msg += "[학사안내]";
        else
            msg += "[대학생활]";
        lblOutput.Text = msg;
    }
}