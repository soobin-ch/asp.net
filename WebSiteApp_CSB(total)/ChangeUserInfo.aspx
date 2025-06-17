<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="ChangeUserInfo.aspx.cs" Inherits="ChangeUserInfo" %>

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
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small; width: 205px;" >성명</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:TextBox ID="curName" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="296px"></asp:TextBox>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                   ControlToValidate="curName" ErrorMessage="성명을 입력해 주세요." 
                   ForeColor="#CC0000">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small; width: 205px;" >별명</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:TextBox ID="curNickname" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="296px"></asp:TextBox>
           </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                   ControlToValidate="curNickname" ErrorMessage="별명을 입력해 주세요." 
                   ForeColor="#CC0000">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small; width: 205px;">이메일</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:TextBox ID="curEmail" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="294px"></asp:TextBox>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                   ControlToValidate="curEmail" ErrorMessage="이메일 형식이 맞지 않습니다." 
                   ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                   ForeColor="#CC0000">*</asp:RegularExpressionValidator>
             </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small; width: 205px;">생년월일</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:DropDownList ID="listBirthYear" runat="server" AutoPostBack="True" 
                   style="font-family: '맑은 고딕'; font-size: medium" 
                   onselectedindexchanged="listBirthYear_SelectedIndexChanged" Width="66px">
               </asp:DropDownList>
               <asp:DropDownList ID="listBirthMonth" runat="server" AutoPostBack="True" 
                   style="font-family: '맑은 고딕'; font-size: medium" 
                   onselectedindexchanged="listBirthMonth_SelectedIndexChanged" Width="69px">
               </asp:DropDownList>
               <asp:DropDownList ID="listBirthDay" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="65px">
               </asp:DropDownList>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle"></td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small; width: 205px;">휴대전화</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:TextBox ID="curPhone" runat="server" 
                   style="font-size: medium; font-family: '맑은 고딕'" Width="296px"></asp:TextBox>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                   ControlToValidate="curPhone" ErrorMessage="휴대전화 번호를 입력하세요." 
                   ForeColor="#CC0000">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
           <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small; width: 205px;">주소</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:TextBox ID="curAddress" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: medium" Width="296px"></asp:TextBox>
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                   ErrorMessage="주소를 입력하세요." ControlToValidate="curAddress" 
                   ForeColor="#CC0000">*</asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
           <td style="width: 205px">&nbsp;</td>
           <td style="width:200px; text-align:left; vertical-align:middle">
               <asp:Button ID="btnRevise" runat="server" 
                   style="font-family: '맑은 고딕'; font-weight: 700; font-size: small" Text="회원정보수정" 
                   Width="135px" onclick="btnRevise_Click" />
               
             </td>
           <td style="width:400px; text-align:left; vertical-align:middle">
               <asp:Label ID="lblMessage" runat="server" ForeColor="Red" 
                   style="font-family: '맑은 고딕'; font-size: small"></asp:Label>
             </td>
         </tr>
         <tr>
           <td style="width: 205px">&nbsp;</td>
           <td colspan="2" style="width:600px; text-align:left; vertical-align:middle">
               <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                   style="font-family: '맑은 고딕'; font-size: small" ForeColor="#CC0000" />
             </td>
         </tr>
       </table>
</asp:Content>

