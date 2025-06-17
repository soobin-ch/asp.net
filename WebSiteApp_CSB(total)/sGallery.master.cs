using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sGallery : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ibtnMyPhoto_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("albumlist.aspx?id=1");
        //내사진 페이지로 이동, 추후 수정

    }

    protected void ibtnCampusLife_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("albumlist.aspx?id=2");
        //대학생활 페이지로 이동, 추후 수정

    }

    protected void ibtnScenery_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("albumlist.aspx?id=3");
        //풍경사진 페이지로 이동, 추후 수정

    }
}
