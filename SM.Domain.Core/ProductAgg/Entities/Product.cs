﻿using Base_Framework.Domain.Core.Entities;
using SM.Domain.Core.ProductCategoryAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductAgg.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public DateTime CreationDate { get; set; }
        public string MetaDescription { get; private set; }
        public bool Inventory { get; set; }
        public ProductCategory Category { get; private set; }
        public List<ProductPicture> Pictures { get; private set; }


        public Product(string name, string code, string shortDescription, string description, long categoryId, string slug,
            string keywords, string metaDescription)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CreationDate = DateTime.Now;
            Inventory = true;
        }

        public void Edit(string name, string code, string shortDescription, string description, long categoryId, string slug,
            string keywords, string metaDescription)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }

        public void NotInStock()
        {
            Inventory = false;
        }

        public void IsInStock()
        {
            Inventory = true;
        }
    }
}
