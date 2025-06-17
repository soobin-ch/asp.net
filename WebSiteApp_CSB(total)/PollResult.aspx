<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="PollResult.aspx.cs" Inherits="pollresult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table style="width:700px" border="0">
    <tr>
      <td colspan="3">
        <asp:Label ID="Label1" runat="server" BackColor="#99CCFF" Font-Bold="True" Text="설문결과" Width="700px"></asp:Label>
      </td>
    </tr>
    <tr>
      <td style="text-align:right; vertical-align:middle; width:80px; font-size: small"><b>질문</b></td>
      <td style="text-align:left; vertical-align:middle; width:540px">
        <asp:Label ID="lblQuestion" runat="server" BackColor="#CCFFFF" Font-Bold="True" Width="540px"></asp:Label><br /><br />
      </td>
      <td style="width:80px"></td>
    </tr>
    <tr>
      <td style="text-align:right; vertical-align:middle; font-size: small"><b>선택항목</b></td>
      <td  style="text-align:left; vertical-align:middle">      
        <asp:GridView ID="grvOptions" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" ShowHeader="False" Width="540px">
          <Columns>
            <asp:TemplateField ItemStyle-Width="20px" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
              <ItemTemplate>
                <img src="images/bbsArrow.jpg" style="width:15px" alt="">
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="520px">
               <ItemTemplate>
                 <%#Eval("option") %> <br />
                 <img src="images/bbsBar.jpg" style="height:10px" width='<%#GetGraphWidth(Eval("hits")) %>'/>&nbsp;&nbsp;
                 <%#Eval("hits") %>명 &nbsp;&nbsp;
                 <%#GetPercent(Eval("hits")) %>%
               </ItemTemplate>
            </asp:TemplateField>           
          </Columns>
          <FooterStyle BackColor="White" ForeColor="#000066" />
          <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
          <RowStyle ForeColor="#000066" />
          <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
          <SortedAscendingCellStyle BackColor="#F1F1F1" />
          <SortedAscendingHeaderStyle BackColor="#007DBB" />
          <SortedDescendingCellStyle BackColor="#CAC9C9" />
          <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
      </td>
      <td>
      </td>
    </tr>
    <tr>
      <td style="text-align:center; vertical-align:middle; height: 24px">
      </td>
      <td style="text-align:left; vertical-align:middle">
        <hr />
      </td>
    </tr>
    <tr>
      <td style="text-align:center; vertical-align:middle; height: 24px">
      </td>
      <td style="text-align:center; vertical-align:middle">
        <span style="font-size: small; font-family: '맑은 고딕'">
        <strong>
           총응답자 : 
           <asp:Label ID="lblTotalHits" runat="server"></asp:Label>명&nbsp;&nbsp; 
           설문기간 : 
           <asp:Label ID="lblDuration" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp; 
           설문요청자 : 
           <asp:Label ID="lblDemander" runat="server" style="font-weight: 700"></asp:Label>
        </strong>
        </span>      
      </td>
      <td></td>
    </tr>
    <tr>
      <td style="text-align:center; vertical-align:middle; height: 24px">
      </td>
      <td style="text-align:left; vertical-align:middle">
         <hr />
      </td>
      <td></td>
    </tr>
    <tr>
      <td style="text-align:center; vertical-align:middle; height: 24px">
      </td>
       <td style="text-align:center; vertical-align:middle">
          <asp:ImageButton ID="ibtnList" runat="server" ImageUrl="~/images/bbsList.jpg" onclick="ibtnList_Click" />
      </td>
    </tr>
  </table>

</asp:Content>

