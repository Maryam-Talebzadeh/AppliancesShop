using Base_Framework.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.SliderAgg.Entities
{
    public class SlidePicture : BaseEntity
    {
        public SlidePicture(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
        }

        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Alt { get; private set; }
        public Slide Slide { get; set; }

        public void Edit(string name, string title, string alt)
        {
            Name = name;
            Title = title;
            Alt = alt;
        }

    }
}
