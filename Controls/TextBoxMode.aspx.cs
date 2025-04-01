using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TextBoxMode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtInput.Focus();
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        txtResult.Text += txtInput.Text + "\n";
        txtInput.Text = "";
        txtInput.Focus();
    }

}