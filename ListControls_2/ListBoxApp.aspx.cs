using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListBoxApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            for(int i=1; i<5; i++)
            {
                ListBox2.Items.Add(new ListItem(i + ".리스트 항목", i.ToString()));
            }
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {

        if (ListBox2.SelectedIndex != -1)
            lblResult1.Text = ListBox1.SelectedItem.Value;
        else
            lblResult1.Text = "";


            foreach (ListItem item in ListBox2.Items)
            {
                if (item.Selected)
                {
                    lblResult2.Text += item.Value + " ";
                }
            }
    }
}