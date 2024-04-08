using Base_Framework.Infrastructure.DataAccess;
using SM.Domain.Core.ProductCategoryAgg.Data;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Domain.Core.ProductCategoryAgg.Entities;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace SM.Infrastructure.DataAccess.Repos.EFCore.ProductCategoryAgg
{
    public class PictureRepository : BaseRepository_EFCore<long, Picture>, IPictureRepository
    {
        private readonly ShopContext _context;

        public PictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public long Create(CreatePictureDTO create)
        {
            var picture = new Picture(create.Name, create.Title, create.Alt);
            _context.Pictures.Add(picture);
            Save();
            return picture.Id;
        }

        public void Edit(PictureDTO picture)
        {
            var dbPicture = Get(picture.Id);
            dbPicture.Edit(picture.Name, picture.Title, picture.Alt);
        }

        public List<PictureDTO> GetAll()
        {
            return _context.Pictures.Select(p =>
            new PictureDTO()
            {
                Id = p.Id,
                Alt = p.Alt,
                Name = p.Name,
                Title = p.Title
            }).ToList();
        }

        public PictureDTO GetBy(long id)
        {
            return _context.Pictures.Select(p =>
            new PictureDTO()
            {
                Id = p.Id,
                Alt = p.Alt,
                Name = p.Name,
                Title = p.Title
            }).SingleOrDefault(p => p.Id == id);
        }

        private Picture Get(long id)
        {
            return _context.Pictures.SingleOrDefault(p => p.Id == id);
        }
    }
}
