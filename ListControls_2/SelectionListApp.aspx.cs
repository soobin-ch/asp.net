using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelectionList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedIndex !=-1)
        {
            lblRadio.Text = RadioButtonList1.SelectedItem.Value;
        }
    }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCheck.Text = "";
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected)
                lblCheck.Text += item.Value + " ";
        } 
    }
}