using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Reflection;
/// <summary>
/// MemberDao의 요약 설명입니다.
/// </summary>
public class MemberDao
{
	public MemberDao()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
	}
    // 로그인 (사용자 인증) --> 인증성공 : true, 인증실패 : false
    // 입력 : id --> 사용자 아이디, pw --> 비밀번호
    public bool Authenticate(string id, string pw)
    {
        // 리턴값 및 out 참조변수 초기화
        bool isAuthen = false; // false --> 미인증상태

        // 쿼리문을 이용하여 조건(id, pwd, 탈퇴하지 않음)에 일치하는 자료를 불러 옴. 비밀번호는 MD5로 암호화 처리
        // string test = this.GetMD5(pwd);
        string sQuery = "SELECT * FROM members WHERE userid='" + id + "' AND passwd='" + this.GetMD5(pw) + "' AND status='true'";

        // DbMan.ExecuteReader() 메서드를 호출하여 결과를 가져옴
        SqlDataReader mReader = DbMan.ExecuteReader(sQuery);

        // 결과값이 존재하면 인증성공, 없으면 인증실패
        if (mReader.Read())
        {
            isAuthen = true;
        }

        // mReader 닫기
        mReader.Close();

        // 데이터베이스 연결 해제
        DbMan.Close();

        // 결과 반환
        return isAuthen;
    }


    // userid를 이용하여, members 테이블에서 nickname을 읽어옴
    // 메인 마스터 페이지에서 환영인사를 표시할 때 nickname을 이용하기 위함
    public string GetNickname(string uid)
    {
        string nickname = null;

        // 쿼리문을 이용하여 nickname을 읽어 옴
        string sQuery = "SELECT nickname FROM members WHERE userid = '" + uid + "'";

        SqlDataReader mReader = DbMan.ExecuteReader(sQuery);

        // userid 존재 여부 확인 후, nickname 지정
        if (mReader.Read())
        {
            nickname = mReader["nickname"].ToString().TrimEnd();
        }

        // mReader 닫기, 닫지 않으면 추후 SqlDataReader를 만들 때 오류 발생
        mReader.Close();

        // 데이터베이스 연결 해제
        DbMan.Close();

        // 리턴값 반환
        return nickname;
    }
    public memberInfo GetMemberInfo(string uid)
    {
        memberInfo member = null;

        // 쿼리문 (SQL Injection 위험 제거 위해 나중엔 파라미터화 추천)
        string sQuery = "SELECT name, nickname, phone, birthday, email, address FROM members WHERE userid = '" + uid + "'";

        // DB 연결 열기
        DbMan.Open();

        SqlDataReader mReader = DbMan.ExecuteReader(sQuery);

        if (mReader.Read())
        {
            member = new memberInfo
            {
                Name = mReader["name"].ToString().Trim(),
                Nickname = mReader["nickname"].ToString().Trim(),
                Phone = mReader["phone"].ToString().Trim(),
                birthDay = mReader["birthday"].ToString().Trim(),
                Email = mReader["email"].ToString().Trim(),
                Address = mReader["address"].ToString().Trim()
            };
        }

        // Reader 닫기
        mReader.Close();

        // DB 연결 닫기
        DbMan.Close();

        return member;
    }

   
    private string GetMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                // 10진수를 두자리의 16진수(대문자 표기)로 변환
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    // 아이디 찾기
    // 입력 : 사용자 Id와 전화번호, 검색 결과는 reference 형으로 전달
    // 출력 : 사용자 Id 검색 성공 여부
    public bool FindUserId(string name, string phone, out string id)
    {
        // 리턴값 초기화
        bool result = false;

        // "Call By Reference" 변수 초기화
        id = "";

        // 전화번호를 "-" 기준으로 분리
        string[] splitedPhoneNumber = phone.Split('-');

        // 검색을 위한 쿼리문 작성
        string selectQry = "SELECT userId FROM members WHERE name = '" + name + "'";

        foreach (string no in splitedPhoneNumber)
        {
            selectQry += " AND phone LIKE '%" + no + "%'";
        }

        // 쿼리문을 실행하고, 결과를 SqlDataReader 객체로 받아옴
        SqlDataReader myReader = DbMan.ExecuteReader(selectQry);

        // SELECT 결과가 존재하면 검색 성공, 결과를 id로 전달함
        if (myReader.Read())
        {
            result = true;
            id = myReader["userId"].ToString();
        }

        // SqlDataReader 객체 소멸 및 데이터베이스 연결 해제
        myReader.Close();
        DbMan.Close();

        // 결과를 리턴
        return result;
    }

    // 아이디 중복검사 --> 사용자 ID 사용가능 여부
    public bool VerifyUserID(string id)
    {
        // 결과 반환용 변수
        bool result = true;

        // 쿼리문 지정
        string sQuery = "SELECT * FROM members WHERE userid = '" + id + "'";

        // DbMan 클래스의 메서드를 호출하여 결과를 구해옴
        SqlDataReader myReader = DbMan.ExecuteReader(sQuery);

        // SqlDataReader 객체의 결과를 확인하여 사용여부 판단
        if (myReader.Read())
        {
            // 사용자ID 존재 → 사용불가
            result = false;
        }

        // SqlDataReader 객체 소멸 및 데이터베이스 연결 해제
        myReader.Close();
        DbMan.Close();

        // 결과 반환
        return result;
    }

    // 회원가입(새로운 사용자 등록) --> 쿼리문 이용
    public void RegisterUserUsingQuery(MemberDo mDo)
    {
        // 쿼리문 지정, 암호화 처리
        string sQuery = "INSERT INTO members (userid, passwd, name, nickname, email, birthday, phone, address, joindate, status, ugrade) " +
                        "VALUES ('" + mDo.Userid + "', '" + this.GetMD5(mDo.Passwd) + "', '" + mDo.Name + "', '" + mDo.Nickname + "', '" +
                        mDo.Email + "', '" + mDo.Birthday + "', '" + mDo.Phone + "', '" + mDo.Address + "', GETDATE(), 'true', 1)";

        // DbMan.cs 클래스를 이용하여 쿼리문 실행 및 연결 해제
        DbMan.ExecuteNonQuery(sQuery);
        DbMan.Close();
    }

    // 회원가입(새로운 사용자 등록) --> 저장프로시저 이용
    public int RegisterUser(MemberDo mDo)
    {
        // SqlCommand 객체 생성 및 저장프로시저 호출 지정
        SqlCommand myCmd = new SqlCommand("procAddMember", DbMan.Open());
        myCmd.CommandType = CommandType.StoredProcedure;

        // 저장프로시저 실행에 필요한 인수 지정

        // userid
        SqlParameter param = new SqlParameter("@userid", SqlDbType.Char, 15);
        param.Value = mDo.Userid;
        myCmd.Parameters.Add(param);

        // passwd (MD5 해시 적용)
        param = new SqlParameter("@passwd", SqlDbType.Char, 32);
        param.Value = this.GetMD5(mDo.Passwd);
        myCmd.Parameters.Add(param);

        // name
        param = new SqlParameter("@name", SqlDbType.NChar, 10);
        param.Value = mDo.Name;
        myCmd.Parameters.Add(param);

        // nickname
        param = new SqlParameter("@nickname", SqlDbType.NChar, 10);
        param.Value = mDo.Nickname;
        myCmd.Parameters.Add(param);

        // email
        param = new SqlParameter("@email", SqlDbType.Char, 20);
        param.Value = mDo.Email;
        myCmd.Parameters.Add(param);

        // birthday
        param = new SqlParameter("@birthday", SqlDbType.SmallDateTime);
        param.Value = mDo.Birthday;
        myCmd.Parameters.Add(param);

        // phone
        param = new SqlParameter("@phone", SqlDbType.Char, 13);
        param.Value = mDo.Phone;
        myCmd.Parameters.Add(param);

        // address
        param = new SqlParameter("@address", SqlDbType.NVarChar, 50);
        param.Value = mDo.Address;
        myCmd.Parameters.Add(param);

        // result (회원가입 성공여부 OUT 변수)
        SqlParameter paramOut = new SqlParameter("@result", SqlDbType.Int);
        paramOut.Direction = ParameterDirection.Output;
        myCmd.Parameters.Add(paramOut);

        // 저장프로시저 실행 및 결과 반환
        return DbMan.ExecuteStoredProcedure(myCmd, paramOut);
    }

    // 비밀번호 재설정 → 본인 인증
    public bool AuthenticateToSetNewPasswd(string id, string name, string birthday)
    {
        bool result = false;

        // 검색을 위한 쿼리문 작성
        string selectQry = "SELECT * FROM members " +
                           "WHERE userid = '" + id + "' " +
                           "AND name = '" + name + "' " +
                           "AND birthday = '" + birthday + "'";

        // 쿼리문을 실행하고 결과를 SqlDataReader 객체로 받아옴
        SqlDataReader myReader = DbMan.ExecuteReader(selectQry);

        if (myReader.Read())
            result = true;

        // SqlDataReader 객체 소멸 및 데이터베이스 연결 해제
        myReader.Close();
        DbMan.Close();

        // 결과를 리턴
        return result;
    }
    // 비밀번호 재설정 → 새 비밀번호로 변경
    public void SetNewPasswd(string id, string pw)
    {
        // 비밀번호 변경을 위한 쿼리문
        string md5Pw = this.GetMD5(pw);
        string updateQry = "UPDATE members SET passwd = '" +this.GetMD5(pw) + "' WHERE userid = '" + id + "'";

        DbMan.ExecuteNonQuery(updateQry);

        // 데이터베이스 연결 해제
        DbMan.Close();
    }

    public bool updateUser(string uid, memberInfo mInfo)
    {
        bool isUpdated = false;

        string sQuery = "UPDATE members SET " +
                    "name = '" + mInfo.Name + "', " +
                    "nickname = '" + mInfo.Nickname + "', " +
                    "email ='" + mInfo.Email + "', " +
                    "phone = '" + mInfo.Phone + "', " +
                    "birthday ='" + mInfo.birthDay + "', " +
                    "address = '" + mInfo.Address + "' " +
                    "WHERE userid = '" + uid + "'";

        // DbMan.cs 클래스를 이용하여 쿼리문 실행 및 연결 해제
        DbMan.ExecuteNonQuery(sQuery);
        DbMan.Close();

        isUpdated = true;

        return isUpdated;
    }

    // 회원의 등급 알아내기
    public int GetUgradeOfUserid(string userid)
    {
        // 반환값 초기화
        int ugrade = 0;

        // ugrade 날아내기 위한 쿼리문 작성
        string qrySelect = "SELECT ugrade FROM members WHERE userid='" + userid.Trim() + "'";

        SqlDataReader mReader = DbMan.ExecuteReader(qrySelect);

        // 확인
        if (mReader.Read())
        {
            ugrade = int.Parse(mReader["ugrade"].ToString());
        }
       
        // 데이터베이스 닫기
        mReader.Close();
        DbMan.Close();

        // 반환값 리턴
        return ugrade;
    }

    // 등급이름에 따른 ugrade 값 구하기
    public int GetUgradeOfGradename(string gradename)
    {
        // 반환값 초기화
        int ugrade = 0;

        // ugrade 날아내기 위한 쿼리문 작성
        string qrySelect = "SELECT ugrade FROM usergrade WHERE gradename='" + gradename +  "'";
        SqlDataReader mReader = DbMan.ExecuteReader(qrySelect);

        // 확인
        if (mReader.Read())
            ugrade = int.Parse(mReader["ugrade"].ToString());

        // 데이터베이스 닫기
        mReader.Close();
        DbMan.Close();

        // 반환값 리턴
        return ugrade;
    }
    public bool CheckAuth(object id, int auth)
    {
        //리턴값 초기화
        bool retValue = false;

        //로그인 되어야만 권한 확인이 가능
        if (id != null)
        {
            if (this.GetUgradeOfUserid(id.ToString()) >= auth)
                retValue = true;
        }

        //결과 리턴
        return retValue;
    }
}