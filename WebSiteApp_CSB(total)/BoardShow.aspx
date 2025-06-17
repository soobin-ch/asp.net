<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="BoardShow.aspx.cs" Inherits="boardshow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table style="width:730px" border="1">
      <tr>
          <td colspan="5">
              <asp:Label ID="Label1" runat="server" BackColor="#CCCCFF" Text="게시판 글 상세보기" 
                Width="725px" style="font-family: '맑은 고딕'; font-size: large"></asp:Label>
          </td>
      </tr>
      <tr>
          <td style="height:25px; text-align:center; vertical-align:middle; font-family:'맑은 고딕'; font-size: small" >
              제&nbsp;&nbsp;목
          </td>
          <td colspan="4" style="text-align:center; vertical-align:middle;"">
              <asp:Label ID="lbltitle" runat="server" style="font-size: small; font-family: '맑은 고딕';">
              </asp:Label>
          </td>
      </tr>
      <tr>
          <td style="height:25px; font-family: '맑은 고딕'; font-size: small; text-align:center; vertical-align:middle;">
              작성자
          </td>
          <td style="text-align:center; vertical-align:middle;">
              <asp:Label ID="lblAuthor" runat="server" style="font-size: small; font-family: '맑은 고딕';">
              </asp:Label>
          </td>
          <td style="text-align:center; vertical-align:middle; font-size: small; font-family: '맑은 고딕';">
              조회수</td>
          <td colspan="2" style="font-family: '맑은 고딕'; font-size: small; text-align:center; vertical-align:middle">
              <asp:Label ID="lblHits" runat="server" style="font-family: '맑은 고딕'; font-size: small;">
              </asp:Label>
          </td>
      </tr>
      <tr>
          <td style="width:120px; font-family: '맑은 고딕'; font-size: small; text-align:center; vertical-align:middle;">
              작성일
          </td>
          <td style="width:200px; text-align:center; vertical-align:middle;">
              <asp:Label ID="lblUploadDate" runat="server" style="font-family: '맑은 고딕'; font-size: small;">
              </asp:Label>
          </td>
          <td style="width:120px; font-family: '맑은 고딕'; font-size: small; text-align:center; vertical-align:middle;">
              첨부파일
          </td>
          <td style="width:180px; text-align:center; vertical-align:middle;">
              <asp:Label ID="lblFname" runat="server" style="font-family: '맑은 고딕'; font-size: small">
              </asp:Label>
          </td>
          <td style="width:65px; text-align:center; vertical-align:middle;" >
              <%-- 다운로드 버튼을 이용하는 경우 현재의 브라우저에 다운로드가 실행됨 --%>
              <%--<asp:Button ID="btnDownload" runat="server" Text="다운로드" Enabled="False" onclick="btnDownload_Click" style="font-family: '맑은 고딕'; font-size: small" Width="65px" /> --%>
              <%-- 하이퍼링크를 이용하는 경우, 새로운 윈도우에서 다운로드 될 수 있게 할 수 있음 --%>
              <asp:HyperLink ID="hlDownload" NavigateUrl="~/Download.aspx" target="_blank" runat="server" Visible="False" style="font-family:'맑은 고딕'; font-size:small;" Text="Download"></asp:HyperLink>
          </td>
      </tr>
      <tr>
          <td style="height:25px; text-align:center; vertical-align:middle; font-family: '맑은 고딕'; font-size: small" >
              내&nbsp;&nbsp;용
          </td>
          <td colspan="4" style="text-align:left; vertical-align:middle;">
              <asp:Label ID="lblContents" runat="server" Width="600px" style="font-family: '맑은 고딕'; font-size: small">
              </asp:Label>
          </td>
      </tr>
      <tr>
          <td colspan="2" style="text-align:center; vertical-align:middle;">
              <asp:ImageButton ID="ibtnList" runat="server" Height="28px" ImageUrl="~/images/bbsList.jpg" Width="75px" onclick="ibtnList_Click" />
              <asp:ImageButton ID="ibtnModify" runat="server" Height="28px" ImageUrl="~/images/bbsModify.jpg" Width="75px" onclick="ibtnModify_Click" />
              <asp:ImageButton ID="ibtnDelete" runat="server" Height="28px" ImageUrl="~/images/bbsDelete.jpg" Width="75px" onclick="ibtnDelete_Click" />
          </td>
          <td colspan="3" style="text-align:left; vertical-align:middle">
              <asp:Label ID="lblMessage" runat="server" ForeColor="Red" style="font-size: small; font-family: '맑은 고딕';">
              </asp:Label>
          </td>
      </tr>
  </table>
</asp:Content>

