using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

/// <summary>
/// NaverApi의 요약 설명입니다.
/// </summary>
public class NaverApi
{
    ////모듈변수
    const string ID = "9d1SMaUNp7hRgd825pPf";
    const string SECRET = "DtWEncu3cB";

    //검색 레코드의 5개 결과를 저장할 문자열 배열
    static string[] sArr = new string[5];

    public NaverApi()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }


    //입력 qry는 검색 키워드
    public static DataSet Search(string qry)
    {
        DataSet myDs = new DataSet();

        // DataSet 내부의 테이블 구조 설계 --> 응답 형식 참고
        DataTable myDt = new DataTable("search");
        myDt.Columns.Add("title");
        myDt.Columns.Add("originalLink");
        myDt.Columns.Add("link");
        myDt.Columns.Add("description");
        myDt.Columns.Add("pubDate");

        // Naver Open API 호출 url --> 결과는 xml 형식
        // 자료는 연관성 높은 100개를 반환함
        string url = "https://openapi.naver.com/v1/search/news.xml?query=" + qry + "&display=100&start=1&sort=sim";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

        // 클라이언트 id와 secret 등록
        request.Headers.Add("X-Naver-Client-ID", ID);
        request.Headers.Add("X-Naver-Client-Secret", SECRET);

        // 결과를 받아옴
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string status = response.StatusCode.ToString();

        if (status == "OK")
        {
            // 결과를 XmlReader 형식으로 읽음
            XmlReader xmlReader = XmlReader.Create(new StreamReader(response.GetResponseStream(), Encoding.UTF8));

            // 총 검색수 표시 위치로 이동 (주석 처리됨)
            // xmlReader.ReadToFollowing("total");
            // xmlReader.Read();
            // Console.WriteLine("+" + xmlReader.Value + "\n\n");

            // 자료가 끝날 때까지 읽음
            while (xmlReader.Read())
            {
                // item 항목이 존재하는 위치로 이동
                xmlReader.ReadToFollowing("item");

                // 배열의 인덱스 처리용 변수
                int iCount = 0;
                string[] sArr = new string[5];

                // xmlReader.Read()는 XML 태그도 한 줄로 읽어들임
                for (int i = 0; i < 15; i++)
                {
                    // 다음 항목 읽음
                    xmlReader.Read();

                    // 시작 태그와 끝 태그는 건너뛰고, 항목 내용만 출력
                    if (xmlReader.NodeType != XmlNodeType.Text)
                        continue;

                    // 항목 출력 (주석 처리됨)
                    // Console.WriteLine(xmlReader.Value);

                    // 검색된 항목을 문자열 배열에 저장
                    sArr[iCount++] = xmlReader.Value;

                    // Console.WriteLine("\n");

                    // DataTable의 레코드로 등록
                    if (iCount == 5)
                    {
                        myDt.Rows.Add(sArr[0], sArr[1], sArr[2], sArr[3], sArr[4]);
                        iCount = 0;
                    }
                }
            }
        }
        else
        {
            // 오류 처리 주석 (주석 처리됨)
            // Response.Write("error: " + status);
        }

        // DataTable을 DataSet의 테이블로 등록
        myDs.Tables.Add(myDt);

        // 결과 반환
        return myDs;
    }
}