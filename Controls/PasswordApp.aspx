<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PasswordApp.aspx.cs" Inherits="PasswordApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
    <tr>
        <td colspan="2">
            <h3>암호 확인: 동일한 암호를 입력하세요</h3>
        </td>
    </tr>
    <tr>
        <td>암호입력</td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" Width="240px" TextMode="Password"></asp:TextBox>
        </td>
     
    </tr>
    <tr>
        <td class="auto-style1">암호확인
        </td>
        <td class="auto-style1">

            <asp:TextBox ID="txtPasswordConfirm" runat="server" Width="241px" TextMode="Password"></asp:TextBox>

        </td>
    </tr>
                <tr>
                    <td>

                        <asp:Button ID="btnOk" runat="server" Text="확인" OnClick="btnOk_Click" />

                    </td>
                    <td>
                        <asp:Label ID="lblOutput" runat="server"></asp:Label>
                    </td>
                </tr>
</table>
        </div>
    </form>
</body>
</html>
