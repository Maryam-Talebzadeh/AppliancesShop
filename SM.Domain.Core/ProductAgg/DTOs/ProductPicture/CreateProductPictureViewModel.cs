using Base_Framework.Domain.Core;
using Base_Framework.Domain.Core.Attributes;
using Microsoft.AspNetCore.Http;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SM.Domain.Core.ProductAgg.DTOs.ProductPicture
{
    public class CreateProductPictureViewModel
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxFileSize(3*24, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtentionLimitation(new string[] {".jpeg", ".jpg",".png"}, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
