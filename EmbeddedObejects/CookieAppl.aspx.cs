using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CookieAppl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        HttpCookie cookieDate = Request.Cookies["lastVisit"];

        if(cookieDate != null)
        {
            lblTitle.Text = "최종 접속 시간 :" + HttpUtility.UrlDecode(cookieDate.Value);
        }
        else
        {
            lblTitle.Text = "처음 방문하셨군요";
        }
        Response.Cookies["lastVisit"].Value = HttpUtility.UrlEncode(DateTime.Now.ToString());

    }
}