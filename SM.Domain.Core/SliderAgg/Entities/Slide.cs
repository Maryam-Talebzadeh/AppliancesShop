using Base_Framework.Domain.Core.Entities;
using SM.Domain.Core.ProductCategoryAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.SliderAgg.Entities
{
    public class Slide : BaseEntity
    {
        public Slide(long pictureId, string heading,
    string title, string text, string link, string btnText)
        {
            PictureId = pictureId;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            Link = link;
            IsRemoved = false;
        }

        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string BtnText { get; private set; }
        public string Link { get; private set; }
        public bool IsRemoved { get; private set; }
        public long PictureId { get; private set; }
        public SlidePicture Picture { get; private set; }


        public void Edit(long pictureId, string heading,
            string title, string text, string link, string btnText)
        {
            PictureId = pictureId;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            Link = link;
        }

    }
}
