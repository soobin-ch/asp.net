using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Activities.Expressions;

public partial class albumshow : System.Web.UI.Page
{
    //전역변수 선언  
    static AlbumInfo aInfo;
    static AlbumDo aDo;
    static int no;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null) return;

        // 처음 실행할 때의 조치
        if (!IsPostBack)
        {
            // 비정상 접속에 대한 조치 --> 초기화면으로 보냄
            if (Request["id"] == null || Request["no"] == null)
                Response.Redirect("profile.aspx");

            // 제목 표시줄에 부착된 앨범/사진번호를 가져옵니다.
            int albId = int.Parse(Request["id"]);
            no = int.Parse(Request["no"]);

            // 앨범 및 사진에 해당하는 정보를 가져옵니다.
            aInfo = (new AlbumDao()).GetAlbumInfo(albId);
            aDo = (new AlbumDao()).GetPhotoInfo(aInfo.Tablename, no);

            // 비정상 접속 --> 읽기 권한 없음(주소입력)
            if (!(new MemberDao()).CheckAuth(Session["userid"], aInfo.Readauth))
                Response.Redirect("profile.aspx");

            // 앨범 제목 및 사진 표시
            lblTitle.Text = aInfo.Albumname + " >> " + aDo.Title;
            imgMain.ImageUrl = "~/Photos/" + aInfo.Tablename + "_" + no.ToString() +
                aDo.Fname.Substring(aDo.Fname.IndexOf("."));

            // 본인이 작성한 글 혹은 관리자만 삭제할 수 있음
            if ((Session["userid"].ToString() == aDo.Author) ||
                ((new MemberDao()).GetUgradeOfUserid(Session["userid"].ToString())
                >= (new MemberDao()).GetUgradeOfGradename("관리자")))
            {
                ibtnDelete.Visible = true;
            }
        }
    }

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        // 업로드된 사진 삭제
        // 실제 사진이 저장되는 위치 구하기
        string path = Request.PhysicalApplicationPath + "Photos\\" +
                      aInfo.Tablename + no.ToString() +
                      aDo.Fname.Substring(aDo.Fname.IndexOf("."));

        // 해당 위치에 파일이 존재하는 경우, 파일 삭제
        // 이 작업을 위해서는 네임스페이스 using System.IO; 추가
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        // 임시객체를 활용하여 데이터베이스의 게시글을 삭제
        (new AlbumDao()).RemovePhoto(aInfo.Tablename, no);

        // 삭제 후 창 닫기 소스 코드
        ClientScriptManager sm = Page.ClientScript;
        string script = "<script>window.opener='nothing';window.open('', '_parent','');window.close();</script>";
        sm.RegisterStartupScript(this.GetType(), "sm", script);

        // else {
        //     lblMessage.Text = "본인이 작성한 글만 삭제할 수 있습니다.";
        // }
    }
}
