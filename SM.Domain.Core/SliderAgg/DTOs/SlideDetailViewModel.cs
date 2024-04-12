using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.SliderAgg.DTOs
{
    public class SlideDetailViewModel 
    {
        public long Id { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string BtnText { get; set; }
        public string Link { get; set; }
        public bool IsRemoved { get; set; }
        public string Picture { get; set; }
    }
}
