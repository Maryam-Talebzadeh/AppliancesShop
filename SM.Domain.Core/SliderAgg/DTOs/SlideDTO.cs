﻿using Base_Framework.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.SliderAgg.DTOs
{
    public class SlideDTO
    {
        public long Id { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
        public long PictureId { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
        public string Text { get; set; }
        public string BtnText { get; set; }
        public string Link { get; set; }
    }
}
