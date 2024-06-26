﻿using SM.Domain.Core.ProductCategoryAgg.Data;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Domain.Core.ProductCategoryAgg.Entities;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using System.Linq.Expressions;
using Base_Framework.Domain.Core.Entities;
using Base_Framework.Infrastructure.DataAccess;

namespace SM.Infrastructure.DataAccess.Repos.EFCore.ProductCategoryAgg
{
    public class ProductCategoryRepository : BaseRepository_EFCore<ProductCategory> ,IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public void Create(CreateProductCategoryDTO productCategory)
        {
            var newProductCategory = new ProductCategory(productCategory.Name, productCategory.Description, productCategory.MetaDescription, productCategory.Slug, productCategory.KeyWords, productCategory.PictureId);
            _context.ProductCategories.Add(newProductCategory);
        }

        public void Edit(EditProductCategoryDTO edit)
        {
            var productCategory = Get(edit.Id);
            productCategory.Edit(edit.Name, edit.Description, edit.MetaDescription, edit.Slug, edit.KeyWords);
        }

        public List<ProductCategoryDTO> GetAll()
        {
            return _context.ProductCategories.Select(pc =>
             new ProductCategoryDTO
             {
                 Id = pc.Id,
                 Name = pc.Name,
                 CreationDate = pc.CreationDate,
                 PictureId = pc.PictureId
             }).ToList();
        }

        public ProductCategoryDTO GetBy(long id)
        {
            return _context.ProductCategories.Where(pc => pc.Id == id).Select(pc =>
            new ProductCategoryDTO
            {
                Id = pc.Id,
                Name = pc.Name,
                CreationDate = pc.CreationDate,
                PictureId = pc.PictureId
            }).Single();
}
        public ProductCategoryDetailDTO GetDetail(long id)
        {
            return _context.ProductCategories.Where(pc => pc.Id == id).Select(pc =>
            new ProductCategoryDetailDTO
            {
                Id = pc.Id,
                Name = pc.Name,
                Description = pc.Description,
                IsDeleted = pc.IsRemoved,
                KeyWords = pc.KeyWords,
                MetaDescription = pc.MetaDescription,
                Slug = pc.Slug,
                 PictureId = pc.PictureId
            }).Single();
        }

        public List<ProductCategoryDTO> Search(SearchProductCategoryDTO searchModel)
        {
            var query = _context.ProductCategories.Select(pc =>
             new ProductCategoryDTO
             {
                 Id = pc.Id,
                 Name = pc.Name,
                 CreationDate = pc.CreationDate,
                 PictureId = pc.PictureId
             });

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(pc => pc.Name == searchModel.Name);

            return query.OrderByDescending(pc => pc.Id).ToList();
        }

    }
}
