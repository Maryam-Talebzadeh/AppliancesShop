﻿using Base_Framework.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductCategoryAgg.Entities
{
    public class Picture: BaseEntity
    {
        public Picture(string name , string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
        }

        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Alt { get; private set; }
        public ProductCategory ProductCategory { get; private set; }

       public void Edit(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
        }
    }
}
