using Base_Framework.Infrastructure.DataAccess;
using SM.Domain.Core.ProductAgg.Data;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;
using SM.Domain.Core.ProductAgg.Entities;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;
namespace SM.Infrastructure.DataAccess.Repos.EFCore.ProductAgg
{
    public class ProductPictureRepository : BaseRepository_EFCore<ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task Create(CreateProductPictureDTO command, CancellationToken cancellationToken)
        {
            var picture = new ProductPicture(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
            _context.ProductPictures.Add(picture);
        }

        public async Task Edit(EditProductPictureDTO command, CancellationToken cancellationToken)
        {
            var productPicture = Get(command.Id);
            productPicture.Edit(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
        }

        public async Task<ProductPictureDTO> GetBy(long id, CancellationToken cancellationToken)
        {
            return _context.ProductPictures.Select(p =>
            new ProductPictureDTO()
            {
                Id = p.Id,
                IsRemoved = p.IsRemoved,
                Picture = p.Picture,
                ProductId = p.ProductId,
                CategorySlug = p.Product.Category.Slug
                
            }).SingleOrDefault(p => p.Id == id);
        }

        public async Task<DetailProductPictureDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return _context.ProductPictures.Select(p =>
            new DetailProductPictureDTO()
            {
                Id = p.Id,
                Picture = p.Picture,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle,
                ProductId = p.ProductId,
                CategorySlug = p.Product.Category.Slug
            }).SingleOrDefault(p => p.Id == id);
        }


        public async Task Remove(long id, CancellationToken cancellationToken)
        {
            var productPicture = Get(id);
            productPicture.Remove();
        }

        public async Task Restore(long id, CancellationToken cancellationToken)
        {
            var productPicture = Get(id);
            productPicture.ReStore();
        }


        public async Task<List<ProductPictureDTO>> Search(SearchProductPictureDTO searchModel, CancellationToken cancellationToken)
        {
            var pictures = _context.ProductPictures.Select(p =>
            new ProductPictureDTO()
            {
                Id = p.Id,
                Picture = p.Picture,
                ProductId = p.ProductId,
                IsRemoved = p.IsRemoved,
                Product = p.Product.Name,
                CategorySlug = p.Product.Category.Slug
            });

            if(searchModel.ProductId != 0)
            {
                pictures = pictures.Where(p => p.ProductId == searchModel.ProductId);
            }

            return pictures.OrderByDescending(p => p.Id).ToList();
        }

    }
}
