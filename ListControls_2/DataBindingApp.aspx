<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataBindingApp.aspx.cs" Inherits="DataBindingApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="데이터바인딩예제, 배열에서 항목을 가져옴"></asp:Label>
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
            <asp:Button ID="brnOk" runat="server" OnClick="brnOk_Click" Text="확인" />
            <br />
            <br />
            <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
