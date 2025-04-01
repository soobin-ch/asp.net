<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CookieAppl.aspx.cs" Inherits="CookieAppl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" Text="웹 사이트 방문을 환영합니다."></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="새로 고침" />
        </div>
    </form>
</body>
</html>
