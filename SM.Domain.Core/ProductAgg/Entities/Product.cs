using Base_Framework.Domain.Core.Entities;
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
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public long CategoryId { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public DateTime CreationDate { get; set; }
        public string MetaDescription { get; private set; }
        public ProductCategory Category { get; private set; }

        public Product(string name, string code, string shortDescription, string description,
            string picture, string pictureAlt, string pictureTitle, long categoryId, string slug,
            string keywords, string metaDescription)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CreationDate = DateTime.Now;
        }

        public void Edit(string name, string code, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, long categoryId, string slug,
            string keywords, string metaDescription)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }
    }
}
