﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain.Core.ColleagueDiscountAgg.DTOs
{
    public class ColleagueDiscountDTO
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public int DiscountRate { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
    }
}
