﻿using System;
using System.Web.UI;

public partial class Site : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public void ChangeMainImage(string paramImageUrl)
    {
        bannerImage.Src = paramImageUrl;
    }
}