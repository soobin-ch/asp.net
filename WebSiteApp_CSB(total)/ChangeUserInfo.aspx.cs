using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class ChangeUserInfo : System.Web.UI.Page
{

   

    // MemberDao 클래스의 객체
    MemberDao mDao;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
{
    InitializeBirthYearMonth();

    // 기본 선택값
    int currentYear = DateTime.Now.Year;
    listBirthYear.SelectedValue = currentYear.ToString();
    listBirthMonth.SelectedValue = "01";
    InitializeBirthDay(currentYear.ToString(), "01");

    // DB 값 있으면 표시
    if (Session["userId"] != null)
    {
        memberInfo memberInfo = new MemberDao().GetMemberInfo(Session["userId"].ToString());

        curNickname.Text = memberInfo.Nickname;
        curName.Text = memberInfo.Name;
        curEmail.Text = memberInfo.Email;

        string birthday = memberInfo.birthDay.Trim();
        string[] birthParts = birthday.Split('-');

        string birthYear = birthParts[0];
        string birthMonth = birthParts[1];
        string birthDay = birthParts[2].PadLeft(2, '0'); // 생일의 일(day)이 한 자릿수일 경우 두 자릿수로 포맷팅

        listBirthYear.SelectedValue = birthYear;
        listBirthMonth.SelectedValue = birthMonth;

        // 생일 일자 선택 항목 초기화
        InitializeBirthDay(birthYear, birthMonth);

        // 생일 일자가 유효한지 확인하고 선택
        if (listBirthDay.Items.FindByValue(birthDay) != null)
        {
            listBirthDay.SelectedValue = birthDay;
        }
        else
        {
            // 유효하지 않으면 마지막 날짜 대신 기본값으로 설정
            listBirthDay.SelectedIndex = 0;  // 0번째로 선택된 날짜가 있다면 그 날짜로 설정
        }

        curPhone.Text = memberInfo.Phone;
        curAddress.Text = memberInfo.Address;
    }
}


    }


private void InitializeBirthYearMonth()
    {
        if (listBirthYear.Items.Count == 0)
        {
            int currentYear = DateTime.Now.Year;
            for (int year = 1901; year <= currentYear; year++)
            {
                listBirthYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            }
        }

        if (listBirthMonth.Items.Count == 0)
        {
            for (int month = 1; month <= 12; month++)
            {
                listBirthMonth.Items.Add(new ListItem(month.ToString("D2"), month.ToString("D2")));
            }
        }
    }

    private void InitializeBirthDay(string year, string month)
    {
        listBirthDay.Items.Clear();

        int y = int.Parse(year);
        int m = int.Parse(month);
        int dayMax = DateTime.DaysInMonth(y, m);

        for (int day = 1; day <= dayMax; day++)
        {
            listBirthDay.Items.Add(new ListItem(day.ToString("D2"), day.ToString("D2")));
        }
    }



protected void listBirthMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedDay =  listBirthDay.SelectedValue.PadLeft(2, '0');


        int selectedMonth = int.Parse(listBirthMonth.SelectedValue);
        int dayMax = DateTime.DaysInMonth(DateTime.Now.Year, selectedMonth);

        switch (listBirthMonth.SelectedValue.ToString())
        {
            case "2": dayMax = 29; break; // 12
            case "4":
            case "6":
            case "7":
            case "9":
            case "11": dayMax = 30; break;
            default: dayMax = 31; break;
        }

        //일에 해당하는 드랍다운리스트 항목 결정
         //1차적으로 기존의 Items 속성 제거
        listBirthDay.Items.Clear();

        // 반복문으로 일자에 해당하는 항목 추가
        for (int i = 1; i <= dayMax; i++)
            listBirthDay.Items.Add(new ListItem(i.ToString("D2"), i.ToString("D2")));


        if (listBirthDay.Items.FindByValue(selectedDay) != null)
        {
            listBirthDay.SelectedValue = selectedDay;
        }
        else
        {
            // 존재하지 않으면 마지막 날짜로 선택
            listBirthDay.SelectedIndex = listBirthDay.Items.Count - 1;
        }
    }

    protected void btnRevise_Click(object sender, EventArgs e)
    {
        string uid = Session["userId"].ToString();


        //입력정보 전달을 위해 MemberInfo 객체 생성
        memberInfo mDo = new memberInfo(curName.Text, curNickname.Text, curEmail.Text,
        listBirthYear.Text + "-" + listBirthMonth.Text + "-" + listBirthDay.Text, curPhone.Text, curAddress.Text);

        //MemberDao 객체 인스턴스 생성 및 연결
        mDao = new MemberDao();

        //UPdate 쿼리문을 이용한 회원가입
        if (mDao.updateUser(uid, mDo)) lblMessage.Text = "회원수정에 성공하였습니다.";
        else lblMessage.Text = "회원수정에 실패하였습니다.";
        //로그인 페이지로 이동하기

    }
    protected void listBirthYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        listBirthMonth_SelectedIndexChanged(sender, e);
    }

}