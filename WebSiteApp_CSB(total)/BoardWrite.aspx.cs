using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class boardwrite : System.Web.UI.Page
{
    //모듈변수 --> 클래스 전체에서 사용하는 변수
    int no;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 주소를 직접 입력하고 들어오는 경우를 대비하여 점검
            // 사용자가 로그인 되어 있지 않으면 로그인페이지로 이동
            if (Session["userid"] == null)
                Response.Redirect("login.aspx");

            // 로그인한 사용자가 관리자 등급이 아닐 경우 목록페이지로 이동
            // 만약에 로그인만 점검한다면 아래 코드는 주석으로 처리할 것.
            if (!(new MemberDao()).CheckAuth(Session["userid"],
             (new MemberDao().GetUgradeOfGradename("관리자"))))
            {
                Response.Redirect("boardlist.aspx");
            }


            if (Request["no"] != null)
            {
                int no = int.Parse(Request["no"].ToString());

                BoardDao dao = new BoardDao();
                BoardDo curPost = dao.GetBoardDetails(no);

                if (curPost == null)
                {
                    Response.Write("<script>alert('해당 게시글을 찾을 수 없습니다.'); history.back();</script>");
                    return;
                }

                // 기존 내용 채워넣기
                txtTitle.Text = curPost.Title;
                txtContents.Text = curPost.Contents;

                if (Session["path"] != null)
                {
                    // 첨부파일이 저장되는 path 구하기
                    // string path = Request.PhysicalApplicationPath + "\\Notice\\notice_" + no.ToString() + mDo.Filename.Substring(mDo.Filename.IndexOf("."));
                    string path = Request.PhysicalApplicationPath + "\\" + Session["path"].ToString();

                    // 해당 위치에 파일이 존재하는 경우, 파일 삭제
                    // 이 작업을 위해서는 네임스페이스 using System.IO; 추가
                    if (File.Exists(path))
                      Response.Write("파일첨부 존재함");

                    // Session 변수 삭제
                    Session["path"] = null;
                    Session["fname"] = null;
                }
                txtId.Text = curPost.Author;
                ViewState["no"] = no;  // 저장 시 수정 모드 판단용
            }

            // 접속하게 되면 로그인한 사용자의 id를 TextBox에 표시함
            txtId.Text = Session["userid"].ToString().Trim();
        }

    }

    //FileUpload1 컨트롤에서 가져온 전체경로에서 파일이름만 추출
    private string GetFileName(string path)
    {

        return path.Substring(path.LastIndexOf(@"\") + 1);
    }

    protected void ibtnWrite_Click(object sender, ImageClickEventArgs e)
    {

        System.Diagnostics.Debug.WriteLine("ibtnWrite_Click 호출됨: " + DateTime.Now.ToString("HH:mm:ss.fff"));
       
        string fname = "";

        // FileUpload1 컨트롤로부터 경로를 제거한 파일이름 추출
        if (FileUpload1.HasFile)
            fname = this.GetFileName(FileUpload1.FileName);

        string loginId = Session["userid"].ToString().Trim();
        // 입력 데이터를 전달하기 위해 BoardDo 클래스의 객체 생성
        BoardDo mDo = new BoardDo(txtTitle.Text, txtContents.Text, loginId, fname);

        // 데이터베이스에 레코드를 하나 추가하고 글번호를 리턴받음
        no = (new BoardDao()).NewBoardArticle(mDo);

        // 파일 업로드 처리 → 약속된 파일이름 사용
        // 동일한 이름으로 업로드하는 경우 덮어쓰기 발생 → 유일성 보장을 위해 notice_글번호.확장자 형식 사용
        // tablename_no.ext → notice_2.jpg
        if (fname != "")
        {
            string uFname = "notice_" + no.ToString() + fname.Substring(fname.IndexOf("."));
            FileUpload1.SaveAs(Server.MapPath(@"Notice\" + uFname));
        }

        // 글쓰기가 종료되면 목록 페이지로 이동
        Response.Redirect("boardlist.aspx");

    }

    protected void ibtnList_Click(object sender, ImageClickEventArgs e)
    {
        //목록 페이지로 이동
        Response.Redirect("boardlist.aspx");
    }

    protected void ibtnModify_Click(object sender, ImageClickEventArgs e)
    {
        string fname = "";

        // FileUpload1 컨트롤로부터 경로를 제거한 파일이름 추출
        if (FileUpload1.HasFile)
            fname = this.GetFileName(FileUpload1.FileName);

        string loginId = Session["userid"].ToString().Trim();
        no = int.Parse(Request["no"].ToString());
        // 입력 데이터를 전달하기 위해 BoardDo 클래스의 객체 생성
        BoardDo mDo = new BoardDo(no, txtTitle.Text, txtContents.Text, loginId, fname);

        new BoardDao().ModifyBoardContents(mDo);

        Response.Redirect("boardlist.aspx");
    }
}