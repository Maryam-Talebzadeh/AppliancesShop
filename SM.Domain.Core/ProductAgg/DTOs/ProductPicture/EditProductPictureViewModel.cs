﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductAgg.DTOs.ProductPicture
{
    public class EditProductPictureViewModel : CreateProductPictureViewModel
    {
        public long Id { get; set; }
        public string CategorySlug { get; set; }
    }
}
