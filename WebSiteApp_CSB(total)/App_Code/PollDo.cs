using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; //DataSet

/// <summary>
/// PollDo의 요약 설명입니다.
/// </summary>
public class PollDo
{
    //설문조사와 관련한 데이터 전달용
    private int qid; //설문번호
    public int Qid
    {
        get { return qid; }
        set { qid = value; }
    }
    private string qcontents; // 질문
    public string Qcontents
    {
        get { return qcontents; }
        set { qcontents = value; }
    }
    private bool selectionmode;// 단일/ 복수선택
    public bool Selectionmode
    {
        get { return selectionmode; }
        set { selectionmode = value; }
    }
    private string demander;// 요청자
    public string Demander
    {
        get { return demander; }
        set { demander = value; }
    }
    private string name; // 요청자 이름
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string nickname; //요청자 별명
    public string Nickname
    {
        get { return nickname; }
        set { nickname = value; }
    }
    private string uploaddate;// 게시일
    public string Uploaddate
    {
        get { return uploaddate; }
        set { uploaddate = value; }
    }
    private string duedate;// 마감일
    public string Duedate
    {
        get { return duedate; }
        set { duedate = value; }
    }
    private int totalVotes; // 총 투표수 --> 저장프로시저 이용 구함
    public int TotalVotes
    {
        get { return totalVotes; }
        set { totalVotes = value; }
    }
    private DataSet dsOptions; // 선택항목 정보 --> 별도로 조회하여 구함
    public DataSet DsOptions
    {
        get { return dsOptions; }
        set { dsOptions = value; }
    }

    //설문입력용 생성자
	public PollDo(string qcontents, bool selectionmode, string demander, string duedate)
	{
        this.qcontents = qcontents;
        this.selectionmode = selectionmode;
        this.demander = demander;
        this.duedate = duedate;
	}

    //설문조회용 생성자
    public PollDo(int qid, string qcontents, bool selectionmode, string demander, string name, string nickname, string uploaddate, string duedate, int totalVotes, DataSet dsOptions)
    {
        this.qid = qid;
        this.qcontents = qcontents;
        this.selectionmode = selectionmode;
        this.demander = demander;
        this.name = name;
        this.nickname = nickname;
        this.uploaddate = uploaddate;
        this.duedate = duedate;
        this.totalVotes = totalVotes;
        this.dsOptions = dsOptions;
    }
}