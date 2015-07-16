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
            _pageSize = 15;
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


        protected void OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void Add_Record(object sender, EventArgs e)
        {
            var c = new Campaign();
            c.Category = this.tbCategory.Text;
            c.Name = this.tbName.Text;
            c.Email = this.tbEmail.Text;
            c.TemplateName = this.tbTemplateName.Text;
            c.Date = DateTime.Now;

            var valid = (this.tbName.Text != "" && this.tbEmail.Text != "" && this.tbCategory.Text != "");
            if (valid)
            {
                _campaignRepo.Add(c);
                LoadGrid();
                lblError.Text = "";
                this.tbCategory.Text = "";
                this.tbName.Text = "";
                this.tbEmail.Text = "";
                this.tbTemplateName.Text = "";
                this.hEditMode.Text = "false";
            }
            else
            {
                lblError.Text = "invalid entry";
                this.hEditMode.Text = "true";
            }
        }

        protected void rGrid_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {

            var x = e.CommandName;
            int y = Int32.Parse(e.CommandArgument.ToString());
            _campaignRepo.Delete(y);
                
            this.LoadGrid();
        }

        protected void rGrid_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        { 
        }
    }
}