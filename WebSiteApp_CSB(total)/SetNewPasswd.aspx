<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="SetNewPasswd.aspx.cs" Inherits="setNewPasswd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:700px">
        <tr>
            <td colspan="3" style="text-align:left;vertical-align:middle">
                <asp:Label ID="Label1" width="700px" runat="server" Text="비밀번호 재설정" BackColor="SkyBlue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle; width:100px">Id</td>
            <td style="text-align:left; vertical-align:middle; width:300px">
                <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:middle; width:300px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle">성명</td>
            <td style="text-align:left; vertical-align:middle">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle">생년월일</td>
            <td style="text-align:left; vertical-align:middle">
                <asp:DropDownList ID="ddlYear" Width="100px" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="ddlMonth" Width="50px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="ddlDay" Width="70px" runat="server"></asp:DropDownList>
            </td>
            <td style="text-align:left; vertical-align:middle"></td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle"></td>
            <td style="text-align:left; vertical-align:middle" colspan="2">
                <asp:Button ID="btnAuthenticate" runat="server" Text="본인인증" OnClick="btnAuthenticate_Click" CausesValidation="False" />
                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" OnClick="btnCancel_Click" Text="취소" />
                <asp:Label ID="lblResult" runat="server" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle; height: 23px">새 비밀번호</td>
            <td style="text-align:left; vertical-align:middle">
                <asp:TextBox ID="txtPw1" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:middle" >
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="비밀번호룰 입력해 주세요." ControlToValidate="txtPw1" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle; width:100px">비밀번호확인</td>
            <td style="text-align:left; vertical-align:middle">
                <asp:TextBox ID="txtPw2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:middle">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="비밀번호가 일치하지 않습니다." ControlToCompare="txtPw1" ControlToValidate="txtPw2" ForeColor="#CC0000">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle"></td>
            <td style="text-align:left; vertical-align:middle" colspan="2">
                <asp:Button ID="SetPasswd" runat="server" Text="비밀번호변경" OnClick="SetPasswd_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle"> </td>
            <td style="text-align:left; vertical-align:middle" colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" />
            </td>
        </tr>
    </table>
</asp:Content>

