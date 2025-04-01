using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Certificate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = (string)Session["id"];
        string name = (string)Session["name"];

        Response.Write("현재 " + id + "(" + name + ")님이 접속중입니다.");
    }
}