using Base_Framework.Infrastructure.DataAccess;
using SM.Domain.Core.SliderAgg.Data;
using SM.Domain.Core.SliderAgg.DTOs;
using SM.Domain.Core.SliderAgg.Entities;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace SM.Infrastructure.DataAccess.Repos.EFCore.SliderAgg
{
    public class SlideRepository : BaseRepository_EFCore<Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public void Create(CreateSlideDTO slide)
        {
            var dbSlide = new Slide(slide.PictureId, slide.Heading, slide.Title, slide.Text, slide.Link, slide.BtnText);
            _context.Slides.Add(dbSlide);
        }

        public void Edit(EditSlideDTO edit)
        {
            var slide = Get(edit.Id);
            slide.Edit(edit.PictureId, edit.Heading, edit.Title, edit.Text, edit.Link, edit.BtnText);
        }

        public List<SlideDTO> GetAll()
        {
            return _context.Slides.Select(s =>
            new SlideDTO
            {
                Id = s.Id,
                Heading = s.Heading,
                PictureId = s.PictureId,
                Title = s.Title,
                IsRemoved = s.IsRemoved
            }).ToList();
        }

        public SlideDTO GetBy(long id)
        {
            return _context.Slides.Select(s =>
           new SlideDTO
           {
               Id = s.Id,
               Heading = s.Heading,
               PictureId = s.PictureId,
               Title = s.Title
           }).SingleOrDefault(s => s.Id == id);
        }

        public SlideDetailDTO GetDetail(long id)
        {
            return _context.Slides.Select(s =>
            new SlideDetailDTO
            {
                Id = s.Id,
                Heading = s.Heading,
                PictureId = s.PictureId,
                Title = s.Title,
                BtnText = s.BtnText,
                Link = s.Link,
                Text = s.Text
            }).SingleOrDefault(s => s.Id == id);
        }

        public void Remove(long id)
        {
            var slide = Get(id);
            slide.Remove();
        }

        public void Restore(long id)
        {
            var slide = Get(id);
            slide.ReStore();
        }
    }
}
