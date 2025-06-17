using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sStudy : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ibtnCs_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("UnderConstruction.aspx");
        //C# 공부방 페이지로 이동

    }

    protected void ibtnAsp_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("UnderConstruction.aspx");
        //ASP.NET 공부방 페이지로 이동

    }

    protected void ibtnSql_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("UnderConstruction.aspx");
        //MS.SQL 공부방 페이지로 이동

    }

    protected void ibtnNews_Click(object sender, ImageClickEventArgs e)
    {
        //공사중 페이지로 이동, 추후 수정
        Response.Redirect("ictnews.aspx");
        // ICT News 페이지로 이동

    }
}
