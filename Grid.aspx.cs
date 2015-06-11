using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace WebApplication37
{
    public partial class Grid : System.Web.UI.Page
    {
        private FakeCampaignRepo _campaignRepo;
        private int _pageSize;
        private int _pageNumber;

        public Grid()
        {
            _campaignRepo = new FakeCampaignRepo();
            _pageSize = 5;
            _pageNumber = 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid( )
        {
            this.rGrid.DataSource = _campaignRepo.Get(_pageSize, _pageNumber);
            this.rGrid.DataBind();
            var pages = new List<Pager>();
            var totalRecords = _campaignRepo.Total;
            var totalPages = (int)Math.Ceiling ( (float)totalRecords / (float)_pageSize );

            //pages.Add(new Pager { Text = "first", PageValue = 0, Style = (0 == _pageNumber) ? "active" : "inactive" });
            //pages.Add(new Pager { Text = "prev", PageValue = _pageNumber - 1, Style = (0 == _pageNumber) ? "active" : "inactive" });
            for (int i = 0; i < totalPages; i ++)
            { 
                pages.Add(new Pager { Text = i.ToString(), PageValue = i, Style = (i == _pageNumber) ? "active" : "inactive" });
            }
            //pages.Add(new Pager { Text = "next", PageValue = _pageNumber+1, Style = (totalPages - 1 == _pageNumber) ? "active" : "inactive" });
            //pages.Add(new Pager { Text = "last", PageValue = totalPages - 1, Style = (totalPages - 1 == _pageNumber) ? "active" : "inactive" }); 
            this.rPager.DataSource = pages;
            this.rPager.DataBind();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            _pageNumber = pageIndex;
            this.LoadGrid();
        }


    }

    public class Pager
    {
        public string Text { get; set; }
        public string Style { get; set; }
        public int PageValue { get; set; }
    }
}