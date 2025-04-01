using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("브라우저 정보 : " + Request.Browser.Browser + " " +
            Request.Browser.Version.ToString() + "<br>");
        Response.Write("클라이언트 IP주소 : " + Request.Url + "<br>");
        Response.Write("전체 url : " + Request.Url + "<br>");
        Response.Write("가상 디렉토리 : " + Request.ApplicationPath + "<br>");
        Response.Write("물리적 디렉토리 : " + Request.PhysicalApplicationPath + "<br>");

           
    }
}