<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RadioButtonApp.aspx.cs" Inherits="RadioButtonApp" %>

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
    <asp:RadioButton ID="rdoCs" runat="server" Text="Visual C# Programming" Checked="True" GroupName="P1" />
    <br />
    <asp:RadioButton ID="rdoVb" runat="server" Text="Visual Basic Programming" GroupName="P1" />
    <br />
    <asp:RadioButton ID="rdoJava" runat="server" Text="Java Programming" GroupName="P1" />
    <br />
    <br />
    <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="확인" />
            <br />
    <br />
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</div>
    </form>
</body>
</html>
