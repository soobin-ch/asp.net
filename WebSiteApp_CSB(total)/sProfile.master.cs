using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sProfile : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ibtnProfile_Click(object sender, ImageClickEventArgs e)
    {
        //프로필 페이지로 이동
        Response.Redirect("Profile.aspx");
    }

    protected void ibtnNotice_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("boardlist.aspx");
        //공지사항 목록 페이지로 이동

    }

    protected void ibtnMap_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("map.aspx");
        //맵 페이지 이동

    }
}
