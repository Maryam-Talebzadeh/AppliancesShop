using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.SliderAgg.DTOs
{
    public class SlideDTO
    {
        public long Id { get; set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public long PictureId { get; private set; }
    }
}
