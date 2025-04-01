<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhysicalDir.aspx.cs" Inherits="PhysicalDir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>물리적 디렉토리 구하기 -> 파일 입출력에서 사용</h4>
            <hr />
            <br />
            현재 AP.NET의 경로 ===> <asp:Label ID ="Label1" runat="server" Text="Label1"></asp:Label>
            <br />
            /디렉토리의 경로 ===> <asp:Label ID="Label2" runat="server" Text="Label2"></asp:Label>
        </div>
    </form>
</body>
</html>
