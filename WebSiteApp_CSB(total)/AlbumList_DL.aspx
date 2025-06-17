<%@ Page Title="" Language="C#" MasterPageFile="~/sGallery.master" AutoEventWireup="true" CodeFile="AlbumList_DL.aspx.cs" Inherits="albumlist_dl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:700px">
        <tr>
            <td style="width:600px; text-align:left; vertical-align:middle;">
                <asp:Label ID="lblAlbumTitle" runat="server" BackColor="#CCCCFF" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="Large" Text="앨범보기" Width="600px">
                </asp:Label>
            </td>
            <td style="width:100px; text-align:center; vertical-align:middle">
                <asp:Button ID="btnSave" runat="server" Font-Size="Large" style="font-size: small; font-weight: 700; font-family: '맑은 고딕'" Text="사진올리기" onclick="btnSave_Click" UseSubmitBehavior="False" Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:left; vertical-align:middle;">
                <b><span style="font-size: small">원본을 보시려면 이미지를 클릭하세요...</span></b>
                <asp:Label ID="lblMessage" runat="server" Font-Names="맑은 고딕" Font-Size="Small"  ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:left; vertical-align:top;">
                <asp:DataList ID="dlAlbum" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" Width="730px">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#GetShowUrl(Eval("no"))%>' Target="_blank" Width="150px" Height="150px"> 
                        <%--ImageUrl='<%#GetImageUrl(Eval("no"),Eval("fname")) %>' --%> 

                            <%-- asp:HyperLink 태그의 ImageUrl 속성(attribute)을 이용하는 경우 사진의 크기를 원하는 대로 조절할 수 없어 asp:hyperLink의 body에 asp:Image 태그로 추가함  --%>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#GetImageUrl(Eval("no"),Eval("fname")) %>' Width="150px" Height="150px">
                            </asp:Image>

                        </asp:HyperLink>
                        <br />                     
                        <asp:Image ID="Image2" runat="server" ImageUrl="images\bbsNote.jpg" Width="10px" />
                        <%#Eval("title") %>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>

