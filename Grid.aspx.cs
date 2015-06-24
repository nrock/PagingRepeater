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
            _pageSize = 6;
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
            _pageNumber = Int32.Parse(this.CurrentPage.Value == "" ?  "0" : this.CurrentPage.Value);
            this.rGrid.DataSource = _campaignRepo.Get(_pageSize, _pageNumber);
            this.rGrid.DataBind();
            var pages = new List<Pager>();
            var totalRecords = _campaignRepo.Total;
            var totalPages = (int)Math.Ceiling ( (float)totalRecords / (float)_pageSize );

            //pages.Add(new Pager { Text = "first", PageValue = 0, Style = (0 == _pageNumber) ? "active" : "inactive" });
            if (totalPages > 2)
            {
                pages.Add(new Pager{
                    Text = "<span aria-hidden='true'>&laquo;</span>",
                    PageValue = _pageNumber - 1,
                    Style = (0 == _pageNumber) ? "active" : "inactive"
                });
            }
            for (int i = 0; i < totalPages; i ++)
            { 
                pages.Add(new Pager { Text = i.ToString(), PageValue = i, Style = (i == _pageNumber) ? "active" : "inactive" });
            }
            if (totalPages > 2)
            {
                pages.Add(new Pager
                {
                    Text = "<span aria-hidden='true'>&raquo;</span>",
                    PageValue = _pageNumber + 1,
                    Style = (totalPages - 1 == _pageNumber) ? "active" : "inactive"
                });
            }
            //pages.Add(new Pager { Text = "last", PageValue = totalPages - 1, Style = (totalPages - 1 == _pageNumber) ? "active" : "inactive" }); 
            this.CurrentPage.Value = _pageNumber.ToString();
            this.rPager.DataSource = pages;
            this.rPager.DataBind();
        }


        protected void Add_Record(object sender, EventArgs e)
        {
            _campaignRepo.Add(new Campaign { Category = "NewCategory", Date = DateTime.Now, Email = "new@newmail.com", Name = "campaign new", TemplateName = "tempnew" });
            LoadGrid();
        }

        protected void Delete_Record(object sender, EventArgs e)
        {
            
        }

        protected void rGrid_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        { 
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {  
                var ucCampaign = (ucCampaign)e.Item.FindControl("ucCampaign");
                ucCampaign.Campaign = e.Item.DataItem as Campaign;
               
                ucCampaign.RecordDeleted += Delete_Record; 
            }
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.CurrentPage.Value = pageIndex.ToString();
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