using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class findUserId : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
      
        string id;

        // 사용자 ID를 가져와서 결과에 따라 조치를 취함
        // MemberDao 객체는 오로지 한번만 수행함. 코드를 줄이기 위해 객체를 생성함과 동시에 곧바로 메서드 호출함 ==> 임시 객체 (Anonymous Object)

        // MemberDao mDao = new MemberDao();
        // if (mDao.FindUserId(txtName.Text, txtPhone.Text, out id))

        if ((new MemberDao()).FindUserId(txtName.Text, txtPhone.Text, out id))
            lblResult.Text = txtName.Text + " 님의 id는 " + id + " 입니다.";
        else
            lblResult.Text = txtName.Text + " 님의 id를 찾지 못했습니다.";
    
}

protected void btnCancel_Click(object sender, EventArgs e)
    {
        //로그인 페이지로 이동
        Response.Redirect("login.aspx");
    }
}