using Base_Framework.Infrastructure.DataAccess;
using SM.Domain.Core.ProductAgg.Data;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using SM.Domain.Core.ProductAgg.Entities;
using Microsoft.EntityFrameworkCore;
using SM.Domain.Core.ProductAgg.DTOs.Product;
using System.Threading;

namespace SM.Infrastructure.DataAccess.Repos.EFCore.ProductAgg
{
    public class ProductRepository : BaseRepository_EFCore<Product>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<long> Create(CreateProductDTO product, CancellationToken cancellationToken)
        {
            var dbProduct = new Product(product.Name, product.Code,
            product.ShortDescription, product.Description, product.CategoryId, product.Slug,
            product.Keywords, product.MetaDescription);

            _context.Products.Add(dbProduct);
            Save();
            return dbProduct.Id;
        }

        public async Task Edit(EditProductDTO edit, CancellationToken cancellationToken)
        {
            var product = Get(edit.Id);

            product.Edit(product.Name, product.Code,
                product.ShortDescription, product.Description, product.CategoryId, edit.Slug,
                product.Keywords, product.MetaDescription);
        }

        public async Task<List<ProductDTO>> GetAll(CancellationToken cancellationToken)
        {
            return _context.Products.Select(p =>
            new ProductDTO()
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }

        public async Task<ProductDTO> GetBy(long id, CancellationToken cancellationToken)
        {
            return _context.Products.Select(p =>
             new ProductDTO()
             {
                 Id = p.Id,
                 Name = p.Name
             }).SingleOrDefault(p => p.Id == id);
        }

        public async Task<string> GetCategorySlugByProductId(long id, CancellationToken cancellationToken)
        {
            return _context.Products.Include(p => p.Category).Where(p => p.Id == id).Select(p => p.Category.Slug).FirstOrDefault();
        }

        public async Task<ProductDetailDTO> GetDetail(long id, CancellationToken cancellationToken)
        {
            return _context.Products.Select(x => new ProductDetailDTO
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Slug = x.Slug,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                ShortDescription = x.ShortDescription,
                CategorySlug = x.Category.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public async Task IsInStock(long id, CancellationToken cancellationToken)
        {
            var product = Get(id);
            product.IsInStock();
        }

        public async Task NotInStock(long id, CancellationToken cancellationToken)
        {
            var product = Get(id);
            product.NotInStock();
        }

        public async Task<List<ProductDTO>> Search(SearchProductDTO searchModel, CancellationToken cancellationToken)
        
        {
            var query = _context.Products
               .Include(x => x.Category)
               .Select(x => new ProductDTO
               {
                   Id = x.Id,
                   Name = x.Name,
                   Category = x.Category.Name,
                   CategoryId = x.CategoryId,
                   Code = x.Code,
                   IsInStock = x.Inventory,
                   CategorySlug = x.Category.Slug,
                   Picture = x.Pictures.First().Picture,
                   
               });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

    }
}
