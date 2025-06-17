<%@ Page Title="" Language="C#" MasterPageFile="~/sProfile.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div style="text-align: left;">
        여러분, 반갑습니다.  
        이 사이트는 C#, ASP.NET, MS-SQL을 공부하는 사람들이 정보를 공유하기 위한 목적으로 개설되었습니다.  
        많이 참여해 주시길 부탁드립니다.<br /><br />

        <strong>운영자</strong><br />
        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/bullet.JPG" Width="16px" Height="16px" />  
        성명 : 홍길동<br />

        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/bullet.JPG" Width="16px" Height="16px" />  
        소속 : 두원공과대학교 컴퓨터공학과<br />

        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/bullet.JPG" Width="16px" Height="16px" />  
        직위 : 학생<br /><br />

        <asp:Image ID="Image6" runat="server" ImageUrl="~/images/bullet.JPG" Width="16px" Height="16px" />  
        주관사항 :  
        C# 및 ASP.NET을 이용한 윈도우/웹/모바일 프로그래밍  
        현재 웹 프로그래밍을 배우고 있으며,  
        조만간 앱을 작성해 볼까 합니다.<br /><br />

        <asp:Image ID="Image7" runat="server" ImageUrl="~/images/bullet.JPG" Width="16px" Height="16px" />  
        연락처 : <strong>broadway4u@gmail.com</strong>
    </div>
</asp:Content>

