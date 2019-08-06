using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class AgmInfo : Page
{
    private XDocument doc;

    protected void Page_Init(object sender, EventArgs e)
    {
        doc = SiteCache.AGMData;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAgm();
        }
    }

    private void BindAgm()
    {
        //grid.Selection.UnselectAll();
        grid.PageIndex = 0;
        grid.DataBind();
    }


    protected void AgmData_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        var minutes = from items in doc.Element("minutes").Elements("minute")
                      orderby DateTime.Parse(items.Attribute("date").Value) descending
                      select new
                          {
                              date = items.Attribute("date").Value,
                              file = items.Attribute("file").Value,
                              preview = items.Attribute("preview").Value
                          };

        e.Result = minutes;
    }
}