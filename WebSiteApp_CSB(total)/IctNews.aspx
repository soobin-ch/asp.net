<%@ Page Title="" Language="C#" MasterPageFile="~/sStudy.master" AutoEventWireup="true" CodeFile="IctNews.aspx.cs" Inherits="ictnews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" BackColor="#CCCCFF" Font-Bold="True" Font-Names="맑은 고딕" Font-Size="Medium" Text="Naver API를 이용한 'ICT' 검색 " Width="730px"></asp:Label><BR />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="7" ShowHeader="False" Width="730px">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table style="width:728px;">
                        <tr>
                            <td style="width:728px; text-align:left;">
                                <asp:HyperLink runat="server" Text='<%#Eval("title") %>' NavigateUrl='<%#Eval("originalLink") %>'></asp:HyperLink>
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <%#Eval("pubDate") %>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <%#Eval("description") %>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>

