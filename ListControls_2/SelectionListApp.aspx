<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectionListApp.aspx.cs" Inherits="SelectionList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="RadioButtonList활용"></asp:Label>
            <br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem>선택항목A</asp:ListItem>
                <asp:ListItem>선택항목B</asp:ListItem>
                <asp:ListItem>선택항목C</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="lblRadio" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="2.CheckBoxList활용"></asp:Label>
            <br />
            <br />
            <br />
        </div>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
            <asp:ListItem>선택항목A</asp:ListItem>
            <asp:ListItem>선택항목B</asp:ListItem>
            <asp:ListItem>선택항목C</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <asp:Label ID="lblCheck" runat="server"></asp:Label>
        <br />
    </form>
</body>
</html>
