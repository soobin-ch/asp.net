﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropDownListApp.aspx.cs" Inherits="DropDownListApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="확인" />
            <br />
            <asp:Label ID="lblResult1" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblResult2" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
