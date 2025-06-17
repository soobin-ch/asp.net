using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; //첨부파일 삭제 처리에 이용

public partial class boardshow : System.Web.UI.Page
{
    static int no;
    static BoardDo mDo;

    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (!IsPostBack)
        {
            // url로부터 글번호 no를 추출
            no = int.Parse(Request["no"].ToString());

            // 임시객체(Anonymous Object)를 활용하여 게시글의 상세정보를 조회함
            mDo = (new BoardDao()).GetBoardDetails(no);

            // 글의 정보를 화면에 출력
            lblAuthor.Text = mDo.Nickname + "(" + mDo.Author + ")";
            lblContents.Text = mDo.Contents;

            if (mDo.Filename.Length > 0)
            {
                lblFname.Text = mDo.Filename;

                // 다운로드 버튼을 이용 현재 브라우저에 다운로드함
                // btnDownload.Enabled = true;

                // 하이퍼링크를 이용하여 새 브라우저를 열고 다운로드함
                hlDownload.Visible = true;
                hlDownload.NavigateUrl = ResolveUrl("~/Download.aspx");

                // 첨부파일이 저장되는 파일명과 데이터베이스에 저장된 파일명을 Session 변수에 저장
                Session["path"] = "Notice\\notice_" + no.ToString() + mDo.Filename.Substring(mDo.Filename.IndexOf("."));
                Session["fname"] = mDo.Filename;
            }

            lblHits.Text = mDo.Hits.ToString();
            lbltitle.Text = mDo.Title;
            lblUploadDate.Text = mDo.Uploadtime;
        }
    }



protected void ibtnList_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("boardList.aspx");

    }

    protected void ibtnModify_Click(object sender, ImageClickEventArgs e)
    {
        //도전과제로 남겨둠
        no = int.Parse(Request["no"].ToString());

       

        Response.Redirect("boardwrite.aspx?no=" +no);
    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        if(Session["userid"] == null)
        {
            lblMessage.Text = "본이이 작성한 글만 삭제할 수 있습니다. 삭제하시려면 로그인해 주세요.";
            return;
        }
        if ((Session["userid"].ToString() == mDo.Author) ||
       ((new MemberDao()).CheckAuth(Session["userid"].ToString(),
       (new MemberDao()).GetUgradeOfGradename("관리자"))))
        {
            // 첨부파일이 존재할 경우 첨부파일 삭제
            if (Session["path"] != null)
            {
                // 첨부파일이 저장되는 path 구하기
                // string path = Request.PhysicalApplicationPath + "\\Notice\\notice_" + no.ToString() + mDo.Filename.Substring(mDo.Filename.IndexOf("."));
                string path = Request.PhysicalApplicationPath + "\\" + Session["path"].ToString();

                // 해당 위치에 파일이 존재하는 경우, 파일 삭제
                // 이 작업을 위해서는 네임스페이스 using System.IO; 추가
                if (File.Exists(path))
                    File.Delete(path);

                // Session 변수 삭제
                Session["path"] = null;
                Session["fname"] = null;
            }

       // 임시객체를 활용하여 게시글을 삭제
       (new BoardDao()).RemoveArticle(no);

            // 게시글의 삭제가 완료되면 목록 페이지로 이동
            Response.Redirect("boardlist.aspx");
        }
        else
        {
            lblMessage.Text = "본인이 작성한 글만 삭제할 수 있습니다.";
        }
    }

    //다운로드 버튼을 클릭할 경우, 현재는 사용하지 않음
    protected void btnDownload_Click(object sender, EventArgs e)
    {

    }
}