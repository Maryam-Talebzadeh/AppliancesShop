using Base_Framework.Domain.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.SliderAgg.DTOs
{
    public class SlidePictureDTO
    {
        public string Name { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
    }
}
