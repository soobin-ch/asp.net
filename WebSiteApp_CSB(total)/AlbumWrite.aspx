<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="AlbumWrite.aspx.cs" Inherits="albumwrite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:700px">
    <tr>
      <td style="text-align:right; vertical-align:middle" colspan="5">
        <asp:Label ID="Label1" runat="server" BackColor="#CCCCFF" Text="앨범에 사진 올리기" Width="700px" style="font-family: '맑은 고딕'; font-size: large; text-align: left;" Font-Bold="True"></asp:Label>
      </td>
    </tr>
    <tr>
      <td style="font-family: '맑은 고딕'; font-size: small; width: 90px; text-align:right; vertical-align:middle" ><b>작성자</b></td>
      <td style="width:520px; text-align: left; vertical-align:middle" colspan="3">
        <asp:TextBox ID="txtId" runat="server" ReadOnly="True" Width="520px" BorderStyle="None" style="font-family: '맑은 고딕'"></asp:TextBox>
      </td>
      <td style="width:90px; text-align: left; vertical-align:middle">
      </td>
    </tr>
    <tr>
      <td style="font-family: '맑은 고딕'; font-size: small; text-align:right; vertical-align:middle" ><b>사진제목</b></td>
      <td style="text-align: left; vertical-align:middle" colspan="3">
        <asp:TextBox ID="txtTitle" runat="server" Width="520px" style="font-family: '맑은 고딕'" MaxLength="20"></asp:TextBox>
      </td>
      <td style=" text-align: left; vertical-align:middle">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="txtTitle" ErrorMessage="글 제목을 입력하세요..."  ForeColor="Red">*</asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td  style="font-family: '맑은 고딕'; font-size: small; text-align:right; vertical-align:middle">
          <b>사진설명</b>
      </td>
      <td style="text-align: left; vertical-align:middle" colspan="3">
        <asp:TextBox ID="txtComment" runat="server" Height="137px" TextMode="MultiLine" Width="520px" style="font-family: '맑은 고딕'" MaxLength="500" ></asp:TextBox>
      </td>
      <td style=" text-align: left; vertical-align:middle">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ControlToValidate="txtComment" ErrorMessage="글내용을 입력하세요..." ForeColor="Red">*</asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
      <td style="font-family: '맑은 고딕'; font-size: small; text-align:right; vertical-align:middle">
          <b>사진찾기</b>
      </td>
      <td style="text-align: left; vertical-align:middle" colspan="3">
         <asp:FileUpload ID="fileUpload1" runat="server" Width="520px" style="font-family: '맑은 고딕'" />&nbsp;<br />
          <span style="font-family: '맑은 고딕'; font-size: small">용량은 10M로 제한됩니다. 10M를 초과하면 에러메시지 없이 업로드되지 않습니다.
          </span>
      </td>
    </tr>
    <tr>
      <td style="font-family: '맑은 고딕'; font-size: small; text-align:right; vertical-align:middle"></td>
      <td style="width:70px; text-align: center; vertical-align:middle">
        <asp:ImageButton ID="ibtnWrite" runat="server" ImageUrl="~/images/bbsWrite.jpg" onclick="ibtnWrite_Click" />
      </td>
      <td style="width:70px; text-align: center; vertical-align:middle">
        <asp:ImageButton ID="ibtnList" runat="server" CausesValidation="False" ImageUrl="~/images/bbsList.jpg" onclick="ibtnList_Click" />
      </td>
      <td style="width:380px; text-align: left; vertical-align:middle">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="Small" ForeColor="#CC0000"></asp:Label>
      </td>
      <td style=" text-align: left; vertical-align:middle">
      </td>
    </tr>
    <tr>
      <td style="font-family: '맑은 고딕'; font-size: small; text-align:right; vertical-align:middle"></td>
      <td style="text-align: left; vertical-align:middle" colspan="3">
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
      </td>
      <td style=" text-align: left; vertical-align:middle">
      </td>
    </tr>
  </table>

</asp:Content>

