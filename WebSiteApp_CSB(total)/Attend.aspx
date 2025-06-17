<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="Attend.aspx.cs" Inherits="attend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="width:730px">
         <tr>
           <td style="text-align:left; vertical-align:middle;" colspan="3">
              <asp:Label ID="Label1" runat="server" Text="출석부 (방문 흔적을 남겨 주세요)" 
                  BackColor="#CCCCFF" 
                  style="font-family: '맑은 고딕'; font-size: medium; font-weight: 700" 
                  Width="700px" Height="25px"></asp:Label>
              <br />
           </td>
         </tr>
         <tr>
           <td style="text-align:center; vertical-align:top;" colspan="3">
              <asp:GridView ID="grvAttend" runat="server" AutoGenerateColumns="true" 
                  CellPadding="4" ForeColor="#333333" GridLines="None" 
                  AllowPaging="True" onpageindexchanging="grvAttend_PageIndexChanging" 
                  style="font-size: small" Width="700px">
             <Columns>

            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             </asp:GridView>
             <hr style="color:blue" />
           </td>
         </tr>
         <tr>
           <td style="text-align:left; vertical-align:middle;" colspan="3">
              <asp:Label ID="Label2" runat="server" Text="글 쓰기 (내용은 50자로 제한됩니다.)" 
                   style="font-family: '맑은 고딕'; font-size: medium; font-weight: 700;"></asp:Label>    
              <br />
           </td>
         </tr>
         <tr>
           <td style="width:100px; text-align:right; vertical-align:middle;">
              <asp:Label ID="Label3" runat="server" 
                  style="font-family: '맑은 고딕'; font-size: medium" Text="내용"></asp:Label>
           </td>
           <td style="width:530px; text-align:right; vertical-align:middle;">
              <asp:TextBox ID="txtContents" runat="server" TextMode="MultiLine" Width="530px"></asp:TextBox>
           </td>
           <td style="width:100px; text-align:left; vertical-align:middle;">
              <asp:Button ID="btnWrite" runat="server" onclick="btnWrite_Click" Text="저장" 
                   style="font-family: '맑은 고딕'; font-size: medium" />    
           </td>
         </tr>
       </table>
</asp:Content>

