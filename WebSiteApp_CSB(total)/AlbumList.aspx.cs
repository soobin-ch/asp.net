using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class albumlist : System.Web.UI.Page
{
    //전역변수 선언
    //static 키워드는 해당 클래스 종료할 때까지 객체 유지
    //앨범정보 --> 어떤 서브메뉴를 눌렀느냐에 의해 결정
    static AlbumInfo albumInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 주소 표시줄에 부착된 테이블 정보를 가져옵니다.
            // 주소 형식 : albumlist.aspx?id=1
            int albumId = int.Parse(Request["id"]);

            // 임시객체를 이용하여, 앨범 정보를 가져옵니다.
            albumInfo = (new AlbumDao()).GetAlbumInfo(albumId);

            // 쓰기 권한을 체크하여 권한이 있을 경우 "사진올리기" 버튼의 Visible 속성을 true로 변경
            // if (Session["userid"] != null)
            // {
            //     if ((new MemberDao()).GetUgradeOfUserid(Session["userid"].ToString()) >= albumInfo.Writeauth)
            //         btnSave.Visible = true;
            // }

            if ((new MemberDao()).CheckAuth(Session["userid"], albumInfo.Writeauth))
                btnSave.Visible = true;
            else
                btnSave.Visible = false;

            // 앨범 제목에 상세표시 추가
            lblAlbumTitle.Text += "(" + albumInfo.Albumname + ")";

            // 앨범 목록 보이기
            DisplayAlbum();
        }

    }

    //앨범 목록 보이기 --> 첫 목록 및 새로운 사진 등록 후 이용
    private void DisplayAlbum()
    {
        grvAlbum.DataSource = (new AlbumDao()).GetPhotosList(albumInfo.Tablename, albumInfo.AlbumId);

        // 데이터 바인드
        grvAlbum.DataBind();
    }

    //페이지 번호를 고려한 앨범 목록 보이기 --> 현재는 사용하지 않음
    private void DisplayAlbum(int iPage)
    {
        grvAlbum.PageIndex = iPage;

        // 데이터를 불러온 후, 데이터 바인드
        this.DisplayAlbum();
    }

    //사진을 클릭하면 이동하여야 할 url을 제공
    //"albumShow.aspx?id=3&no=7"의 형식을 가짐
    public string GetShowUrl(object no)
    {
        if ((new MemberDao()).CheckAuth(Session["userid"], albumInfo.Readauth))
        {
            // 상세보기 권한이 있습니다. url에는 빈칸이 포함되면 안됨.
            return "albumshow.aspx?id=" + albumInfo.AlbumId + "&no=" + no.ToString();
        }
        else // 권한이 없습니다.
        {
            lblMessage.Text = "로그인하지 않았거나 권한이 없습니다.";
            return null;
        }
    }

    //사진의 주소글 가져옵니다.
    public string GetImageUrl(object no, object fname)
    {
        return @"~\Photos\" + albumInfo.Tablename + "_"
            +no +
            fname.ToString().Substring(fname.ToString().IndexOf("."));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("albumwrite.aspx?id=" + albumInfo.AlbumId);
    }

    protected void grvAlbum_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAlbum.PageIndex = e.NewPageIndex;
        grvAlbum.DataBind();
    }

}