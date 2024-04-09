using Base_Framework.Domain.Core;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SM.Domain.Core.ProductCategoryAgg.DTOs
{
    public class CreateProductCategoryViewModel
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        public string Description { get; set; }
        public IFormFile? Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
    }
}
