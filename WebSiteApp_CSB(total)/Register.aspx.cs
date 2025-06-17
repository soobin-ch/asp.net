using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    //모듈변수 선언 --> 클래스 전체에서 사용 가능한 변수
    //ID중복검사 여부 --> 중복검사를 하지 않으면 회원가입 안 됨

    //MemberDao 클래스의 객체 
  
        // 모듈 변수 선언 → 클래스 전체에서 사용 가능한 변수

        // ID 중복검사 여부 → 중복검사를 하지 않으면 회원가입 안 됨
        static bool isIdDuchecked = false;

        // MemberDao 클래스의 객체
        MemberDao mDao;
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) // LOH
        {
            int i; //반복처리하기 위한 변수
                   //생년월일의 생년 드롭다운리스트의 항목값 부여(1901~현재)
            int currentYear = int.Parse(DateTime.Now.Year.ToString());
            for (i =1901; i <= currentYear; i++)
                listBirthYear.Items.Add(new ListItem(i.ToString()));
            //연도에는 금년이 표시되도록 함
            //int test = i - 1901-1;
            listBirthYear.SelectedIndex = i - 1901- 1;
            //표시
            for (i = 1; i <= 12; i++)
                
                listBirthMonth.Items.Add(new ListItem(i.ToString()));
            //화면에 1월 표시
            listBirthMonth.SelectedIndex = 0;
            //일은 월을 선택하면 표시되게 함--> 원에 따라 29일, 30일, 31일 지정
            listBirthMonth_SelectedIndexChanged(sender, e);
            
}
    }

    protected void listBirthMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        int dayMax = 0;
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
            listBirthDay.Items.Add(new ListItem(i.ToString()));

    }

    protected void btnIdDupl_Click(object sender, EventArgs e)
    {
        mDao = new MemberDao();

        //ID값이 입력되어 있지 않으면 실행 곤란
        //--> ID중복검사는 Validation Control이 작용하고 있지 않기 때문에 프로그램으로 확인할 필요가 있음
        if (txtId.Text.Length <= 0)
        {
            lblMessage.Text = "ID를 입력하세요..";
            this.txtId.Focus();
            return;
        }

        if (isIdDuchecked =  mDao.VerifyUserID(txtId.Text))
        { 
    //중복검사 통과 --> 포커스를 비밀번호로 옮김
    lblMessage.Text = "이 사용자 ID를 이용할 수 있습니다."; this.txtPasswd1.Focus();
        }
        else
        //중복검사 실패 --> 사용자Id 항목을 삭제하고 포커스를 Id에 위치
        {
            lblMessage.Text = "이 사용자 ID를 이용할 수 없습니다.";
            this.txtId.Text = "";
            this.txtId.Focus();
        }
       
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (!isIdDuchecked)
        {
            lblMessage.Text = "ID 중복검사를 먼저 해주세요....";
            return;
        }

        //입력정보 전달을 위해 MemberDo 객체 생성
        MemberDo mDo = new MemberDo(txtId.Text, txtPasswd1.Text, txtName.Text, txtNickname.Text, txtEmail.Text,
        listBirthYear.Text + "-" + listBirthMonth.Text + "-" + listBirthDay.Text, txtPhone.Text, txtAddress.Text);

        //MemberDao 객체 인스턴스 생성 및 연결
        mDao = new MemberDao();

        //INSERT INTO 쿼리문을 이용한 회원가입
        if (mDao.RegisterUser(mDo) == 1) lblMessage.Text = "회원가입에 성공하였습니다.";
        else lblMessage.Text = "회원가입에 실패하였습니다.";
            //로그인 페이지로 이동하기
         
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //로그인 페이지로 이동하기
        Response.Redirect("login.aspx");
    }
}
