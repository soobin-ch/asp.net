<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageMenuApp.aspx.cs" Inherits="ImageMenuApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="아래의 메뉴를 선택하세요..."></asp:Label>
            <br />
            <asp:ImageButton ID="ibtnMenu" runat="server" ImageUrl="~/menu.jpg" OnClick="ibtnMenu_Click" />
            <br />
            <asp:Label ID="lblOutput" runat="server" Text="선택한 메뉴 :"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
