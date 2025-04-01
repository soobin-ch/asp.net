   <%@ Page Language="C#" AutoEventWireup="true" CodeFile="HyperLinkApp.aspx.cs" Inherits="HyperLinkApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            태그바디 이용:
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.doowon.ac.kr" ToolTip="두원공대 홈페이지">두원공과대학교
            </asp:HyperLink>
            <br />
            <br />
            문자열 이용 :
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.doowon.ac.kr" ToolTip="두원공대 홈페이지">두원공과대학교</asp:HyperLink>
            <br />
            <br />
            이미지 이용:&nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/doowon.jpg" NavigateUrl="http://www.doowon.ac.kr" ToolTip="두원공대 홈페이지">HyperLink</asp:HyperLink>
        </div>
    </form>
</body>
</html>
