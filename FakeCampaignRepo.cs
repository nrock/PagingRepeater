using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Providers.Entities;

namespace WebApplication37
{
    public class FakeCampaignRepo
    {
        private readonly string _campaignSessionKey = "FakeCampaignRepo-campaigns";

        private List<Campaign> _campaigns
        {
            get
            { 
                var campaigns = new List<Campaign>();
                if (HttpContext.Current.Session[_campaignSessionKey] == null)
                { 
                    var date = DateTime.Parse("6/11/2015 11:33:23");
                    var i = 1;
                    campaigns.Add(new Campaign { Id=1,  Name= "aaaa", Email= "aaaa@abc.com", TemplateName= "Template a", Category= "Summer",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=2,  Name= "bbbb", Email= "bbbb@abc.com", TemplateName= "Template b", Category= "Winter",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=3,  Name= "cccc", Email= "cccc@abc.com", TemplateName= "Template c", Category= "Summer",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=4,  Name= "dddd", Email= "dddd@abc.com", TemplateName= "Template d", Category= "Winter",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=5,  Name= "eeee", Email= "eeee@abc.com", TemplateName= "Template e", Category= "Holiday",  Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=6,  Name= "ffff", Email= "ffff@abc.com", TemplateName= "Template f", Category= "Summer",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=7,  Name= "gggg", Email= "gggg@abc.com", TemplateName= "Template g", Category= "Memorial", Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=8,  Name= "hhhh", Email= "hhhh@abc.com", TemplateName= "Template h", Category= "Summer",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=9,  Name= "iiii", Email= "iiii@abc.com", TemplateName= "Template i", Category= "Summer",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=10, Name= "jjjj", Email= "jjjj@abc.com", TemplateName= "Template j", Category= "Memorial", Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=11, Name= "kkkk", Email= "kkkk@abc.com", TemplateName= "Template k", Category= "Winter",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=12, Name= "llll", Email= "llll@abc.com", TemplateName= "Template l", Category= "Memorial", Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=13, Name= "mmmm", Email= "mmmm@abc.com", TemplateName= "Template m", Category= "Memorial", Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=14, Name= "nnnn", Email= "nnnn@abc.com", TemplateName= "Template n", Category= "Winter",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=15, Name= "oooo", Email= "oooo@abc.com", TemplateName= "Template o", Category= "Summer",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=16, Name= "pppp", Email= "pppp@abc.com", TemplateName= "Template p", Category= "Memorial", Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=17, Name= "qqqq", Email= "qqqq@abc.com", TemplateName= "Template q", Category= "Winter",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=18, Name= "rrrr", Email= "rrrr@abc.com", TemplateName= "Template r", Category= "Memorial", Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=19, Name= "ssss", Email= "ssss@abc.com", TemplateName= "Template s", Category= "Memorial", Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=20, Name= "tttt", Email= "tttt@abc.com", TemplateName= "Template t", Category= "Winter",   Date=date.AddDays(-(--i)) });
                    campaigns.Add(new Campaign { Id=21, Name= "uuuu", Email= "uuuu@abc.com", TemplateName= "Template u", Category= "Winter",   Date=date.AddDays(-(--i)) });
                    HttpContext.Current.Session[_campaignSessionKey] = campaigns; 
                }
                else
                {
                    campaigns = (List<Campaign>) HttpContext.Current.Session[_campaignSessionKey];
                }
                return campaigns;
            }
            set { HttpContext.Current.Session[_campaignSessionKey] = value; }
        } 

        public FakeCampaignRepo()
        {

        }

        public int Total { get { return _campaigns.Count; }}

        public IList<Campaign> Get(int pageSize, int pageNumber)
        {
            return _campaigns.Skip(pageSize*pageNumber).Take(pageSize).ToList();
        }

        internal void Delete(int id)
        {
            var c = _campaigns.First(x => x.Id == id);
            _campaigns.Remove(c);
        }
        
        public void Add(Campaign campaign)
        {
            _campaigns.Add(campaign); 
        }
    }
}