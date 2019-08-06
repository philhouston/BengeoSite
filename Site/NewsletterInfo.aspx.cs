using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class NewsletterInfo : Page
{
    private XDocument doc;
    private string reference;

    protected void Page_Init(object sender, EventArgs e)
    {
        doc = SiteCache.NewslettersData;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ref"] != null)
            {
                // We have a reference from the query string, lets use that
                reference = Request.QueryString["ref"];
                selection.Visible = false;
                BindNewsletters();
            }
            else
            {
                BindSeasons();
                BindNewsletters();
            }
        }
    }

    private void BindSeasons()
    {
        IEnumerable<string> seasons = (from e in doc.Elements("newsletters").Elements("newsletter")
                                       orderby e.Attribute("season").Value descending
                                       select e.Attribute("season").Value).Distinct();

        cbSeason.DataSource = seasons;
        cbSeason.DataBind();
    }


    private void BindNewsletters()
    {
        //grid.Selection.UnselectAll();
        grid.PageIndex = 0;
        grid.DataBind();
    }


    protected void cbSeason_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindNewsletters();
    }

    protected void NewslettersData_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (reference == null)
            reference = cbSeason.SelectedItem.Value;

        var newsletters = from items in doc.Element("newsletters").Elements("newsletter")
                          where items.Attribute("season").Value == reference
                          orderby DateTime.Parse(items.Attribute("date").Value) descending
                          select new
                              {
                                  date = items.Attribute("date").Value,
                                  file = items.Attribute("file").Value,
                                  preview = items.Attribute("preview").Value
                              };

        e.Result = newsletters;
    }
}