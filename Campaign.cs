using System;

namespace WebApplication37
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TemplateName { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }
}