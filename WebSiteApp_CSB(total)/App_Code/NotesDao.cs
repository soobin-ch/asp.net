using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// NotesDao의 요약 설명입니다.
/// </summary>
public class NotesDao
{
	public NotesDao()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
	}


    // 출석부 목록을 가져옴
    public DataSet GetNotesList()
    {
        // 쿼리문 지정, 사용자 이름 및 이메일 주소를 가져오기 위해 JOIN 필요
        string qrySelect = "SELECT * FROM view_Attendance ORDER BY uploaddate DESC";

        // 결과 리턴
        return DbMan.DataAdapterFill(qrySelect, "attendance");
    }

    // notes 테이블에 한 줄을 삽입
    public void InsertNotes(NoteDo mDo)
    {
        //// 쿼리문을 이용한 데이터 입력
        // string qryInsert = 
        //     "INSERT INTO attendance " +
        //     "(author, contents, uploaddate) " +
        //     "VALUES ('" + mDo.Author + "', '" + mDo.Contents + "', GETDATE())";
        //// 쿼리문 실행
        // DbMan.ExecuteNonQuery(qryInsert);

        // 저장 프로시저를 이용한 데이터 입력
        SqlCommand mCmd = new SqlCommand("procAddNote", DbMan.Open());
        mCmd.CommandType = CommandType.StoredProcedure;

        // 입력 파라미터 추가
        SqlParameter param;

        param = new SqlParameter("@author", SqlDbType.Char, 15);
        param.Value = mDo.Author;
        mCmd.Parameters.Add(param);

        param = new SqlParameter("@contents", SqlDbType.NVarChar, 50);
        param.Value = mDo.Contents;
        mCmd.Parameters.Add(param);

        // 실행
        DbMan.ExecuteNonQuery(mCmd);

        // 데이터베이스 연결 해제
        DbMan.Close();
    }

}