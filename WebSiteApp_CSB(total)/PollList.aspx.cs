using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class polllist : System.Web.UI.Page
{
    //모듈변수
    string kword = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
                ibtnInsertPoll.Visible = true;
        }

        // 로그인 되었으면 설문작성 버튼 활성화
       

        // 과제. 관리자 등급 혹은 프리미엄 등급만 설문을 추가할 수 있게 하려면?

        // 질문 목록을 화면에 표시
        DisplayQuestionList();
    }

    //질문목록 구현 - Page_Load()에서 호출
    private void DisplayQuestionList()
    {
        this.DisplayQuestionList(null, 0);
    }

    //질문목록 구현 - 검색기능과 페이지 기능 있음
    private void DisplayQuestionList(string kword, int iPage)
    {
        grvQuestions.DataSource = (new PollDao()).GetPollQuestionList(kword);

        // 페이지 번호에 따른 처리
        grvQuestions.PageIndex = iPage;

        // 데이터바인딩
        grvQuestions.DataBind();
    }

    //투표하기 페이지 호출 Url-> 디자인 소스에서 요구하는 메서드
    public string GetVoteUrl(object qId)
    {


        string sResult = null;

        // 로그인되어있지 않으면 투표 못함
        if (Session["userid"] == null)
        {
            lblMessage.Text = "참여하려면 로그인이 필요합니다.";
        }
        else
        {
            // 투표종료일 확인, 날짜가 지나지 않았으면 투표페이지로 이동
            if ((new PollDao()).ConfirmDueDate((int)qId))
                sResult = "pollVote.aspx?no=" + qId.ToString();
        }

        // 실행결과 반환
        return sResult;


       
    }

    //투표하기 버튼 이미지 생성 => 디자인소스에서 요구하는 메서드
    public string GetVoteFig(object qId)
    {
        //투표종료일 확인, 진행중 : 투표 버튼, 종료사 : 종료 버튼
        if ((new PollDao()).ConfirmDueDate((int)qId))
            return "images/bbsVote.jpg";
        else
            return "images/bbsFinish.jpg";

    }

    //결과보기 페이지 호출 Url -> 디자인 소스에서 요구하는 메서드
    public string GetResultUrl(Object qId)
    {
        //로그인되어있지 않으면 투표 못함

        // 로그인되어있지 않으면 투표 못함
        if (Session["userid"] == null)
        {
            lblMessage.Text = "참여하려면 로그인이 필요합니다.";
            return null;
        }
        else
        {
            // 로그인되어있어 결과보기 페이지로 이동
            return "pollResult.aspx?no=" + qId.ToString();
        }



    }

    protected void ibtnInsertPoll_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("pollWrite.aspx");
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        //키워드가 없으면 검색을 수행하지 않으며
        //키워드가 있을떄 검색을 수행함

        //마지막 키워드가 존재하면 검색을 수행하여 결과를 표시함. 검색 후에는 첫 페이지로 이동(iPage=0)
        if (txtKword.Text != "")
            kword = txtKword.Text;

        // 마지막 키워드가 존재하면 검색을 수행하여 결과를 표시함.
        // 검색 후에는 첫 페이지로 이동(iPage = 0)
        this.DisplayQuestionList(kword, 0);
    }

    protected void grvQuestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //검색 키워드와 페이지 번호를 이용하여 화면에 결과를 표시
        this.DisplayQuestionList(kword, e.NewPageIndex);
    }
}