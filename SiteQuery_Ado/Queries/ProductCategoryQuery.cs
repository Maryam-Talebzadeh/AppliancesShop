using Microsoft.Data.SqlClient;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;
using System.Data;
using Base_Framework.Domain.General;

namespace SiteQuery_Ado.Queries
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly string _connectionString;

        public ProductCategoryQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            List<ProductCategoryQueryModel> productCategories = new List<ProductCategoryQueryModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                //GetProductCategories StoredProcedure in db:
                //BEGIN
                //    SELECT Id, Name, Picture, PictureAlt, PictureTitle, Slug
                //    FROM ProductCategories
                //END

                using (SqlCommand command = new SqlCommand("GetProductCategories", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductCategoryQueryModel category = new ProductCategoryQueryModel
                            {
                                Id = reader.GetInt64(reader.GetOrdinal("Id")),
                                Name = reader["Name"].ToString(),
                                Picture = reader["Picture"].ToString(),
                                PictureAlt = reader["Alt"].ToString(),
                                PictureTitle = reader["Title"].ToString(),
                                Slug = reader["Slug"].ToString()
                            };

                            productCategories.Add(category);
                        }
                    }
                }
            }

            return productCategories;
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
            var productCategories = GetProductCategories();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                foreach (var category in productCategories)
                {
                    var categoryProducts = new List<ProductQueryModel>();
                    using (SqlCommand command = new SqlCommand("GetProductsByCategoryId", connection))
                    {
                        //GetProductsByCategoryId StoredProcedure in db:
                        //                        @CategoryId INT
                        //AS
                        //BEGIN
                        //SELECT pc.Id AS 'pc.Id', pc.Name AS 'p.CategoryName', p.Id AS 'p.Id',  p.Name AS 'p.Name', picture.Picture AS 'p.Picture', Picture.PictureAlt AS 'p.PictureAlt', Picture.PictureTitle AS 'p.PictureTitle', inventory.UnitPrice As 'p.Price', cd.DiscountRate As 'p.DiscountRate'
                        //FROM dbo.ProductCategories pc
                        //INNER JOIN dbo.Products p ON pc.Id = p.CategoryId
                        //INNER JOIN dbo.ProductPictures picture on picture.ProductId = p.Id
                        //Left JOIN dbo.Inventory inventory on inventory.ProductId = p.Id
                        //Left JOIN(Select cd.DiscountRate, cd.ProductId from dbo.CustomerDiscounts cd where cd.StartDate<GETDATE() and cd.EndDate > GETDATE()) cd on cd.ProductId = p.Id
                        //Where pc.Id = @CategoryId
                        //End

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
                        command.Parameters["@CategoryId"].Value = category.Id;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new ProductQueryModel()
                                {

                                    Category = reader.GetString(reader.GetOrdinal("p.CategoryName")),
                                    Id = reader.GetInt64(reader.GetOrdinal("p.Id")),
                                    Name = reader.GetString(reader.GetOrdinal("p.Name")),
                                    Picture = reader.GetString(reader.GetOrdinal("p.Picture")),
                                    PictureAlt = reader.GetString(reader.GetOrdinal("p.PictureAlt")),
                                    PictureTitle = reader.GetString(reader.GetOrdinal("p.PictureTitle")),

                                };

                                if (!Convert.IsDBNull(reader["p.Price"]))
                                {
                                    var price = reader.GetDouble(reader.GetOrdinal("p.Price"));
                                    product.Price = price.ToMoney();
                                    var discountRate = reader["p.DiscountRate"];

                                    if (!Convert.IsDBNull(reader["p.DiscountRate"]))
                                    {
                                        product.DiscountRate = reader.GetInt32(reader.GetOrdinal("p.PictureTitle"));
                                        product.HasDiscount = product.DiscountRate > 0;
                                        var discountAmount = Math.Round((double)(price * product.DiscountRate) / 100);
                                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                                    }
                                }

                                categoryProducts.Add(product);
                            }
                        }
                    }

                    category.Products = categoryProducts;
                }
            }

            return productCategories;
        }

        public ProductCategoryQueryModel GetProductCategoryBy(string slug)
        {
            var category = new ProductCategoryQueryModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                //GetCategoryBySlug StoredProcedure in db:
                //                @CategorySlug NVarchar(max)
                //AS
                //BEGIN
                //select pc.Id, pc.Name, pc.Description, pc.MetaDescription, pc.KeyWords
                //from dbo.ProductCategories pc
                //where pc.Slug = @CategorySlug
                //End

                using (SqlCommand command = new SqlCommand("GetCategoryBySlug", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@CategorySlug", SqlDbType.NVarChar));
                    command.Parameters["@CategorySlug"].Value = slug;

                    using (SqlDataReader reader = command.ExecuteReader())
                    { 
                        while (reader.Read())
                        {

                            category.Id = reader.GetInt64(reader.GetOrdinal("pc.Id"));
                            category.Name = reader.GetString(reader.GetOrdinal("pc.Name"));
                            category.Description = reader.GetString(reader.GetOrdinal("pc.Description"));
                            category.MetaDescription = reader.GetString(reader.GetOrdinal("pc.MetaDescription"));
                            category.Keywords = reader.GetString(reader.GetOrdinal("pc.Keywords"));
                        }
                    }
                }
            }

            return category;
        }

        public ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string slug)
        {
            var category = GetProductCategoryBy(slug);
            var categoryProducts = new List<ProductQueryModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetProductsByCategorySlug", connection))
                {
                    //GetProductsByCategorySlug StoredProcedure in db:
                    //                    @CategorySlug NVarchar(max)
                    //AS
                    //BEGIN
                    //SELECT pc.Id AS 'pc.Id', pc.Name AS 'p.CategoryName', p.Id AS 'p.Id',  p.Name AS 'p.Name', picture.Picture AS 'p.Picture', Picture.PictureAlt AS 'p.PictureAlt', Picture.PictureTitle AS 'p.PictureTitle', inventory.UnitPrice As 'p.Price', cd.DiscountRate As 'p.DiscountRate'
                    //FROM dbo.ProductCategories pc
                    //INNER JOIN dbo.Products p ON pc.Id = p.CategoryId
                    //INNER JOIN dbo.ProductPictures picture on picture.ProductId = p.Id
                    //Left JOIN dbo.Inventory inventory on inventory.ProductId = p.Id
                    //Left JOIN(Select cd.DiscountRate, cd.ProductId from dbo.CustomerDiscounts cd where cd.StartDate<GETDATE() and cd.EndDate > GETDATE()) cd on cd.ProductId = p.Id
                    //Where pc.Slug = @CategorySlug
                    //End

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@CategorySlug", SqlDbType.NVarChar));
                    command.Parameters["@CategorySlug"].Value = slug;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new ProductQueryModel()
                            {

                                Category = reader.GetString(reader.GetOrdinal("p.CategoryName")),
                                Id = reader.GetInt64(reader.GetOrdinal("p.Id")),
                                Name = reader.GetString(reader.GetOrdinal("p.Name")),
                                Picture = reader.GetString(reader.GetOrdinal("p.Picture")),
                                PictureAlt = reader.GetString(reader.GetOrdinal("p.PictureAlt")),
                                PictureTitle = reader.GetString(reader.GetOrdinal("p.PictureTitle")),
                         
                            };

                            if (!Convert.IsDBNull(reader["p.Price"]))
                            {
                                var price = reader.GetDouble(reader.GetOrdinal("p.Price"));
                                product.Price = price.ToMoney();
                                var discountRate = reader["p.DiscountRate"];

                                if (!Convert.IsDBNull(reader["p.DiscountRate"]))
                                {
                                    product.DiscountRate = reader.GetInt32(reader.GetOrdinal("p.PictureTitle"));
                                    product.HasDiscount = product.DiscountRate > 0;
                                    var discountAmount = Math.Round((double)(price * product.DiscountRate) / 100);
                                    product.PriceWithDiscount = (price - discountAmount).ToMoney();
                                    product.DiscountExpireDate = reader.GetDateTime(reader.GetOrdinal("p.DiscountExpireDate")).ToDiscountFormat();
                                }
                            }

                            categoryProducts.Add(product);
                        }
                    }

                }
            }

            category.Products = categoryProducts;

            return category;
        }
    }

}
