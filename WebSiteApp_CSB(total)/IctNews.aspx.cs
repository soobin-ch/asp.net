using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ictnews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //검색API 결과를 그리드뷰의 DataSource로 데이터바인딩
        GridView1.DataSource = NaverApi.Search("ICT");
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
}