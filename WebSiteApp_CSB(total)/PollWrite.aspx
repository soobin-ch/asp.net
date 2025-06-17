<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="PollWrite.aspx.cs" Inherits="pollwrite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table style="width:700px" border="0">
    <tr>
      <td colspan="4">
          <asp:Label ID="Label1" runat="server" BackColor="#99CCFF" Font-Bold="True" 
              Text="설문등록" Width="700px"></asp:Label>
      </td>
    </tr>
    <tr>
      <td style="text-align:right; vertical-align:middle; font-size: small; font-family: '맑은 고딕';">
          <b>질문</b>
      </td>
      <td style="text-align:left; vertical-align:middle" colspan="2">
          <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Height="62px" Width="390px" Font-Names="맑은 고딕" Font-Size="Small" style="font-family: '맑은 고딕'; font-size: small"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQuestion" ErrorMessage="질문을 입력해 주세요..." ForeColor="Red" style="font-family: '맑은 고딕'; font-size: small">*</asp:RequiredFieldValidator>
      </td>
      <td rowspan="3" style="width:200px; text-align:center; vertical-align:top; font-family: '맑은 고딕'; font-size: small">
          <b>마감일</b><br />
          <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
              Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px"  Width="200px">
              <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
              <NextPrevStyle VerticalAlign="Bottom" />
              <OtherMonthDayStyle ForeColor="#808080" />
              <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
              <SelectorStyle BackColor="#CCCCCC" />
              <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
              <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
              <WeekendDayStyle BackColor="#FFFFCC" />
          </asp:Calendar>
      </td>
    </tr>
    <tr>
      <td style="text-align:right; vertical-align:middle; font-size: small; font-family: '맑은 고딕';">
          <b>옵션</b>
      </td>
      <td style="text-align:left; vertical-align:middle" colspan="2">      
          <asp:RadioButtonList ID="rdoOpt" runat="server" RepeatDirection="Horizontal" Font-Names="맑은 고딕" Font-Size="Small">
              <asp:ListItem Selected="True">단일선택</asp:ListItem>
              <asp:ListItem>다중선택</asp:ListItem>
          </asp:RadioButtonList>
      </td>
    </tr>
    <tr>
      <td style="text-align:right; vertical-align:middle; font-size: small; font-family: '맑은 고딕';">
          <b>선택항목</b>
      </td>
      <td style="text-align:left; vertical-align:middle" colspan="2">      
          <asp:ListBox ID="lbxOptions" runat="server" Width="392px" Height="99px" AutoPostBack="True" onselectedindexchanged="lbxOption_SelectedIndexChanged" Font-Names="맑은 고딕" Font-Size="Small" style="font-family: '맑은 고딕'; font-size: small"></asp:ListBox>
      </td> 
    </tr>
    <tr>
      <td style="width:100px; height: 71px; text-align:right; vertical-align:middle; font-family: '맑은 고딕'; font-size: small;">
          <b>선택항목 <br /> 입력</b>
      </td>
      <td style="text-align:left; vertical-align:middle; width:300px; height: 71px;" colspan="2"> 
          <asp:TextBox ID="txtOption" runat="server" Width="383px" Height="47px" TextMode="MultiLine" Font-Names="맑은 고딕" Font-Size="Small" ></asp:TextBox>
      </td>
      <td style="text-align:left; vertical-align:middle; width:100px; height: 71px; ">   
          <asp:Button ID="btnAdd" runat="server" Text="추가" Width="100px" Font-Names="맑은 고딕" Font-Size="Small" onclick="btnAdd_Click" CausesValidation="False" Height="20px" />
          <br />
          <asp:Button ID="btnModify" runat="server" Text="수정" Width="100px" Font-Names="맑은 고딕" Font-Size="Small" onclick="btnModify_Click" CausesValidation="False" Height="20px" />
          <br />
          <asp:Button ID="btnDelete" runat="server" Text="삭제" Width="100px" Font-Names="맑은 고딕" Font-Size="Small" onclick="btnDelete_Click" CausesValidation="False" Height="20px"  />
      </td>
    </tr>
    <tr>
      <td style="text-align:center; vertical-align:middle" colspan="4">
          <asp:ImageButton ID="ibtnWrite" runat="server" ImageUrl="~/images/bbsWrite.jpg" onclick="ibtnWrite_Click" Visible="False" />
          <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/images/bbsCancel.jpg" 
              onclick="ibtnCancel_Click" CausesValidation="False" />
          <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
      </td>
    </tr>
    <tr>
      <td style="text-align:center; vertical-align:middle" colspan="4">
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
      </td>
</asp:Content>

