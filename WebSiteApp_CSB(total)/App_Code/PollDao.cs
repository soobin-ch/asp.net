using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; //DataSet
using System.Data.SqlClient; //4개 클래스

/// <summary>
/// PollDao의 요약 설명입니다.
/// </summary>
public class PollDao
{
	public PollDao()
	{
		// TODO: 여기에 생성자 논리를 추가합니다.
	}

    //질문목록 반환
    // 질문목록 반환
    public DataSet GetPollQuestionList(string kword)
    {
        // 쿼리문 작성
        // string qrySelect = "SELECT p.*, m.name, m.nickname FROM pollquestions AS p JOIN members AS m ON p.demander=m.userid ";

        // 뷰 이용
        string qrySelect = "SELECT * FROM view_pollquestions ";
        if (kword != null)
            qrySelect += "WHERE qcontents LIKE '%" + kword + "%' ";
        // qrySelect += "ORDER BY p.duedate DESC";
        qrySelect += "ORDER BY duedate DESC";

        // 실행 및 결과 반환
        return DbMan.DataAdapterFill(qrySelect, "questions");
    }


    //투표종료여부 확인
    public bool ConfirmDueDate(int qId)
    {
        // 오늘 날짜와 마감일을 비교하여 진행중 여부 확인
        // SqlCommand
        SqlCommand myCmd = new SqlCommand("proccheckdue", DbMan.Open());
        myCmd.CommandType = CommandType.StoredProcedure;

        // 저장 프로시저 동작을 위한 파라미터 지정
        // 질문번호 --> QId
        SqlParameter myParam = new SqlParameter("@qid", SqlDbType.Int);
        myParam.Value = qId;
        myCmd.Parameters.Add(myParam);


        SqlParameter myPrmOut = new SqlParameter("@isprocessing", SqlDbType.NChar, 5);
myPrmOut.Direction = ParameterDirection.Output;
myCmd.Parameters.Add(myPrmOut);

// 명령문 실행 (결과는 문자열 "true" 혹은 "false"로 반환)
string sProcessing = DbMan.ExecuteStoredProcedureStr(myCmd, myPrmOut);

// 결과(true 혹은 false)에 따라 반환값 리턴
bool retValue = false;
if (sProcessing.Trim() == "True")
    retValue = true;

return retValue;
    }

    public void InsertPoll(PollDo pDo, string[] options)
    {
        //질문을 입력하고 질분번호를 가져옴 --> 선택항목입력에 필요
        SqlCommand myCmd = new SqlCommand("procaddquestion", DbMan.Open());
        myCmd.CommandType = CommandType.StoredProcedure;

        // 파라미터 설정
        // qContent
        SqlParameter myParam = new SqlParameter("@qcontents", SqlDbType.NVarChar, 100);
        myParam.Value = pDo.Qcontents;
        myCmd.Parameters.Add(myParam);

        // selectionmode
        myParam = new SqlParameter("@selectionmode", SqlDbType.Bit);
        myParam.Value = pDo.Selectionmode;
        myCmd.Parameters.Add(myParam);

        // demander --> userid
        myParam = new SqlParameter("@demander", SqlDbType.Char, 15);
        myParam.Value = pDo.Demander;
        myCmd.Parameters.Add(myParam);

        // duedate
        myParam = new SqlParameter("@duedate", SqlDbType.DateTime);
        myParam.Value = pDo.Duedate;
        myCmd.Parameters.Add(myParam);

        // qId --> Output
        SqlParameter myPrmOut = new SqlParameter("@qid", SqlDbType.Int);
        myPrmOut.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(myPrmOut);

        // 입력을 실행하고 질문번호를 받아옴
        int qid = DbMan.ExecuteStoredProcedure(myCmd, myPrmOut);

        // 선택항목 입력
        int optid = 0;

        // 선택항목의 수만큼 순회하면서 입력 처리함
        foreach (string option in options)
        {
            // 저장 프로시저 지정
            myCmd = new SqlCommand("procaddoption", DbMan.Open());
            myCmd.CommandType = CommandType.StoredProcedure;

            // SqlParameters
            // @qid
            myParam = new SqlParameter("@qid", SqlDbType.Int);
            myParam.Value = qid;
            myCmd.Parameters.Add(myParam);

            // @optid
            myParam = new SqlParameter("@optid", SqlDbType.Int);
            myParam.Value = ++optid;
            myCmd.Parameters.Add(myParam);

            // @option
            myParam = new SqlParameter("@option", SqlDbType.NVarChar, 100);
            myParam.Value = option;
            myCmd.Parameters.Add(myParam);

            // 명령 실행
            DbMan.ExecuteNonQuery(myCmd);
            DbMan.Close();
        }
    }

