﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAST_Alumni_2020_Web_Portal.Models
{
    public class JobPostFinal
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string skils { get; set; }

        public string OrganizationName { get; set; }
        public int organizationId { get; set; }
        public string  Location { get; set; }

        public JobPostFinal(int id,string title, string description, string skils, string organizationName,int oid,string location)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.skils = skils;
            OrganizationName = organizationName;
            this.organizationId = oid;
            this.Location = location;
        }
    }
}