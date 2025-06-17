using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pollresult : System.Web.UI.Page
{
    //모듈변수
    static PollDo pDo;

    protected void Page_Load(object sender, EventArgs e)
    {
        //처음에 접속할 때 실행
        if (!IsPostBack)
        {
            // 비정상적인 접속에 대한 처리
            if (Session["userid"] == null) return;
            if (Request["no"] == null) return;

            // 설문번호를 Url에서 추출함
            int qId = int.Parse(Request["no"]);

            // 설문과 선택항목번호를 가져옴
            pDo = (new PollDao()).GetPollDetails(qId);

            // 설문 내용 표시
            lblQuestion.Text = pDo.Qcontents;

            // GridView DataSource
            grvOptions.DataSource = pDo.DsOptions;
            grvOptions.DataBind();

            // 아래 label영역에 조회수 표시
            lblTotalHits.Text = pDo.TotalVotes.ToString();

            // label 영역에 설문기간 표시
            lblDuration.Text = DateTime.Parse(pDo.Uploaddate.ToString()).ToShortDateString() +
                               "~" + DateTime.Parse(pDo.Duedate.ToString()).ToShortDateString();

            // 설문 요청자
            lblDemander.Text = pDo.Nickname + "(" + pDo.Demander + ")";
        }
    }

    //디자인 소스에서 사용하는 메서드, Bar.jpg의 폭을 결정
    public int GetGraphWidth(object hits)
    {
        //해당 선택항목의 응답수
        return this.GetPercent(hits) * 4;
    }

    //디자인 소스에서 사용하는 메서드, 응답의 백분율 계산
    public int GetPercent(object hits)
    {

        int iCnt = (int)hits;

        // 반환할 백분율을 0%라 가정
        int iVal = 0;

        // 응답이 존재하면 백분율 계산
        if (iCnt != 0)
            iVal = (int)((double)iCnt / pDo.TotalVotes * 100);

        // 리턴
        return iVal;

    }

    protected void ibtnList_Click(object sender, ImageClickEventArgs e)
    {
        //목록으로 이동
        Response.Redirect("polllist.aspx");
    }
}