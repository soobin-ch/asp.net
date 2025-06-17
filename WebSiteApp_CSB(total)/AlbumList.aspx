<%@ Page Title="" Language="C#" MasterPageFile="~/sGallery.master" AutoEventWireup="true" CodeFile="AlbumList.aspx.cs" Inherits="albumlist" %>

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
                <asp:GridView ID="grvAlbum" runat="server" AllowPaging="True" GridLines="None" PageSize="5" style="font-family: '맑은 고딕'"  onpageindexchanging="grvAlbum_PageIndexChanging" Width="700px" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:TemplateField HeaderText="포토" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <asp:HyperLink ID="hyperlink1" runat="server" NavigateUrl='<%#GetShowUrl(Eval("no")) %>' Target="_blank" ImageUrl='<%#GetImageUrl(Eval("no"),Eval("fname")) %>' ImageWidth="150px" >
                                   <%-- <asp:Image ID="Image1" runat="server" ImageUrl='<%#GetImageUrl(Eval("no")) %>' Width="150px" AlternateText="사진" /> --%>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="제목+내용" ItemStyle-Width="550px" ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <table style="width:550px" border="0">
                                    <tr>
                                        <td style="width:550px; text-align:left; vertical-align:middle;">
                                            <span style="font-size:medium">
                                                <b> <%#Eval("title") %></b>&nbsp;(파일명 : <%#Eval("fname")%>)
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:left; vertical-align:middle;">
                                            <span style="font-size: small"> 
                                                <asp:Label ID="Label1" Width="540px" runat="server" Text='<%#Eval("comment") %>'>
                                                </asp:Label>
                                            </span>  
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:left; vertical-align:middle">
                                            <span style="font-size: small"> 
                                                <b>
                                                    작성자 : <%#Eval("nickname")%>(<%#Eval("author") %>)&nbsp;&nbsp;&nbsp;
                                                    작성일 : <%#Eval("uploadtime","{0:yyyy/MM/dd}") %>&nbsp;&nbsp;&nbsp;
                                                    조회수 : <%#Eval("hits") %>
                                                </b>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

