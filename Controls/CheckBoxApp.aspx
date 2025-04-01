<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckBoxApp.aspx.cs" Inherits="CheckBoxApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            어떤 프로그래밍 언어를 선호하시나요?<br />
            <br />
            <asp:CheckBox ID="chkCs" runat="server" Text="Visual C# Programming" />
            <br />
            <asp:CheckBox ID="chkVb" runat="server" Text="Visual Basic Programming" />
            <br />
            <asp:CheckBox ID="chkJava" runat="server" Text="Java Programming" />
            <br />
            <br />
            <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="확인" />
            <br />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
