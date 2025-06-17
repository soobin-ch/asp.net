using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pollwrite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //처음 들어오는 경우에는 캘린더의 선택일을 현재일로
        if (!IsPostBack)
        {
            // 비정상 접속 체크
            if (Session["userid"] == null) return;

            // 종료일 선택을 위한 캘린더에 오늘 날짜 표시
            Calendar1.SelectedDate = DateTime.Now.AddDays(7);

            // 쓰기 버튼 활성화
            ibtnWrite.Visible = true;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //선택항목에 입력되어 있지 않으면 리턴
        if (txtOption.Text == "")
        {
            lblMessage.Text = "선택항목의 내용을 입력하세요.";
            return;
        }

        // 선택항목 추가
        lbxOptions.Items.Add(txtOption.Text);

        // 다음입력을 위해 TextBox 지움
        txtOption.Text = "";
        txtOption.Focus();
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        //항목이 선택되지 않았으면 , 리턴
        if (lbxOptions.SelectedIndex < 0)
        {
            lblMessage.Text = "수정할 항목을 선택해주세요.";
            return;
        }

        // 선택항목 수정을 위해 새로운 항목 입력
        lbxOptions.Items.Insert(lbxOptions.SelectedIndex, txtOption.Text);

        // 기존 항목 삭제
        lbxOptions.Items.Remove(lbxOptions.SelectedItem);

        // 다음 입력을 위해 TextBox 지우고
        txtOption.Text = "";
        txtOption.Focus();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //항목이 선택되지 않았으면 리턴
        if (lbxOptions.SelectedIndex < 0)
        {
            lblMessage.Text = "삭제할 항목을 선택해주세요.";
            return;
        }

        // ListBox의 항목을 삭제함
        lbxOptions.Items.Remove(lbxOptions.SelectedItem);

        // 다음 입력을 위해 TextBox 지우고
        txtOption.Text = "";
        txtOption.Focus();
    }

    protected void lbxOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ListBox에서 선택한 항목을 TextBox에 표시
        txtOption.Text = lbxOptions.SelectedItem.Value;

    }

    protected void ibtnWrite_Click(object sender, ImageClickEventArgs e)
    {
        if (lbxOptions.Items.Count < 0)
        {
            lblMessage.Text = "선택항목을 입력해 주세요";
            return;
        }

        // options DbMan에 전달하기 위한 string[] 배열 선언
        string[] options = new string[lbxOptions.Items.Count];
        for (int i = 0; i < lbxOptions.Items.Count; i++)
            options[i] = lbxOptions.Items[i].ToString();

        // 입력을 위한 자료를 PollDo 클래스에 전달하여 입력 처리
        // 설문입력용 생성자
        // public PollDo(string qcontents, bool selectionmode, string demander, string duedate)
        PollDo pDo = new PollDo(
            txtQuestion.Text,
            (rdoOpt.SelectedIndex == 0),
            Session["userid"].ToString(),
            Calendar1.SelectedDate.ToShortDateString()
        );

        // 설문입력 처리
        (new PollDao()).InsertPoll(pDo, options);

        // 목록페이지로 이동
        Response.Redirect("polllist.aspx");
    }

    protected void ibtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        //목록페이지로 이동
        Response.Redirect("polllist.aspx");

    }

}