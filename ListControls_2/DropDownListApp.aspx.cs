using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DropDownListApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            for(int i=1; i<10; i++)
            {
                DropDownList1.Items.Add(new ListItem(i + ".리스트 항목", i.ToString()));
            }
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        string str = DropDownList1.SelectedItem.Value;
        lblResult1.Text = "선택된 항목 : " + str;
        str = DropDownList1.SelectedIndex.ToString();
        lblResult2.Text = "선택된 지수 :" + str;
    }
}