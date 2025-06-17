<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlbumShow.aspx.cs" Inherits="albumshow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table style="width:900px">
        <tr>
          <td style="width:800px; text-align:left; vertical-align:middle;">
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="Medium" BackColor="#CCCCFF">
            </asp:Label>
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="Small" ForeColor="#CC0000">
            </asp:Label>
           </td>
           <td style="width:100px; text-align:right; vertical-align:middle;">
            <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/images/bbsDelete.jpg" onclick="ibtnDelete_Click"  onclientclick="javascript:if(confirm('정말 삭제하시겠습니까?\n\n삭제하면 복구가 불가능합니다.')) {return true;} else{return false;}" Visible="False"  />
          </td>
        </tr>
        <tr>
          <td colspan="2" style="text-align:center; vertical-align:top;">
              <asp:Image ID="imgMain" runat="server" Width="900px" />
          </td>
        </tr>
      </table>      
    </div>
    </form>
</body>
</html>
