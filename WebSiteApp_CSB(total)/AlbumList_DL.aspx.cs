using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class albumlist_dl : System.Web.UI.Page
{
    //모듈변수 선언
    //static 키워드는 해당 클래스 종료할 때까지 객체 유지
    //앨범정보 --> 어떤 서브메뉴를 눌렀느냐에 의해 결정
    static AlbumInfo albumInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        //처음 접속 시 실행
        if (!IsPostBack)
        {
            // 주소를 직접 입력하는 경우의 처리
            if (Request["id"] == null)
                Response.Redirect("albumlist.aspx?id=3");

            // 주소 표시줄에 부착된 테이블 정보를 가져옵니다. // 예: albumlist.aspx?id=1
            int albumid = int.Parse(Request["id"]);

            // 임시객체를 이용하여 앨범 정보를 가져옵니다.
            albumInfo = (new AlbumDao()).GetAlbumInfo(albumid);

            // 쓰기 권한을 체크하여 권한이 있을 경우 "사진올리기" 버튼의 Visible 속성을 true로 변경
            if ((new MemberDao()).CheckAuth(Session["userid"], albumInfo.Writeauth))
                btnSave.Visible = true;

            // 앨범 제목에 상세표시 추가
            lblAlbumTitle.Text += "(" + albumInfo.Albumname + ")";

            // 앨범 목록 보이기
            DisplayAlbum();
        }
    }

    //앨범 목록 보이기 --> 첫 목록 및 새로운 사진 등록 후 이용
    private void DisplayAlbum()
    {
        dlAlbum.DataSource = (new AlbumDao()).GetPhotosList(albumInfo.Tablename, albumInfo.AlbumId);

        // 데이터 바인드
        dlAlbum.DataBind();
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
        else
        {
            lblMessage.Text = "로그인하지 않았거나 권한이 없습니다.";
            return null;
        }
        
    }

    //사진의 주소글 가져옵니다.
    public string GetImageUrl(object no, object fname)
    {
        //파일이름 작성
        //string test = @"~\Photos\img_"+albumInfo.tablename +"_"+ no + ".jpg";
        return @"~\Photos\" + albumInfo.Tablename + no + fname.ToString().Substring(fname.ToString().IndexOf("."));
        return @"";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Page_Load()에서 권한은 모두 체크해 두었으므로 이곳에서는 글쓰기 페이지로 이동하기만 하면 됨
        Response.Redirect("albumWrite.aspx?id=" + albumInfo.AlbumId);
    }

    //사진 제목 중 앞의 10자리만 추출하여 반환.
    public string GetTitle(object title)
    {
        return title.ToString().Substring(0, 10);
    }
}