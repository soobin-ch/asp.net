<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <table style="width:700px">
         <tr>
           <td colspan="3" style="text-align:left; vertical-align:middle" >
               <asp:Label ID="Label2" runat="server" BackColor="#CCCCFF" Text="회원가입" 
                   Width="700px"></asp:Label>
             </td>
         </tr>
         <tr>
           <td colspan="3" style="text-align:left; vertical-align:middle; font-family: '맑은 고딕'; font-size: small">회원가입을 하시려면 모든 항목에 입력하여야 합니다.
           </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; width:150px; font-family: '맑은 고딕'; font-size: small;">사용자ID</td>
           <td style="width:250px; text-align:left; vertical-align:middle" >
               <asp:TextBox ID="txtId" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="296px"></asp:TextBox>
             </td>
           <td style="width:300px; text-align:left; vertical-align:middle" >
               <asp:Button ID="btnIdDupl" runat="server" CausesValidation="False" 
                   style="font-family: '맑은 고딕'; font-size: small; font-weight: 700" Text="ID중복검사" 
                   Width="77px" onclick="btnIdDupl_Click" />
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                   ControlToValidate="txtId" ErrorMessage="사용자ID를 입력해 주세요..." 
                   ForeColor="#CC0000">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small">암호</td>
           <td style="width:200px; text-align:left; vertical-align:middle" >
               <asp:TextBox ID="txtPasswd1" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" TextMode="Password" 
                   Width="296px"></asp:TextBox>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle" >
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                   ControlToValidate="txtPasswd1" ErrorMessage="암호를 입력해 주세요." 
                   ForeColor="#CC0000">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small">암호확인</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:TextBox ID="txtPasswd2" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" TextMode="Password" 
                   Width="296px"></asp:TextBox>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:CompareValidator ID="CompareValidator1" runat="server" 
                   ControlToCompare="txtPasswd1" ControlToValidate="txtPasswd2" 
                   ErrorMessage="암호가 일치하지 않습니다." ForeColor="#CC0000">*</asp:CompareValidator>
             </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small" >성명</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:TextBox ID="txtName" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="296px"></asp:TextBox>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                   ControlToValidate="txtName" ErrorMessage="성명을 입력해 주세요." 
                   ForeColor="#CC0000">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small" >별명</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:TextBox ID="txtNickname" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="296px"></asp:TextBox>
           </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                   ControlToValidate="txtNickname" ErrorMessage="별명을 입력해 주세요." 
                   ForeColor="#CC0000">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small">이메일</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:TextBox ID="txtEmail" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="294px"></asp:TextBox>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                   ControlToValidate="txtEmail" ErrorMessage="이메일 형식이 맞지 않습니다." 
                   ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                   ForeColor="#CC0000">*</asp:RegularExpressionValidator>
             </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small">생년월일</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:DropDownList ID="listBirthYear" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="66px">
               </asp:DropDownList>
               <asp:DropDownList ID="listBirthMonth" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" AutoPostBack="True" 
                   onselectedindexchanged="listBirthMonth_SelectedIndexChanged" Width="69px">
               </asp:DropDownList>
               <asp:DropDownList ID="listBirthDay" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="65px">
               </asp:DropDownList>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle"></td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small">휴대전화</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:TextBox ID="txtPhone" runat="server" 
                   style="font-size: medium; font-family: '맑은 고딕'" Width="296px"></asp:TextBox>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                   ControlToValidate="txtPhone" ErrorMessage="휴대전화 번호를 입력하세요." 
                   ForeColor="#CC0000">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small">주소</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:TextBox ID="txtAddress" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="296px"></asp:TextBox>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                   ErrorMessage="주소를 입력하세요." ControlToValidate="txtAddress" 
                   ForeColor="#CC0000">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
           <td>&nbsp;</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:Button ID="btnRegister" runat="server" 
                   style="font-family: '맑은 고딕'; font-weight: 700; font-size: small" Text="회원가입" 
                   Width="80px" onclick="btnRegister_Click" />
               <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                   style="font-family: '맑은 고딕'; font-size: small; font-weight: 700" Text="로그인" 
                   Width="80px" onclick="btnCancel_Click" />
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:Label ID="lblMessage" runat="server" ForeColor="Red" 
                   style="font-family: '맑은 고딕'; font-size: small"></asp:Label>
             </td>
         </tr>
         <tr>
           <td>&nbsp;</td>
           <td colspan="2" style="width:600px; text-align:left; vertical-align:middle">
               <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: small" ForeColor="#CC0000" />
             </td>
         </tr>
       </table>
</asp:Content>

