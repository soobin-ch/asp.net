<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TextBoxMode.aspx.cs" Inherits="TextBoxMode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style3 {
            margin-left: 4px;
        }
        .auto-style4 {
            width: 148px;
        }
        .auto-style5 {
            width: 92px;
        }
        .auto-style10 {
            width: 244px;
        }
        .auto-style11 {
            width: 92px;
            height: 32px;
        }
        .auto-style12 {
            width: 244px;
            height: 32px;
        }
        .auto-style13 {
            height: 32px;
        }
        .auto-style14 {
            width: 374px;
            margin-bottom: 7px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td class="auto-style4" colspan="3">
                        <h3 class="auto-style14">한 줄로 입력한 내용을 합치기</h3>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11" style="width:100px">입력창
                    </td>
                    <td class="auto-style12" style="width:200px"><asp:TextBox ID="txtInput" runat="server" Width="240px"></asp:TextBox>
                        </td>
                    <td class="auto-style13"><asp:Button ID="btnOk" runat="server" Text="&gt;&gt;" OnClick="btnOk_Click" /></td>
                </tr>
                <tr>
                    <td class="auto-style5">출력창</td>
                    <td class="auto-style10" colspan="2"><asp:TextBox ID="txtResult" runat="server" Height="175px" TextMode="MultiLine" CssClass="auto-style3" Width="224px"></asp:TextBox>

                    </td>

                </tr>
            </table>
        </div>
    </form>
</body>
</html>
