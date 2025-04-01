using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PasswordApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (txtPassword.Text == txtPasswordConfirm.Text)
            lblOutput.Text = "입력한 암호 일치!";
        else
            lblOutput.Text = "입력한 암호 불일치!";
    }
}