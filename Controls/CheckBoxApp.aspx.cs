using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckBoxApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        string msg = "";

        if (chkCs.Checked)
            msg += chkCs.Text + " ";
        if (chkVb.Checked)
            msg += chkVb.Text + " ";
        if (chkJava.Checked)
            msg += chkJava.Text + " ";

        msg += "를 좋아하시는군요...";
        lblResult.Text = msg;
    }
}