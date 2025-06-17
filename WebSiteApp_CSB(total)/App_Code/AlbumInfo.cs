using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AlbumInfo의 요약 설명입니다.
/// </summary>
public class AlbumInfo
{
    //앨범 설정과 관련한 정보전달용
    private int albumId; //앨범 구분번호, 1->MyPhoto, 2->CampusLife, 3->Senery
    public int AlbumId
    {
        get { return albumId; }
        set { albumId = value; }
    }
    private string albumname; //앨범제목
    public string Albumname
    {
        get { return albumname; }
        set { albumname = value; }
    }
    private string tablename; //사진이 저장된 테이블
    public string Tablename
    {
        get { return tablename; }
        set { tablename = value; }
    }
    private int readauth; //앨범 읽기 권한
    public int Readauth
    {
        get { return readauth; }
        set { readauth = value; }
    }
    private int writeauth; //앨범 쓰기 권한
    public int Writeauth
    {
        get { return writeauth; }
        set { writeauth = value; }
    }

    //인수 있는 생성자
	public AlbumInfo(int aId, string aName, string table, int rAuth, int wAuth )
	{
        this.albumId = aId;
        this.albumname = aName;
        this.tablename = table;
        this.readauth = rAuth;
        this.writeauth = wAuth;
	}
}