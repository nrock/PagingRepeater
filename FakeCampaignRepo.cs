using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities; 

namespace WebApplication37
{
    public class FakeCampaignRepo
    {
        private List<Campaign> Campaigns
        {
            get
            {
                if (HttpContext.Current.Session["_campaigns"] != null)
                {
                    return (List<Campaign>)HttpContext.Current.Session["_campaigns"];
                } 
                var _campaigns = new List<Campaign>();
                var date = DateTime.Parse("6/11/2015 11:33:23");
                var i = 1;
                _campaigns.Add(new Campaign { Name = "aaaa", Email = "aaaa@epsilon.com", TemplateName = "Template a", Category = "Summer",      Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "bbbb", Email = "bbbb@epsilon.com", TemplateName = "Template b", Category = "Winter",      Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "cccc", Email = "cccc@epsilon.com", TemplateName = "Template c", Category = "Summer",      Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "dddd", Email = "dddd@epsilon.com", TemplateName = "Template d", Category = "Winter",      Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "eeee", Email = "eeee@epsilon.com", TemplateName = "Template e", Category = "Holiday",     Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "ffff", Email = "ffff@epsilon.com", TemplateName = "Template f", Category = "Summer",      Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "gggg", Email = "gggg@epsilon.com", TemplateName = "Template g", Category = "Memorial",    Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "hhhh", Email = "hhhh@epsilon.com", TemplateName = "Template h", Category = "Summer",      Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "iiii", Email = "iiii@epsilon.com", TemplateName = "Template i", Category = "Summer",      Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "jjjj", Email = "jjjj@epsilon.com", TemplateName = "Template j", Category = "Memorial",    Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "kkkk", Email = "kkkk@epsilon.com", TemplateName = "Template k", Category = "Winter",      Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "llll", Email = "llll@epsilon.com", TemplateName = "Template l", Category = "Memorial",    Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "mmmm", Email = "mmmm@epsilon.com", TemplateName = "Template m", Category = "Memorial",    Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "nnnn", Email = "nnnn@epsilon.com", TemplateName = "Template n", Category = "Winter",      Date = date.AddDays(-(--i)) });  
                /*_campaigns.Add(new Campaign { Name = "oooo", Email = "oooo@epsilon.com", TemplateName = "Template o", Category = "Summer", Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "pppp", Email = "pppp@epsilon.com", TemplateName = "Template p", Category = "Memorial", Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "qqqq", Email = "qqqq@epsilon.com", TemplateName = "Template q", Category = "Winter", Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "rrrr", Email = "rrrr@epsilon.com", TemplateName = "Template r", Category = "Memorial", Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "ssss", Email = "ssss@epsilon.com", TemplateName = "Template s", Category = "Memorial", Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "tttt", Email = "tttt@epsilon.com", TemplateName = "Template t", Category = "Winter", Date = date.AddDays(-(--i)) });
                _campaigns.Add(new Campaign { Name = "uuuu", Email = "uuuu@epsilon.com", TemplateName = "Template u", Category = "Winter", Date = date.AddDays(-(--i)) });
       */         HttpContext.Current.Session["_campaigns"] = _campaigns;
                return _campaigns; 
            }
            set { HttpContext.Current.Session["_campaigns"] = value; }
        }

        public FakeCampaignRepo()
        {
            

        }

        public int Total { get { return Campaigns.Count; } }

        public IList<Campaign> Get(int pageSize, int pageNumber)
        {
            return Campaigns.Skip(pageSize * pageNumber).Take(pageSize).ToList();
        }
        public void Delete(string name)
        {
            Campaigns.Remove(Campaigns.First(x => x.Name == name));
        }
        public void Add(Campaign campaign)
        {
            Campaigns.Add(campaign); 
        }
    }
}