using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AlbumDo의 요약 설명입니다.
/// </summary>
public class AlbumDo
{
    //멤버변수
    private int no; //사진번호
    public int No
    {
        get { return no; }
        set { no = value; }
    }
    private string title; //사진제목
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    private string comment; //사진설명
    public string Comment
    {
        get { return comment; }
        set { comment = value; }
    }
    private string fname; //파일이름
    public string Fname
    {
        get { return fname; }
        set { fname = value; }
    }
    private string author; //작성자 id
    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    private string name; //작성자 이름
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string nickname; //작성자 별명
    public string NickName
    {
        get { return nickname; }
        set { nickname = value; }
    }
    private int hits; //조회수
    public int Hits
    {
        get { return hits; }
        set { hits = value; }
    }
    private string uploadtime; //작성일
    public string Uploadtime
    {
        get { return uploadtime; }
        set { uploadtime = value; }
    }
    private int albumid; //앨범번호, 1->MyPhoto, 2->CampusLife, 3-> GoodScenery
    public int Albumid
    {
        get { return albumid; }
        set { albumid = value; }
    }

    //인수가 5개 있는 생성자 --> 사진 올리기용 
	public AlbumDo(string title, string comment, string fname, string author, int albumid)
	{
        this.title = title;
        this.comment = comment;
        this.fname = fname;
        this.author = author;
        this.albumid = albumid;
	}
    //인수가 10개 있는 생성자 --> 목록 및 상세보기 용 
    public AlbumDo(int no, string title, string comment, string fname, string author, string name, string nickname, int hits, string uploadtime, int albumid)
    {
        this.no = no;
        this.title = title;
        this.comment = comment;
        this.fname = fname;
        this.author = author;
        this.name = name;
        this.nickname = nickname;
        this.hits = hits;
        this.uploadtime = uploadtime;
        this.albumid = albumid;
    }
}