﻿using DomainFramework.Core.Entities;

namespace SM.Domain.Core.ProductCategoryAgg.Entities
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategory(string name, string description, string metaDescription, string slug, string keyWords)
        {
            Name = name;
            Description = description;
            CreationDate = DateTime.Now;
            MetaDescription = metaDescription;
            Slug = slug;
            KeyWords = keyWords;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int PictureId { get; private set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }

        public void Edit(string name, string description, string metaDescription, string slug, string keyWords)
        {
            Name = name;
            Description = description;
            MetaDescription = metaDescription;
            Slug = slug;
            KeyWords = keyWords;
        }
    }
}

