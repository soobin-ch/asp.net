<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="FindUserId.aspx.cs" Inherits="findUserId" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="width:700px">
        <tr>
            <td colspan="3" style="text-align:left; vertical-align:middle">
                <asp:Label ID="Label1" width="700px" runat="server" Text="사용자 Id 찾기" BackColor="SkyBlue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle; width:100px">성명</td>
            <td style="text-align:left; vertical-align:middle; width:400px">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td style="text-align:left; vertical-align:middle; width:200px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="성명을 입력해 주세요." ControlToValidate="txtName" EnableViewState="False" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle">전화번호</td>
            <td style="text-align:left; vertical-align:middle; width: 400px;">
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                (번호를 - 로 구분)</td>
            <td style="text-align:left; vertical-align:middle">                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="전화번호를 입력해 주세요." ControlToValidate="txtPhone" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle; height: 27px;">
            </td>
            <td style="text-align:left; vertical-align:middle; height: 27px;" colspan="2">
                <asp:Button ID="btnFind" runat="server" Text="찾기" OnClick="btnFind_Click" />
                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" OnClick="btnCancel_Click" Text="로그인"/>
                <asp:Label ID="lblResult" runat="server" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  style="text-align:right; vertical-align:middle""> </td>
            <td style="text-align:left; vertical-align:middle" colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" />
            </td>
        </tr>
    </table>
</asp:Content>

