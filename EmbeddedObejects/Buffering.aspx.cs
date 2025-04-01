using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Buffering : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("1.Buffer는 HTTP Response 의 일시 저장 기능 제공 <br> ");
        Response.Write("2.Buffer의 목적은 속도 차이로 인한 문제를 해결하기 위함 <br> ");
        Response.Write("3.Response.flush()는 버퍼 내용을 client로 전송 <br> ");
        Response.Flush();
        Response.Write("4.Buffer내용을 삭제하려면 Response.Clear() 실행 <br> ");
        Response.Clear();
        Response.Write("5.Response.flush()는 버퍼 내용을 client로 전송 <br> ");
        Response.Flush();
        Response.Write("6.Buffer 내용을 전송하고 종료하려면, Response.End() 실행  <br> ");
       
    }
}