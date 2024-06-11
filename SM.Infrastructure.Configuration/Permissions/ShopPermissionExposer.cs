﻿using Base_Framework.Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Product", new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.ListProducts, "ListProducts"),
                        new PermissionDto(ShopPermissions.SearchProducts, "SearchProducts"),
                        new PermissionDto(ShopPermissions.CreateProduct, "CreateProduct"),
                        new PermissionDto(ShopPermissions.EditProduct, "EditProduct"),
                    }
                },
                {
                    "ProductCategory", new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermissions.SearchProductCategories, "SearchProductCategories"),
                        new PermissionDto(ShopPermissions.ListProductCategories, "ListProductCategories"),
                        new PermissionDto(ShopPermissions.CreateProductCategory, "CreateProductCategory"),
                        new PermissionDto(ShopPermissions.EditProductCategory, "EditProductCategory"),
                    }
                }
            };
        }
    }
}
