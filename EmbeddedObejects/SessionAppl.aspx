<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionAppl.aspx.cs" Inherits="SessionAppl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 190px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
              <td colspan="2" style="text-align:center">
                  <asp:Label ID="Label1" runat="server" Text="Session예제"></asp:Label>
              </td>
        </tr>
        <tr>
            <td style="text-align:right"></td>
            <td style="text-align:left" class="auto-style1">
                <asp:Label ID="Label2" runat="server" Text="아이디"></asp:Label>
                :
                <asp:TextBox ID="txtId" runat="server" Width="95px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="text-align:right"></td>
            <td style="text-align:left" class="auto-style1">
                <asp:Label ID="Label3" runat="server" Text="이름:"></asp:Label>
&nbsp;&nbsp;
                <asp:TextBox ID="txtName" runat="server" Width="91px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="확인" />
            </td>
        </tr>
    </table>

    </form>

    </body>
</html>
