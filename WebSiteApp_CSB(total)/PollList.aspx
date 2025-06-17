<%@ Page Title="" Language="C#" MasterPageFile="~/sBbs.master" AutoEventWireup="true" CodeFile="PollList.aspx.cs" Inherits="polllist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table style="width:700px" border="0">
    <tr> 
      <td style="height: 32px; text-align:left; vertical-align:middle" colspan="3">
          <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="맑은 고딕" 
              Font-Size="Medium" Text="설문목록" Width="700px" BackColor="#99CCFF"></asp:Label>
      </td>
    </tr>
    <tr>
      <td style="text-align:left; vertical-align:middle"  colspan="3">
          <asp:GridView ID="grvQuestions" runat="server" AllowPaging="True" 
              AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" 
              BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" 
              Width="700px" onpageindexchanging="grvQuestions_PageIndexChanging">
              <Columns>
                 <asp:BoundField HeaderText="질문" DataField="qContents" >
                  <itemStyle Width="360px" VerticalAlign="Middle" />
                     </asp:BoundField>
                  <asp:TemplateField HeaderText="요구자">
                      <ItemTemplate><%#Eval("nickname") %> (<%#Eval("demander") %>)</ItemTemplate> 
                      <ItemStyle Width="120px" HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="종료일">
                      <ItemTemplate><%#Eval("duedate","{0:yyyy/MM/dd}") %></ItemTemplate> 
                      <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="투표참여">
                      <ItemTemplate>
                          <asp:HyperLink ID="hyperlink1" runat="server"
                              imageUrl='<%#GetVoteFig(Eval("qId")) %>'
                              NavigateUrl='<%#GetVoteUrl(Eval("qId")) %>'>

                          </asp:HyperLink>
                      </ItemTemplate>
                      <ItemStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="결과보기">
                      <ItemTemplate>
                          <asp:HyperLink ID="hyperlink2" runat="server"
                               ImageUrl="images/bbsResult.jpg"
                              NavigateUrl='<%#GetResultUrl(Eval("qId")) %>'>

                          </asp:HyperLink>
                      </ItemTemplate>
                      <ItemStyle Width="70px" HorizontalAlign="Center" />
                  </asp:TemplateField>
              </Columns>
              <AlternatingRowStyle BackColor="#F7F7F7" />
              <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
              <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
              <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
              <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
              <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
              <SortedAscendingCellStyle BackColor="#F4F4FD" />
              <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
              <SortedDescendingCellStyle BackColor="#D8D8F0" />
              <SortedDescendingHeaderStyle BackColor="#3E3277" />
          </asp:GridView>
      </td>
    </tr>
    <tr>
      <td style="width:300px; text-align:right; vertical-align:middle">
          <asp:ImageButton ID="ibtnInsertPoll" runat="server" Height="28px" 
              ImageUrl="~/images/bbsInsertPoll.jpg" Width="97px" 
              onclick="ibtnInsertPoll_Click" Visible="False" />
        </td>
        <td style="width:300px; text-align:right; vertical-align:middle">
          <asp:TextBox ID="txtKword" runat="server"></asp:TextBox>
        </td>
        <td style="width:400px; text-align:left; vertical-align:middle">
          <asp:ImageButton ID="ibtnSearch" runat="server" Height="28px" 
              ImageUrl="~/images/bbsSearch.jpg" Width="78px" 
              onclick="ibtnSearch_Click" />
        </td>
    </tr>
    <tr>
        <td style="text-align:center; vertical-align:middle" colspan="3"> 
          <asp:Label ID="lblMessage" runat="server" Font-Names="맑은 고딕" Font-Size="Small" 
              ForeColor="Red"></asp:Label>
      </td>
    </tr>
  </table>

</asp:Content>

