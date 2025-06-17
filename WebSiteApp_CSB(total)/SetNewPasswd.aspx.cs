using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class setNewPasswd : System.Web.UI.Page
{
    //비밀번호 변경을 위한 본인 인증여부
    static bool isAuthen = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 생년월일 드롭다운리스트의 항목값 부여
            int currentYear = DateTime.Now.Year;
            int i;

            for (i = 1901; i <= currentYear; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString()));
            }

            // 연도에는 금년이 기본 선택되도록 함
            ddlYear.SelectedIndex = i -1901 -1;

            // 월 표시
            for (i = 1; i <= 12; i++)
            {
                ddlMonth.Items.Add(new ListItem(i.ToString()));
            }

            // 1월을 기본 선택
            ddlMonth.SelectedIndex = 0;

            // 1월에 해당하는 날짜 표시
            SetDate(ddlMonth.SelectedIndex);
        }
    }


    //사용자 정의 함수 --> 회원가입에서의 코드와 비교해 볼 것
    private void SetDate(int iMonth)
    {
        int dayMax;
        switch (iMonth + 1)
        {
            case 2:
                dayMax = 29;
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                dayMax = 30;
                break;
            default:
                dayMax = 31;
                break;
        }

        // 일에 해당하는 드롭다운리스트 항목 결정
        ddlDay.Items.Clear();
        for (int i = 1; i <= dayMax; i++)
        {
            ddlDay.Items.Add(new ListItem(i.ToString()));
        }
    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetDate(ddlMonth.SelectedIndex);
    }

    protected void btnAuthenticate_Click(object sender, EventArgs e)
    {
        if (txtId.Text.Length > 0 && txtName.Text.Length > 0)
        {
            // 익명 객체 활용 → 본인 인증 수행
            bool isValid = (new MemberDao()).AuthenticateToSetNewPasswd(
                txtId.Text,
                txtName.Text,
                ddlYear.Text + "-" + ddlMonth.Text + "-" + ddlDay.Text
            );

            if (isValid)
            {
                isAuthen = true;
                lblResult.Text = "본인 인증에 성공하였습니다.";
            }
            else
            {
                lblResult.Text = "본인 인증에 실패하였습니다.";
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //로그인 페이지로 이동
        Response.Redirect("login.aspx");
    }

    protected void SetPasswd_Click(object sender, EventArgs e)
    {
        if (!isAuthen)
        {
            lblResult.Text = "먼저 본인 인증을 실시해 주세요.";
            return;
        }

    // 사용자 비밀번호 변경
    (new MemberDao()).SetNewPasswd(txtId.Text, txtPw1.Text);

        // 비밀번호 변경 성공 → 로그인 페이지로 이동
        Response.Redirect("login.aspx");
    }
}