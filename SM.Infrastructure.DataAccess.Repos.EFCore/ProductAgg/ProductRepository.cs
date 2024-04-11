using Base_Framework.Infrastructure.DataAccess;
using SM.Domain.Core.ProductAgg.Data;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using SM.Domain.Core.ProductAgg.Entities;
using SM.Domain.Core.ProductAgg.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore;
using SM.Domain.Core.ProductCategoryAgg.DTOs;

namespace SM.Infrastructure.DataAccess.Repos.EFCore.ProductAgg
{
    public class ProductRepository : BaseRepository_EFCore<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public void Create(CreateProductDTO product)
        {
            var dbProduct = new Product(product.Name, product.Code,
            product.ShortDescription, product.Description,"",
            product.PictureAlt, product.PictureTitle, product.CategoryId, product.Slug,
            product.Keywords, product.MetaDescription);

            _context.Products.Add(dbProduct);
        }

        public void Edit(EditProductDTO edit)
        {
            var product = Get(edit.Id);

            product.Edit(product.Name, product.Code,
                product.ShortDescription, product.Description, "",
                product.PictureAlt, product.PictureTitle, product.CategoryId, edit.Slug,
                product.Keywords, product.MetaDescription);
        }

        public List<ProductDTO> GetAll()
        {
            return _context.Products.Select(p =>
            new ProductDTO()
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }

        public ProductDTO GetBy(long id)
        {
            return _context.Products.Select(p =>
             new ProductDTO()
             {
                 Id = p.Id,
                 Name = p.Name
             }).SingleOrDefault(p => p.Id == id);
        }

        public ProductDetailDTO GetDetail(long id)
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
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
            }).FirstOrDefault(x => x.Id == id);
        }

        public void IsInStock(long id)
        {
            var product = Get(id);
            product.IsInStock();
        }

        public void NotInStock(long id)
        {
            var product = Get(id);
            product.NotInStock();
        }

        public List<ProductDTO> Search(SearchProductDTO searchModel)
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
                   Picture = x.Picture,
                   IsInStock = x.Inventory
               });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

        private Product Get(long id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }
    }
}