    public PollDo GetPollDetails(int qid)
    {
        ////쿼리문 이용
        //string qrySelect = "SELECT p.*, m.name, m.nickname FROM pollquestions AS p JOIN members AS m ON p.demander = m.userid WHERE qid=" + qid;
        //설문 테이블에서 해당 번호의 자료 가져오기
        string qrySelect = "SELECT * FROM view_pollquestions WHERE qid=" + qid;

        // 설문 상세정보 매핑
        SqlDataReader myReader = DbMan.ExecuteReader(qrySelect);
        myReader.Read();

        // PollDo의 조회용 생성자
        // public PollDo(int qid, string qcontents, bool selectionmode, string demander, string name, string nickname, string uploaddate, string duedate, int totalVotes, DataSet dsOptions)
        PollDo pDo = new PollDo(
            int.Parse(myReader["qid"].ToString()),
            myReader["qcontents"].ToString(),
            bool.Parse(myReader["selectionmode"].ToString()),
            myReader["demander"].ToString(),
            myReader["name"].ToString(),
            myReader["nickname"].ToString(),
            myReader["uploaddate"].ToString(),
            myReader["duedate"].ToString(),
            this.GetTotalVotes(qid),
            this.GetOptionsList(qid)
        );

        // 데이터베이스 닫기
        myReader.Close();
        DbMan.Close();

        // 반환값 처리
        return pDo;
    }

    public DataSet GetOptionsList(int qid)
    {
        string qrySelect = "SELECT * FROM pollOptions WHERE qid = " + qid;

        // 실행 및 결과 반환
        return DbMan.DataAdapterFill(qrySelect, "options");
    }

    //해당 질문 번호에 대한 총응답수 반환
    public int GetTotalVotes(int qid)
    {
        SqlCommand myCmd = new SqlCommand("procGetPollCount", DbMan.Open());
        myCmd.CommandType = CommandType.StoredProcedure;

        // SqlParameter
        SqlParameter myParam = new SqlParameter("@qid", SqlDbType.Int);
        myParam.Value = qid;
        myCmd.Parameters.Add(myParam);

        // @count
        SqlParameter myPrmOut = new SqlParameter("@count", SqlDbType.Int);
        myPrmOut.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(myPrmOut);

        // 명령 실행 및 결과 반환
        return DbMan.ExecuteStoredProcedure(myCmd, myPrmOut);
    }

    public bool IsVoted(int qid, string userid)
    {
        bool retValue = false;

        // 쿼리문 작성
        string qrySelect = "SELECT * FROM pollvoteduser WHERE voteduser = '" + userid + "' AND qid=" + qid;
        SqlDataReader myReader = DbMan.ExecuteReader(qrySelect);

        if (myReader.Read()) retValue = true;

        myReader.Close();
        DbMan.Close();

        // 결과값 반환
        return retValue;
    }

    //투표를 실시할 경우의 처리, 1. 해당 옵션의 히트수를 하나 증가시킴
    public void UpdateVote(int qid, int optid)
    {
        SqlCommand myCmd = new SqlCommand("procUpdateHits", DbMan.Open());
        myCmd.CommandType = CommandType.StoredProcedure;

        // qId, 질문번호
        SqlParameter myParam = new SqlParameter("@qid", SqlDbType.Int);
        myParam.Value = qid;
        myCmd.Parameters.Add(myParam);

        // optId, 옵션(선택항목) 번호
        myParam = new SqlParameter("@optid", SqlDbType.Int);
        myParam.Value = optid;
        myCmd.Parameters.Add(myParam);

        // 실행
        DbMan.ExecuteNonQuery(myCmd);
        DbMan.Close();

    }

    public void InsertVotedUser(int qid, string userid)
    {
        //저장 프로시저 호출
        SqlCommand myCmd = new SqlCommand("procinsertvoteduser", DbMan.Open());
        myCmd.CommandType = CommandType.StoredProcedure;

        // 파라미터 지정
        // qId
        SqlParameter myParam = new SqlParameter("@qid", SqlDbType.Int);
        myParam.Value = qid;
        myCmd.Parameters.Add(myParam);

        // voteduser
        myParam = new SqlParameter("@voteduser", SqlDbType.Char, 15);
        myParam.Value = userid;
        myCmd.Parameters.Add(myParam);

        // 실행
        DbMan.ExecuteNonQuery(myCmd);
        DbMan.Close();
    }
}