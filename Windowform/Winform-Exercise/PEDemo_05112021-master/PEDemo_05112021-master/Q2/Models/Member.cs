using System;
using System.Collections.Generic;

#nullable disable

namespace Q2.Models
{
    public partial class Member
    {
        public int MemberNo { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middleinitial { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string Country { get; set; }
        public string MailCode { get; set; }
        public string PhoneNo { get; set; }
        public byte[] Photograph { get; set; }
        public DateTime IssueDt { get; set; }
        public DateTime ExprDt { get; set; }
        public int RegionNo { get; set; }
        public int? CorpNo { get; set; }
        public decimal? PrevBalance { get; set; }
        public decimal? CurrBalance { get; set; }
        public string MemberCode { get; set; }

        public virtual Corporation CorpNoNavigation { get; set; }
        public virtual Region RegionNoNavigation { get; set; }
    }
}
