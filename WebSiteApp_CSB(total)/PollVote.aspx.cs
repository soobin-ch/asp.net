using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; //DataTable, DataRow 이용

public partial class pollvote : System.Web.UI.Page
{
    //모듈변수 선언
    static PollDo pDo;

    protected void Page_Load(object sender, EventArgs e)
    {
        //처음 여기로 들어올때만 수행되어야 하는 코드
        if (!IsPostBack)
        {
            // 비정상 접속에 대한 조치
            if (Session["userid"] == null) return;
            if (Request["no"] == null) return;

            // 이미지버튼 활성화
            ibtnVote.Visible = true;
            ibtnResult.Visible = true;

            // 설문번호를 Url에서 추출함
            int qId = int.Parse(Request["no"]);

            // 설문과 선택항목 번호를 가져옴
            pDo = (new PollDao()).GetPollDetails(qId);

            // 설문 내용 및 현재까지의 설문 참가자수 표시
            lblQuestion.Text = pDo.Qcontents;
            lblTotalVotes.Text += pDo.TotalVotes.ToString();

            // 설문이 단일선택인지, 복수선택인지에 따라 RadioButtonList/CheckBoxList 중 선택
            if (pDo.Selectionmode)
            {
                // 단일선택
                rdoOptions.Visible = true;
                chkOptions.Visible = false;

                // 모든 요소를 순회하며 선택항목으로 추가
                DataTable dt = pDo.DsOptions.Tables["options"];
                foreach (DataRow row in dt.Rows)
                {
                    rdoOptions.Items.Add(new ListItem(
                        row["option"].ToString(),
                        row["optId"].ToString()
                    ));
                }
            }
            else
            {
                // 다중선택
                rdoOptions.Visible = false;
                chkOptions.Visible = true;

                // 모든 요소를 순회하며 선택항목으로 추가
                DataTable dt = pDo.DsOptions.Tables["options"];
                foreach (DataRow row in dt.Rows)
                {
                    chkOptions.Items.Add(new ListItem(
                        row["option"].ToString(),
                        row["optId"].ToString()
                    ));
                }
            }
        }
    }

    protected void ibtnVote_Click(object sender, ImageClickEventArgs e)
    {
        int optId;

        // 본 설문에 대해 응답을 한 적이 있는지 확인
        if ((new PollDao()).IsVoted(pDo.Qid, Session["userid"].ToString()))
        {
            lblMessage.Text = "본 설문에 대해 이미 참여하였습니다.";
            return;
        }

        if (pDo.Selectionmode)
        {
            // RadioButtonList로 부터 선택된 옵션번호를 가져와서 히트수 증가
            // Option 번호는 항복의 Value 속성에 저장되어 있음
            optId = int.Parse(rdoOptions.SelectedValue.ToString());
            (new PollDao()).UpdateVote(pDo.Qid, optId); // pollOptions 테이블에 히트수 증가
            
    }
        else
        {
            // CheckBoxList로부터 복수 선택된 옵션항목을 가져와서 히트수 증가
            // 다중 선택이 가능하므로 모든 옵션을 순회하며 체크여부 확인 필 요
            // Option 번호는 항목의 Value 속성에 저장
            foreach (ListItem item in chkOptions.Items)
                if (item.Selected) //
                {
                    optId = int.Parse(item.Value.ToString());
                    (new PollDao()).UpdateVote(pDo.Qid, optId); // pollOptions O
                }
        }

    // 설문조사에 응한 사용자에 userid 등록 --> 중복 응답 방지
            (new PollDao()).InsertVotedUser(pDo.Qid, Session["userid"].ToString());

                // 목록 페이지로 이동
                Response.Redirect("polllist.aspx");
        
    }

    protected void ibtnResult_Click(object sender, ImageClickEventArgs e)
    {
        //결과보기 페이지로 이동
        Response.Redirect("pollResult.aspx?no=" + pDo.Qid);
    }

    protected void ibtnList_Click(object sender, ImageClickEventArgs e)
    {
        //목록 페이지로 이동
        Response.Redirect("polllist.aspx");
    }
}