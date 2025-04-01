using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RadioButtonApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        string msg = "";

        if (rdoCs.Checked)
            msg += rdoCs.Text + " ";
        else if (rdoVb.Checked)
            msg += rdoVb.Text + " ";
        else
            msg += rdoJava.Text + " ";

        msg += "를 좋아하시는군요..";

        lblResult.Text= msg;
    }
}