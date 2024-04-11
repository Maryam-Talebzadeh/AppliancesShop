using Base_Framework.Infrastructure.DataAccess;
using SM.Domain.Core.ProductAgg.Data;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;
using SM.Domain.Core.ProductAgg.Entities;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;
namespace SM.Infrastructure.DataAccess.Repos.EFCore.ProductAgg
{
    public class ProductPictureRepository : BaseRepository_EFCore<long, ProductPicture> ,IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public void Create(CreateProductPictureDTO command)
        {
            var picture = new ProductPicture(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
            _context.ProductPictures.Add(picture);
        }

        public void Edit(EditProductPictureDTO command)
        {
            var productPicture = Get(command.Id);
            productPicture.Edit(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
        }

        public DetailProductPictureDTO GetDetails(long id)
        {
            return _context.ProductPictures.Select(p =>
            new DetailProductPictureDTO()
            {
                Id = p.Id,
                Picture = p.Picture,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle,
                ProductId = p.ProductId
            }).SingleOrDefault(p => p.Id == id);
        }


        public void Remove(long id)
        {
            var productPicture = Get(id);
            productPicture.Remove();
        }

        public void Restore(long id)
        {
            var productPicture = Get(id);
            productPicture.ReStore();
        }


        public List<ProductPictureDTO> Search(SearchProductPictureDTO searchModel)
        {
            var pictures = _context.ProductPictures.Select(p =>
            new ProductPictureDTO()
            {
                Id = p.Id,
                Picture = p.Picture,
                ProductId = p.ProductId,
                IsRemoved = p.IsDeleted
            });

            if(searchModel.ProductId != 0)
            {
                pictures = pictures.Where(p => p.ProductId == searchModel.ProductId);
            }

            return pictures.OrderByDescending(p => p.Id).ToList();
        }

        private ProductPicture Get(long id)
        {
            return _context.ProductPictures.SingleOrDefault(p => p.Id == id);
        }
    }
}
