using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication37
{
    public partial class ucCampaign : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Campaign Campaign{get;set;}


        public event EventHandler RecordDeleted;

        protected void Delete_Record(object sender, EventArgs e)
        {
            if (RecordDeleted != null)
            {
                
                RecordDeleted(this, EventArgs.Empty);
            }
            //_campaignRepo.Delete(((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument);
            //LoadGrid(); 
        }

    }
}