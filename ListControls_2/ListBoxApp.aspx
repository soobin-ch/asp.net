<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListBoxApp.aspx.cs" Inherits="ListBoxApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
    <tr style="text-align:center">
        <td class="auto-style6">
            <asp:Label ID="Label1" runat="server" Text="단일선택동작"></asp:Label>
        </td>
         <td class="auto-style5">
             <asp:Label ID="Label2" runat="server" Text="다중선택동작"></asp:Label>
        </td>
         <td class="auto-style4"></td>
    </tr>
    <tr>
        <td class="auto-style6">
            <asp:ListBox ID="ListBox1" runat="server">
                <asp:ListItem>1. 리스트 항목</asp:ListItem>
                <asp:ListItem>2.리스트 항목</asp:ListItem>
                <asp:ListItem>3.리스트 항목</asp:ListItem>
            </asp:ListBox>
        </td>
        <td class="auto-style5">
            <asp:ListBox ID="ListBox2" runat="server" SelectionMode="Multiple"></asp:ListBox>
        </td>
        <td class="auto-style4">
            <asp:Button ID="btnOk" runat="server" Text="확인" ValidateRequestMode="Disabled" OnClick="btnOk_Click" />
        </td>
    </tr>
    <tr>
         <td class="auto-style6">
             <asp:Label ID="lblResult1" runat="server"></asp:Label>
         </td>
         <td class="auto-style5">
             <asp:Label ID="lblResult2" runat="server"></asp:Label>
         </td>
         <td class="auto-style4"></td>
    </tr>
</table>
        </div>
    </form>
</body>
</html>
