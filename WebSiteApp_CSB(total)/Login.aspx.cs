using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 나를 호출한 페이지 조사
            if (Request.UrlReferrer != null)
            {
                // 로그인 페이지를 호출한 위치 기록 
                // --> 로그인 성공 후 해당 페이지로 이동하기 위함
                // Session["returnUrl"] = Request.UrlReferrer.ToString();

                // 그런데, 회원가입, Id찾기, pw 재설정, 정보변경 등을 처리한 후에는 
                // 그보다 더 이전의 페이지로 이동하여야 함.

                string caller = Request.UrlReferrer.ToString().ToLower();

                bool isMemberRelatedPage =
                    caller.IndexOf("register.aspx") >= 0 ||
                    caller.IndexOf("finduserid.aspx") >= 0 ||
                    caller.IndexOf("setnewpasswd.aspx") >= 0 ||
                    caller.IndexOf("modifyuserinfo.aspx") >= 0;

                if (!isMemberRelatedPage)
                {
                    Session["returnUrl"] = caller;
                    Response.Write(caller);
                }
            }

        }

    

        }

    protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        MemberDao mDao = new MemberDao();
        if(mDao.Authenticate(txtId.Text, txtPasswd.Text))
        {
            Session["userid"] = txtId.Text;
            Response.Redirect(Session["returnUrl"].ToString());
        }else
        {
            lblMessage.Text = "사용자 id 와 암호를 확인해 주세요..";
        }
    }
    protected void ibtnRegister_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("register.aspx");

    }

    protected void lbtnFinfId_Click(object sender, EventArgs e)
    {
        //아이디찾기 페이지로 이동
        Response.Redirect("findUserId.aspx");
    }

    protected void lbtnSetNewPw_Click(object sender, EventArgs e)
    {
        //비밀전호 재설정 페이지로 이동
        Response.Redirect("setNewPasswd.aspx");
    }
}