﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.SliderAgg.DTOs
{
    public class EditSlideViewModel : CreateSlideViewModel
    {
        public long Id { get; set; }
        public long PictureId { get; set; }
    }
}
