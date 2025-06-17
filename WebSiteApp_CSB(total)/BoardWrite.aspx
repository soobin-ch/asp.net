<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="BoardWrite.aspx.cs" Inherits="boardwrite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:725px">
        <tr>
            <td colspan="3" style="text-align:center; vertical-align:middle; ">
                <asp:Label ID="Label1" runat="server" BackColor="#CCCCFF" Text="게시판 글쓰기" width="725px" style="font-family:'맑은 고딕'; Font-Size:large; font-weight:500;"></asp:Label> 
            </td>  
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; height: 27px; width:100px">
                <asp:Label ID="Label2" runat="server" Text="작성자" Width="95px" style="font-family:'맑은 고딕';"></asp:Label> 
            </td>
            <td style="width:500px; text-align:center; vertical-align:middle; height: 27px;">
                <asp:TextBox ID="txtId" runat="server" ReadOnly="True" Width="495px" style="font-family: '맑은 고딕';"></asp:TextBox>
            </td>
            <td style="width:125px; text-align:left"></td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕';">
                <asp:Label ID="Label3" runat="server" Text="제목" Width="95px" style="font-family:'맑은 고딕';"></asp:Label>
            </td>
            <td style="text-align:center; vertical-align:middle">
                <asp:TextBox ID="txtTitle" runat="server" style="width:495px; font-family: '맑은 고딕';"></asp:TextBox>
            </td>
            <td style="text-align:left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" width="125px"
                    ErrorMessage="글 제목을 입력하세요..." ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕';">
                <asp:Label ID="Label4" runat="server" Text="내용" Width="95px" style="font-family:'맑은 고딕';"></asp:Label>
            </td>
            <td style="text-align:center; vertical-align:middle">
                <asp:TextBox ID="txtContents" runat="server" Height="140px" width="495px" TextMode="MultiLine"
                   style="font-family: '맑은 고딕'; margin-left: 2px; margin-top: 0px;" ></asp:TextBox>
            </td>
            <td style="text-align:left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContents" Width="125px"
                   ErrorMessage="글내용을 입력하세요..." ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕'; ">
                <asp:Label ID="Label5" runat="server" Text="파일첨부" Width="95px" style="font-family:'맑은 고딕';"></asp:Label>
            </td>
            <td style="text-align:center; vertical-align:middle">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="495px" style="font-family: '맑은 고딕';" />
                <br />
                <span ID="fileuploadYN"style="font-family: '맑은 고딕';"><span class="auto-style1">용량은 10M로 제한합니다. 10M가 초과되면 에러메시지 없이 파일첨부가 안됩니다.</span></span><br />
            </td>
            <td style="text-align:left"></td>
        </tr>
         <tr>
            <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕';"></td>
            <td style="text-align:center; vertical-align:middle">
                <asp:ImageButton ID="ibtnWrite" runat="server" ImageUrl="~/images/bbsWrite.jpg" Width="70px" OnClick="ibtnWrite_Click" />
                <asp:ImageButton ID="ibtnList" runat="server" ImageUrl="~/images/bbsList.jpg" CausesValidation="False" Width="70px" OnClick="ibtnList_Click" />
                <asp:ImageButton ID="ibtnModify" runat="server" ImageUrl="~/images/bbsModify.jpg" Width="70px" OnClick="ibtnModify_Click" />
            </td>
            <td style="text-align:left"></td>
        </tr>
        <tr>
            <td style="text-align:right; vertical-align:middle; font-family: '맑은 고딕';"></td>
            <td style="text-align:left; vertical-align:middle">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" style="font-family: '맑은 고딕';" />
            </td>
            <td style="text-align:left"></td>
        </tr>
    </table>
</asp:Content>

