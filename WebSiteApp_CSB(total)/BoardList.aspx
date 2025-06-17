<%@ Page Title="" Language="C#" MasterPageFile="~/sProfile.master" AutoEventWireup="true" CodeFile="BoardList.aspx.cs" Inherits="boardlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <table style="width: 720px">
   <tr>
    <td style="text-align:left; vertical-align:top" colspan="2">
        <asp:Label ID="lblBbsTitle" runat="server" BackColor="LightSkyBlue" Text="공지사항" 
            Width="700px" style="font-family: '맑은 고딕'; font-weight: 700"></asp:Label>
    </td>
   </tr>
   <tr>
     <td style="text-align:left; vertical-align:top" colspan="2">
       <asp:GridView ID="grvBoard" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" CaptionAlign="Bottom" 
            style="font-family: '맑은 고딕'; font-size: small" Width="700px" OnPageIndexChanging="grvBoard_PageIndexChanging">
        <Columns>
          <asp:BoundField DataField="no" HeaderText="번호" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
          </asp:BoundField>
          <asp:TemplateField ItemStyle-Width="15px">
            <ItemTemplate >
              <img src="images/bbsNote.jpg" style="width:15px" alt="">
            </ItemTemplate>
          </asp:TemplateField>
          <%--로그인 안되었을 때, 상세보기 권한을 주지 않으려면 다음 방법을 사용 --%>
          <%--<asp:TemplateField HeaderText="제목" ItemStyle-Width="250px">
            <ItemTemplate >
              <asp:HyperLink ID="hyperLink1" runat="server" 
                  NavigateUrl='<%# GetShowUrl(Eval("no")) %>' Text='<%# Eval("title") %>' > 
              </asp:HyperLink>
            </ItemTemplate>
          </asp:TemplateField> --%>
          <%-- Eval() 함수의 출력스트링을 이용하고자 할 때에는 다음 방법을 사용  --%>
          <%--<asp:TemplateField HeaderText="제목" ItemStyle-Width="250px">
            <ItemTemplate >
              <asp:HyperLink ID="hyperLink1" runat="server" 
                  NavigateUrl='<%# Eval("no", "boradshow.aspx?no={0}") %>' Text='<%# Eval("title") %>'>
              </asp:HyperLink>    
            </ItemTemplate>
          </asp:TemplateField> --%>
          <%-- 공지사항은 누구나 읽어야 하므로 권한 설정이 필요 없음, 이 경우에는 <asp:HyperLinkField> 열템플릿을 이용하는 것이 가장 편리함--%>
          <asp:HyperLinkField HeaderText="제목" DataNavigateUrlFields="no" DataNavigateUrlFormatString="boardshow.aspx?no={0}" DataTextField="title" ItemStyle-Width="250px" />
          <asp:BoundField DataField="nickname" HeaderText="이름" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" >
          </asp:BoundField>
          <asp:TemplateField HeaderText="글쓴 날짜" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate> <%# Eval("uploadTime","{0:yyyy/MM/dd}") %></ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="hits" HeaderText="조회" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
          </asp:BoundField>
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
      </asp:GridView>
     </td>
   </tr>
   <tr>
     <td style="width:200px; text-align:left; vertical-align:middle">
      <asp:ImageButton ID="ibtnWrite" runat="server" Height="31px" 
          ImageUrl="~/images/bbsWrite.jpg" Width="83px" 
          onclick="ibtnWrite_Click" Visible="False" />
     </td>
     <td style="width:530px; text-align:left; vertical-align:middle">
         <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
     </td>   
   </tr>
 </table>
</asp:Content>

