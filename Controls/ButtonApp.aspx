<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ButtonApp.aspx.cs" Inherits="ButtonApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        아래 버튼 중 하나를 클릭하세요.<br />
        <br />
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="버튼" />
        <br />
        <asp:LinkButton ID="lbtnOk" runat="server" OnClick="lbtnOk_Click">링크버튼</asp:LinkButton>
        <br />
        <asp:ImageButton ID="ibtnOk" runat="server" Height="139px" ImageUrl="~/mouse.jpg" OnClick="ibtnOk_Click" Width="152px" />
        <br />
        <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
