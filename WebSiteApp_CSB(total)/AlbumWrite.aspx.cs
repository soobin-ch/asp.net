using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class albumwrite : System.Web.UI.Page
{
    //전역변수 선언 -> 앨범의 정보 추출
    static AlbumInfo albumInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        //처음 접속할 경우에 대한 조치
        if (Session["userid"] == null) return;

        // 처음 접속할 경우에 대한 조치
        if (!IsPostBack)
        {
            // 제목표시줄에 부착된 테이블 정보를 가져옵니다.
            int albumid = int.Parse(Request["id"]);

            // 임시객체를 이용하여 앨범의 정보를 가져옵니다.
            albumInfo = (new AlbumDao()).GetAlbumInfo(albumid);

            // 로그인 아이디를 작성자 영역에 표시
            txtId.Text = Session["userid"].ToString();

            // 3개의 메뉴 중 어떤 메뉴를 클릭하고 왔는지, 호출한 위치 지정
            // albumlist.aspx?id=1 / 2 / 3
            Session["returnUrl"] = Request.UrlReferrer.ToString();
        }
    }

    protected void ibtnWrite_Click(object sender, ImageClickEventArgs e)
    {
        string fname = "";

        // 파일 이름과 관련한 처리
        if (fileUpload1.HasFile)
        {
            fname = this.GetFilename(fileUpload1.FileName);
        }
        else
        {
            lblMessage.Text = "업로드할 사진을 선택해 주세요...";
            return;
        }

        // 그림형식의 파일만 다룸. 다른 파일의 경우는 허용하지 않음
        string fileExt = fname.Substring(fname.LastIndexOf(".")).ToLower();
        bool isFig = (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".png" || fileExt == ".jpeg");

        if (!isFig)
        {
            lblMessage.Text = "그림 형식의 파일을 선택해 주세요.";
            return;
        }

        // 데이터를 전달할 AlbumDo 객체 생성
        AlbumDo aDo = new AlbumDo(txtTitle.Text, txtComment.Text, fname, txtId.Text, albumInfo.AlbumId);

        // 임시객체를 이용하여 레코드 입력
        int no = (new AlbumDao()).NewPhoto(albumInfo.Tablename, aDo);

        // 업로드 파일이름(동일파일명 수용) -> (tablename)_(no).(jpg)
        string ufname = Server.MapPath(@"Photos\" + albumInfo.Tablename + "_" + no.ToString() + fileExt);

        // 실제로 업로드합니다.
        fileUpload1.SaveAs(ufname);

        // 작업이 완료되면 목록페이지로 이동
        Response.Redirect(Session["returnUrl"].ToString());
    }

    //파일이름 구하기
    private string GetFilename(string path)
    {

        return path.Substring(path.LastIndexOf(@"\") + 1);
    }

    protected void ibtnList_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(Session["returnUrl"].ToString());
    }
}