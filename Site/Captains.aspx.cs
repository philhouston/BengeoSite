using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Captains : Page
{
    private readonly SocietyModel model = new SocietyModel();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindResults();
        }
    }

    private void BindResults()
    {
        grid.PageIndex = 0;
        grid.DataBind();
    }

    protected void CaptainsSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = model.GetCaptains();
    }
}