using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sBbs : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ibtnFree_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("UnderConstruction.aspx");
        //자유게시판 페이지로 이동

    }

    protected void ibtnQnA_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("UnderConstruction.aspx");
        //Q&A 게시판 페이지로 이동

    }

    protected void ibtnPoll_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("PollList.aspx");
        //설문목록페이지로 이동

    }

    protected void ibtnMessage_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("UnderConstruction.aspx");
        //메시지 목록 페이지로 이동

    }
}
