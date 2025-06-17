using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// BoardDao 클래스는 오로지 하나만의 게시판을 운용학도자 할 때 유용하게 사용할 수 있는 것입니다. 
/// </summary>
public class BoardDao
{
	public BoardDao()
	{
	}
    //단일게시판 목록 가져오기
    public DataSet GetBoardList()
    {
        string qrySelect = "SELECT * FROM view_notice ORDER BY uploadTime DESC";

        // 결과 리턴
        return DbMan.DataAdapterFill(qrySelect, "bbs");
    }

    //새로운 글쓰기 --> notice 테이블에 새로운 레코드 추가
    //반환결과는 글번호 --> 파일업로드에서 사용됨
    public int NewBoardArticle(BoardDo mDo)
    {
        // SqlCommand 객체를 생성, 객체의 형식을 저장프로시저로 설정
        SqlCommand myCmd = new SqlCommand("procInsertNotice", DbMan.Open());

        myCmd.CommandType = CommandType.StoredProcedure;

        // 저장프로시저 동작을 위한 파라미터 지정
        SqlParameter myParam;

        // title
        myParam = new SqlParameter("@title", SqlDbType.NChar, 20);
        myParam.Value = mDo.Title;
        myCmd.Parameters.Add(myParam);

        // contents
        myParam = new SqlParameter("@contents", SqlDbType.NVarChar, 500);
        myParam.Value = mDo.Contents;
        myCmd.Parameters.Add(myParam);

        // author
        myParam = new SqlParameter("@author", SqlDbType.Char, 15);
        myParam.Value = mDo.Author;
        myCmd.Parameters.Add(myParam);

        // filename
        myParam = new SqlParameter("@filename", SqlDbType.NVarChar, 100);
        myParam.Value = mDo.Filename;
        myCmd.Parameters.Add(myParam);

        // no --> OUTPUT으로 결과를 가져옴, GrpNo 지정 및 파일첨부에 이용
        SqlParameter myParamOut = new SqlParameter("@no", SqlDbType.Int);
        myParamOut.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(myParamOut);

        // 명령문 실행 및 글번호 알아오기
        return DbMan.ExecuteStoredProcedure(myCmd, myParamOut);

    }

    //기존 글 수정 --> 도전과제
    public void ModifyBoardContents(BoardDo mDo)
    {
        string qryUpdate = @"
        UPDATE notice
        SET 
            title = '" + mDo.Title + @"',
            contents = '" + mDo.Contents + @"',
            filename = " + (mDo.Filename != null ? ("'" + mDo.Filename + "'") : "NULL") + @"
        WHERE 
            no = " + mDo.No;

        DbMan.ExecuteNonQuery(qryUpdate);
    }
    
//    }

        //게시글 상세보기 --> 게시판 목록에서 제목 하이퍼링크를 클릭할 때 실행
        //입력 : 글번호(no)
        //cnffur : BoardDo 클래스 객체 --> 생성자를 이용하여 멤버변수 할당
    public BoardDo GetBoardDetails(int no)
    {
        //리턴할 값을 초기화
        BoardDo mDo;
        string qryUpdate = "UPDATE notice SET hits=hits+1 WHERE no=" + no;
        DbMan.ExecuteNonQuery(qryUpdate);

        string qrySelect = "SELECT * FROM view_notice WHERE no=" + no;

        SqlDataReader myReader = DbMan.ExecuteReader(qrySelect);
        myReader.Read();
        mDo = new BoardDo(
    int.Parse(myReader["no"].ToString().TrimEnd()),            // no
    myReader["title"].ToString().TrimEnd(),                    // title
    myReader["contents"].ToString().TrimEnd(),                 // contents
    myReader["author"].ToString().TrimEnd(),                   // author
    myReader["name"].ToString().TrimEnd(),                     // name
    myReader["nickname"].ToString().TrimEnd(),                 // nickname
    myReader["uploadTime"].ToString().TrimEnd(),               // uploadtime
    int.Parse(myReader["hits"].ToString().TrimEnd()),          // hits
    myReader["filename"].ToString().TrimEnd()                  // filename
);
        myReader.Close();
        DbMan.Close();

        // 결과 리턴
        return mDo;
    }
    //게시글 삭제
    public void RemoveArticle(int no)
    {
        string qryDelete = "DELETE notice WHERE no=" + no.ToString();
        DbMan.ExecuteNonQuery(qryDelete);
        DbMan.Close();
      

    }
}