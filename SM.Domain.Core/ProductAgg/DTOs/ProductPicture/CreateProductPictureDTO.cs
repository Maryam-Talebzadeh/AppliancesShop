﻿using Base_Framework.Domain.Core;
using Microsoft.AspNetCore.Http;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductAgg.DTOs.ProductPicture
{
    public class CreateProductPictureDTO
    {
        public long ProductId { get; set; }

        public string Picture { get; set; }

        public string PictureAlt { get; set; }

        public string PictureTitle { get; set; }
    }
}
