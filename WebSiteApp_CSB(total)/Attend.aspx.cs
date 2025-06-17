using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class attend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //출석부 목록을 보여 줌 (첫 화면)
        DisplayNoteList();
    }

    // 사용자 정의 메서드(메서드 오버로딩 이용)
    // 출석부(한줄게시판) 목록 : 페이지 로드 혹은 새로운 출석부 입력
    // 사용자 정의 메서드 (메서드 오버로딩 이용)
    // 출석부(한줄게시판) 목록 : 페이지 로드 혹은 새로운 출석부 입력 참조 2개
    private void DisplayNoteList()
    {
        // 데이터셋에 정보를 가져와서 그리드뷰에 출력, 임시객체(Anonymous Object)를 이용 코드 절감
        grvAttend.DataSource = (new NotesDao()).GetNotesList();
        grvAttend.DataBind();
    }

    // 출석부(한줄게시판)의 목록: 페이지만 변경한 경우에 해당
    // 데이터가 수시로 변한다면, 페이지 변경시마다 목록을 불러옴
    // 입력(int): 새로운 페이지 번호 참조 1개
    private void DisplayNoteList(int iPage)
    {
        // 데이터셋에 정보를 가져옴 --> 데이터의 입력이 자주 일어날 경우 목록 갱신
        // grvAttend.DataSource = =(new NotesDao()).GetNotesList();

        // 새로운 페이지 번호 지정
        grvAttend.PageIndex = iPage;
        grvAttend.DataBind();
    }

    // 그리드뷰의 페이지를 변경할 때의 동작 참조 0개
    protected void grvAttend_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // 새로운 페이지 번호를 전달하여 목록 출력
        DisplayNoteList(e.NewPageIndex);
    }

    // 저장 버튼을 누를 때의 동작 참조 0개
    protected void btnWrite_Click(object sender, EventArgs e)
    {
        // 로그인 안되면 저장 못함. 보통의 경우 로그인하지 않은 상태에서는 저장 버튼을 숨기나,
        // 출석부에서는 글입력을 장려하기 위해 버튼을 숨기지 않음
        if (Session["userid"] == null)
        {
            txtContents.Text = "글을 쓰시려면 로그인 해 주세요...";
            return;
        }

        // 데이터 전달을 위한 NoteDo 객체 생성
        NoteDo mDo = new NoteDo(Session["userid"].ToString(), txtContents.Text);

        // NotesDao 객체를 생성하여 입력 처리 --> 임시 객체 이용
        (new NotesDao()).InsertNotes(mDo);

        // 입력이 끝나면, 텍스트박스를 비우고. 출석부의 새 목록을 보여줌
        txtContents.Text = "";
        DisplayNoteList();
    }

}