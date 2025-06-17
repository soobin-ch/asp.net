using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class boardlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //로그인이 되어 있지 않은 경우 글을 작성할 수 없음.
        //일반적으로 공지사항의 경우 관리자 권한이 아니면 글을 작성할 수 없음
        //글쓰기 버튼은 초기에 Visible 속성이 False로 되어 있음

        //게시판 목록 보이기
        if (Session["userid"] != null)
        {
            string userid = Session["userid"].ToString().Trim();


            if ((new MemberDao()).GetUgradeOfUserid(Session["userid"].ToString().Trim()) >=
           (new MemberDao().GetUgradeOfGradename("관리자")))
            {
                int userGrade = (new MemberDao()).GetUgradeOfUserid(userid);
                lblMessage.Text = "현재 로그인한 사용자 등급" + userGrade + "현재 로그인한 사용자 ID: [" + userid + "]";
                ibtnWrite.Visible = true;

            }
        }

        // 로그인이 된 경우 글쓰기를 허용
        // ibtnWrite.Visible = true;

        // 로그인한 사용자가 관리자 등급일 경우 글쓰기 허용
       

        // 게시판 목록 보이기
        DisplayBoardList();
    }

    //게시판 목록 보이기
    //일반적으로 공자사항의 경우 자료의 업데이트가 자주 일어나지 않으므로 매번 목록을 가져올 필요는 없음
    private void DisplayBoardList()
    {
        //데이터셋 형식으로 정보를 가져와서 그리드뷰의 소스로 지정
        grvBoard.DataSource = (new BoardDao()).GetBoardList();
        grvBoard.DataBind();

    }

    //만약에 자료가 자주 변경되는 용도로 사용한다면, 다음 메서드 이용
    //현재는 사용하지 않음
    private void DisplayBoardList(int iPage)
    {
        //데이터셋 형식으로 정보를 가져와서 그리드뷰의 소스로 지정

        //지정된 페이지로 이동
        grvBoard.DataSource = (new BoardDao()).GetBoardList();
        // 지정된 페이지로 이동
        grvBoard.PageIndex = iPage;
        grvBoard.DataBind();
    }

    //GetShowUrl() --> 제목을 클릭하면 이동하여야 할 Url을 제공
    //boardshow.aspx 페이지를 호출하되, 글번호 no를 추가
    //로그인된 경우에만 상세보기를 허용한다면 다름의 메서드 이용
    public string GetShowUrl(object no)
    {

        if (Session["userid"] == null)
        // 문법 오류 포함 원문 유지
        {
            lblMessage.Text = "글 내용을 읽으려면 로그인 하세요..";
            return null;
        }
        else
        {

            return "boardshow.aspx?no=" + no;
        }


        }

    protected void ibtnWrite_Click(object sender, ImageClickEventArgs e)
    {
        //글쓰기 페이지(boardWrite.aspx)로 이동하기
        //권한의 문제는 Page_Load()에서드에서 처리하였으므로 이곳에서는 페이지 이동만 구현하면 됨
     

        // 글쓰기 페이지로 이동
        Response.Redirect("boardwrite.aspx");
    }

    protected void grvBoard_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //글의 목록이 자주 변경되지 않는다면

        //글의 목록이 자주 변경된다면
        grvBoard.PageIndex = e.NewPageIndex;
        grvBoard.DataBind();
    }
}