using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// BoardDo의 요약 설명입니다.
/// </summary>
public class BoardDo
{
    //멤버변수 및 프로퍼티
    private int no; //글번호

    public int No
    {
        get { return no; }
        set { no = value; }
    }
    private string title; //글제목

    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    private string contents; //내용

    public string Contents
    {
        get { return contents; }
        set { contents = value; }
    }
    private string author; //작성자 id

    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    private string name; // 작성자 이름

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string nickname; //작성자 별명

    public string Nickname
    {
        get { return nickname; }
        set { nickname = value; }
    }
    private string uploadtime; //작성일

    public string Uploadtime
    {
        get { return uploadtime; }
        set { uploadtime = value; }
    }
    private int hits; //조회수

    public int Hits
    {
        get { return hits; }
        set { hits = value; }
    }
    private string filename; //첨부파일

    public string Filename
    {
        get { return filename; }
        set { filename = value; }
    }

    //생성자 --> 게시글 입력시 사용
    //제목, 내용, 작성자id, 파일이름 전달 
	public BoardDo(string title, string contents, string author, string filename)
	{
        this.title = title;
        this.contents = contents;
        this.author = author;
        this.filename = filename;
	}
    //생성자 --> 게시글 상세보기에 이용
    //글번호, 제목, 내용, 작성자 id, 작성자 이름, 작성자 별명, 작성일, 조회수, 파일이름 전달
    public BoardDo(int no, string title, string contents, string author, string name, string nickname, string uploadtime, int hits, string filename)
    {
        this.no = no;
        this.title = title;
        this.contents = contents;
        this.author = author;
        this.name = name;
        this.nickname = nickname;
        this.uploadtime = uploadtime;
        this.hits = hits;
        this.filename = filename;
    }

    public BoardDo(int no, string title, string contents, string author, string filename)
    {
        this.no = no;
        this.title = title;
        this.contents = contents;
        this.author = author;
        this.filename = filename;

    }
}