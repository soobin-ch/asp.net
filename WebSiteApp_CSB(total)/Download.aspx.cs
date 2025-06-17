using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Session["path"].ToString(); // 데이터베이스에 저장된 파일이름
        string fname = Session["fname"].ToString();

        // string path = "Notice\\notice_" + no.ToString() + mDo.Filename.Substring(mDo.Filename.IndexOf(".")); // 서버에 저장된 위치
        string serverFname = Server.MapPath(path);

        // 실제 다운로드 실행
        try
        {
            Response.Clear();

            // 파일이름 보내기 --> 인코딩처리를 해주어야 한글이 깨지지 않음
            //Response.AddHeader("Content-Disposition", "filename=" + Server.UrlEncode(fname));

            // 다운로드 타입 지정
            Response.ContentType = "multipart/form-data";
            //Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(fname));
            // 서버로부터 파일 전송
            Response.WriteFile(serverFname);

            Response.Write("<script>window.onload = function() { window.close(); };</script>");
            Response.End();
        }
        catch
        {
        }
    }
}