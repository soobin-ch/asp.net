<%@ Page Title="" Language="C#" MasterPageFile="~/sCommon.master" AutoEventWireup="true" CodeFile="PollVote.aspx.cs" Inherits="pollvote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:700px" border="0"> 
        <tr>
            <td></td> 
            <td colspan="2" style="text-align:left; vertical-align:top"> 
                <asp:Image ID="Image7" runat="server" Height="20px" ImageUrl="~/images/bbsOnlinePoll.jpg" /> &nbsp;&nbsp; 
                <strong><span style="font-size:large; font-family:'Arial Black'";>On-Line Poll</span></strong> 
            </td> 
            <td></td>
        </tr>
        <tr>
            <td style="width: 100px"></td>
            <td style="width: 40px; text-align: center; vertical-align: top">
                <asp:Image ID="Image5" runat="server" Height="50px" ImageUrl="~/images/bbsQuestion.jpg" Width="40px" />
            </td>
            <td style="width: 460px; text-align: left; vertical-align: top">
                <asp:Label ID="lblQuestion" runat="server" Width="450px"></asp:Label>
                <br />
                <asp:Label ID="lblTotalVotes" runat="server" Font-Italic="True" Font-Names="맑은 고딕" Font-Size="Small" Text="현재 투표자수" Style="color: #3366FF" ForeColor="Aqua"></asp:Label>  &nbsp;&nbsp;
                <asp:Label ID="lblMessage" runat="server" Font-Italic="True" Font-Names="맑은 고딕" Font-Size="Small" ForeColor="#CC0000"></asp:Label>
            </td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align: center; vertical-align: top">
                <asp:Image ID="Image6" runat="server" ImageUrl="~/images/bbsAnswer.jpg" Width="40px" />
            </td>
            <td style="text-align:left; vertical-align:top">
                <asp:RadioButtonList ID="rdoOptions" runat="server" Visible="False">
                </asp:RadioButtonList>
                <asp:CheckBoxList ID="chkOptions" runat="server" Visible="False">
                </asp:CheckBoxList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2" style="text-align: center; vertical-align: top">
                <asp:ImageButton ID="ibtnVote" runat="server" ImageUrl="~/images/bbsVote.jpg" OnClick="ibtnVote_Click" Visible="False" />
                <asp:ImageButton ID="ibtnResult" runat="server" ImageUrl="~/images/bbsResult.jpg" OnClick="ibtnResult_Click" Visible="False" />
                <asp:ImageButton ID="ibtnList" runat="server" ImageUrl="~/images/bbsList.jpg"  OnClick="ibtnList_Click" />
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>

