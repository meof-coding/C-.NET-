using System;
using System.Collections.Generic;

#nullable disable

namespace Q2.Models
{
    public partial class Region
    {
        public Region()
        {
            Corporations = new HashSet<Corporation>();
            Members = new HashSet<Member>();
        }

        public int RegionNo { get; set; }
        public string RegionName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string Country { get; set; }
        public string MailCode { get; set; }
        public string PhoneNo { get; set; }
        public string RegionCode { get; set; }

        public virtual ICollection<Corporation> Corporations { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
