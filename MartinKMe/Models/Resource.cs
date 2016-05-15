﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MartinKMe.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string ShortUrl { get; set; }

        public string TargetUrl { get; set; }

        public bool VisibleOnSite { get; set; }

        public int ResourceGroupId { get; set; }
    }
}
