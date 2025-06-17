using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["userid"] == null)
            {
                ibtnToggle.ImageUrl = "~/images/mLogin.jpg";
                lblLogin.Text = "로그인해 주세요...";
            }else
            {
                ibtnToggle.ImageUrl = "~/images/mLogout.jpg";
                MemberDao mDao = new MemberDao();
                lblLogin.Text = mDao.GetNickname(Session["userid"].ToString()) + "님 반갑습니다.";
                ibtnMemberRevise.Visible = true;

            }
        }
    }

    protected void ibtnProfile_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("profile.aspx");
    }

    protected void ibtnStudy_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ictnews.aspx");
    }

    protected void ibtnBbs_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PollList.aspx");
    }

    protected void ibtnDiary_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("underconstruction.aspx");
    }

    protected void ibtnGallery_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("albumlist.aspx?id=3");
    }

    protected void ibtnAttend_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Attend.aspx");
    }

    protected void ibtnToggle_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["userid"] == null)
        {
            Response.Redirect("Login.aspx");
        }else
        {
            Session["userid"] = null;
            ibtnToggle.ImageUrl = "~/images/mLogin.jpg";
            lblLogin.Text = "로그인해 주세요...";
        }
    }

    protected void ibtnHome_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("profile.aspx");
    }

    protected void ibtnMemberRivise_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ChangeUserInfo.aspx");
    }
}
