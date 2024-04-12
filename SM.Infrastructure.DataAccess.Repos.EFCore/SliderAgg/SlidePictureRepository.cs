using Base_Framework.Infrastructure.DataAccess;
using SM.Domain.Core.SliderAgg.Data;
using SM.Domain.Core.SliderAgg.DTOs;
using SM.Domain.Core.SliderAgg.Entities;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.DataAccess.Repos.EFCore.SliderAgg
{
    public class SlidePictureRepository : BaseRepository_EFCore<SlidePicture>, ISlidePictureRepository
    {
        private readonly ShopContext _context;

        public SlidePictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public long Create(CreateSlidePictureDTO create)
        {
            var slide = new SlidePicture(create.Name, create.Title, create.Alt);
            _context.Add(slide);
            Save();

            return slide.Id;
        }

        public void Edit(EditSlidePictureDTO slidePicture)
        {
            var slide = Get(slidePicture.Id);
            slide.Edit(slidePicture.Name, slidePicture.Title, slidePicture.Alt);
        }

        public List<SlidePictureDTO> GetAll()
        {
            return _context.SlidePictures.Select(sp =>
            new SlidePictureDTO
            {
                Alt = sp.Alt,
                Id = sp.Id,
                Name = sp.Name,
                Title = sp.Title
            }).ToList();
        }

        public SlidePictureDTO GetBy(long id)
        {
            return _context.SlidePictures.Select(sp =>
           new SlidePictureDTO
           {
               Alt = sp.Alt,
               Id = sp.Id,
               Name = sp.Name,
               Title = sp.Title
           }).SingleOrDefault(s => s.Id == id);
        }
    }
}
