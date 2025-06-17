<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:700px">
    <tr>
      <td colspan="3" style="text-align:left;vertical-align: middle">
          <asp:Label ID="Label2" runat="server" BackColor="#CCCCFF" Height="24px" 
              style="font-family: '맑은 고딕'; font-weight: 700" Text="로그인" Width="700px"></asp:Label>
      </td>
    </tr>
    <tr>
      <td style="width:100px; text-align:right; vertical-align:middle">
          사용자ID</td>
      <td style="width:200px; text-align:left; vertical-align:middle">
          <asp:TextBox ID="txtId" runat="server" style="font-family: '맑은 고딕'" 
              Width="195px" ></asp:TextBox>
      </td>
      <td style="width:400px; text-align:left;vertical-align: middle">
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
              ControlToValidate="txtID" ErrorMessage="사용자ID를 입력해주세요..." 
              style="font-family: '맑은 고딕'; font-size: small; font-weight: 700">
          </asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td style="text-align:right; vertical-align:middle">
          비밀번호</td>
      <td style="text-align:left; vertical-align:middle">
          <asp:TextBox ID="txtPasswd" runat="server" style="font-family: '맑은 고딕'" 
              Width="194px" TextMode="Password" ></asp:TextBox>
      </td>
      <td style="text-align:left; vertical-align:middle">
      </td>
    </tr>
    <tr>
      <td style="text-align:right; vertical-align:middle">
      </td>
      <td style="text-align:left; vertical-align:middle">
          <asp:ImageButton ID="ibtnLogin" runat="server" 
              ImageUrl="~/images/login_border.JPG" OnClick="ibtnLogin_Click" />
          <asp:ImageButton ID="ibtnRegister" runat="server" 
              ImageUrl="~/images/register.JPG" 
              CausesValidation="False" OnClick="ibtnRegister_Click" />
      </td>
      <td style="text-align:left; vertical-align:middle">
          <asp:LinkButton ID="lbtnFinfId" runat="server" CausesValidation="False" Font-Size="Small" OnClick="lbtnFinfId_Click">id찾기</asp:LinkButton>
          <asp:LinkButton ID="lbtnSetNewPw" runat="server" CausesValidation="False" Font-Size="Small" OnClick="lbtnSetNewPw_Click">pw재설정</asp:LinkButton>
          <asp:Label ID="lblMessage" runat="server" ForeColor="Red" 
              style="font-family: '맑은 고딕'; font-weight: 700; font-size: small"></asp:Label>
      </td>
    </tr>
  </table>
</asp:Content>

