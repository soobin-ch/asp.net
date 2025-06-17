using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// AlbumDao의 요약 설명입니다.
/// </summary>
public class AlbumDao
{
    public AlbumDao()
    {
        // TODO: 여기에 생성자 논리를 추가합니다.
    }

    //앨범 정보 가져오기, 프로그램 하나로 3개의 서브메뉴를 관리하기 위해 도입한 앨범 설정 테이블의 정보를 취급
    //입력 --> 앨범번호, 1->MyPhoto, 2->CampusLife, 3->Senery
    //출력 --> AlbumInfo 객체
    public AlbumInfo GetAlbumInfo(int albumId)
    {
        AlbumInfo mInfo;

        // 앨범정보 조회 위한 쿼리문 지정
        string qrySelect = "SELECT * FROM photosinfo WHERE albumId=" + albumId;

        // 실행하여 결과를 SqlDataReader로 받아옴
        SqlDataReader mReader = DbMan.ExecuteReader(qrySelect);

        // 결과를 AlbumInfo 클래스로 전달, 레코드가 없는 경우는 발생하지 않음
        mReader.Read();
        mInfo = new AlbumInfo(
            int.Parse(mReader["albumid"].ToString().TrimEnd()),
            mReader["albumname"].ToString().TrimEnd(),
            mReader["tablename"].ToString().TrimEnd(),
            int.Parse(mReader["readauth"].ToString().TrimEnd()),
            int.Parse(mReader["writeauth"].ToString().TrimEnd())
        );

        // 데이터베이스 연결 해제
        mReader.Close();
        DbMan.Close();

        // 결과 리턴
        return mInfo;
    }

    //사진 목록 가져오기
    public DataSet GetPhotosList(string tablename, int albumId)
    {
        //JOIN을 이용한 조회방법
        //string qrySelect = "SELECT m.name, m.nickname, p.* FROM members AS m JOIN photos AS p ON m.userid = p.author ORDER BY p.uploadtime DESC";
        //View를 이용한 쿼리문 설정, 조심할 것 -> 테이블 이름을 이용하여 View_photos를 만들어 사용함. 테이블을 생성할 때 반드시 view_(Tablename) 형식의 view를 만들어 둘 것

        //쿼리문 실행 및 결과 리턴
        string qrySelect = "SELECT * FROM view_" + tablename + " WHERE albumId=" + albumId + " ORDER BY uploadtime DESC";

        // 쿼리문 실행 및 결과 리턴
        return DbMan.DataAdapterFill(qrySelect, tablename);
    }

    //사진의 확장자 구하기 --> 현재 사용하지 않음
    public string GetFigExt(string tablename, int no)
    {
        //return 값 설정
        string returnValue = "";

        return returnValue;
    }


    //사진추가
    public int NewPhoto(string table, AlbumDo aDo)
    {
        ////리턴값 초기화 
        //int no=0;
        ////쿼리문 이용 레코드 추가
        //string qryInsert = "INSERT INTO " + table + " (title, comment, fname, author, hits, uploadtime, albumid) VALUES ('" + aDo.Title + "','" + aDo.Comment + "','" + aDo.Fname + "','" + aDo.Author + "',0,GETDATE()," + aDo.Albumid + ")";
        //DbMan.ExecuteNonQuery(qryInsert);
        ////쿼리문 이용 최신 no 값 조회
        //string qrySelect = "SELECT MAX(no) AS no FROM " + table;
        ////입력된 레코드의 no 파악
        //SqlDataReader mReader = DbMan.ExecuteReader(qrySelect);
        //if (mReader.Read())
        //{
        //    no = int.Parse(mReader["no"].ToString());
        //}
        //mReader.Close();
        //DbMan.Close();
        //return no;

        //저장프로시저 이용, , 저장프로시저명 --> "procInsert"+"테이블명"
        // 저장프로시저 이용, 저장프로시저명 --> "procInsert" + 테이블명
        SqlCommand cmd = new SqlCommand("procInsert" + table, DbMan.Open());
        cmd.CommandType = CommandType.StoredProcedure;

        // 사진제목 파라미터에 추가
        SqlParameter param = new SqlParameter("@title", SqlDbType.NChar, 20);
        param.Value = aDo.Title;
        cmd.Parameters.Add(param);

        // 사진설명 파라미터에 추가
        param = new SqlParameter("@comment", SqlDbType.NVarChar, 500);
        param.Value = aDo.Comment;
        cmd.Parameters.Add(param);

        // 사진의 파일명 파라미터에 추가
        param = new SqlParameter("@fname", SqlDbType.NChar, 20);
        param.Value = aDo.Fname;
        cmd.Parameters.Add(param);

        // 사진 작성자 파라미터에 추가
        param = new SqlParameter("@author", SqlDbType.NChar, 20);
        param.Value = aDo.Author;
        cmd.Parameters.Add(param);

        // 앨범종류 파라미터에 추가
        param = new SqlParameter("@albumId", SqlDbType.Int);
        param.Value = aDo.Albumid;
        cmd.Parameters.Add(param);

        // 출력 파라미터 지정 -> 사진의 목록번호 구해옴
        SqlParameter outParam = new SqlParameter("@no", SqlDbType.Int);
        outParam.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(outParam);

        // DbMan 클래스 이용, 저장 프로시저 실행, 사진번호 리턴
        return DbMan.ExecuteStoredProcedure(cmd, outParam);

    }

    //개별 사진의 상세정보 구함
    public AlbumDo GetPhotoInfo(string tablename, int no)
    {
        ////쿼리문 이용 --> JOIN을 통해 정보를 가져옴
        //string qrySelect = "SELECT p.*, m.name, m.nickname FROM "+ tablename+ " AS p JOIN members AS m ON p.author=m.userid WHERE no=" + no.ToString();
        //쿼리문 지정,조심할 것 -> 
        //테이블 이름을 이용하여 ViewPhotos를 만들어옴

        //실행하여 결과를 SqlDataReader로 받아옴

        //결과를 AlbumDo 클래스로 전달

        string qrySelect = "SELECT * FROM view_" + tablename + " WHERE no=" + no.ToString();

        // 실행하여 결과를 SqlDataReader로 받아옴
        SqlDataReader myReader = DbMan.ExecuteReader(qrySelect);

        // 결과를 AlbumDo 클래스로 전달
        myReader.Read();

        AlbumDo aDo = new AlbumDo(
            int.Parse(myReader["no"].ToString().TrimEnd()),
            myReader["title"].ToString().TrimEnd(),
            myReader["comment"].ToString().TrimEnd(),
            myReader["fname"].ToString().TrimEnd(),
            myReader["author"].ToString().TrimEnd(),
            myReader["name"].ToString().TrimEnd(),
            myReader["nickname"].ToString().TrimEnd(),
            int.Parse(myReader["hits"].ToString().TrimEnd()),
            myReader["uploadtime"].ToString().TrimEnd(),
            int.Parse(myReader["albumid"].ToString().TrimEnd())
        );

        myReader.Close();
        DbMan.Close(); // 결과 리턴
        return aDo;

        //결과 리턴

    }

    //사진정보 삭제
    public void RemovePhoto(string tablename, int no)
    {
        //삭제를 위한 쿼리문 작성
        string qryDelete = "DELETE " + tablename + " WHERE no=" + no.ToString();

        // 실행
        DbMan.ExecuteNonQuery(qryDelete);
        //실행
    }

}