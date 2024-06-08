using Base_Framework.Domain.General;
using Microsoft.Data.SqlClient;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;
using System.Data;

namespace SiteQuery_Ado.Queries
{
    public class ProductQuery : IProductQuery
    {
        private readonly string _connectionString;

        public ProductQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ProductQueryModel> GetDetails(string slug, CancellationToken cancellationToken)
        {
            var product = new ProductQueryModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetProductBySlug", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@slug", SqlDbType.NVarChar));
                    command.Parameters["@slug"].Value = slug;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.Id = reader.GetInt64(reader.GetOrdinal("p.Id"));

                            product.Category = reader.GetString(reader.GetOrdinal("p.CategoryName"));
                           
                            product.Name = reader.GetString(reader.GetOrdinal("p.Name"));
                            product.Slug = reader.GetString(reader.GetOrdinal("p.Slug"));
                            product.ShortDescription = reader.GetString(reader.GetOrdinal("p.ShortDescription"));
                            product.Code = reader.GetString(reader.GetOrdinal("p.Code"));
                            product.CategorySlug = reader.GetString(reader.GetOrdinal("p.CategorySlug"));
                            product.Keywords = reader.GetString(reader.GetOrdinal("p.Keywords"));
                            product.MetaDescription = reader.GetString(reader.GetOrdinal("p.MetaDescription"));
                            product.Pictures = await GetPicturesByProductId(product.Id, cancellationToken);

                            var firstPicture = await GetFirstPictureByProductId(product.Id, cancellationToken);

                            product.Picture = firstPicture.Picture;
                            product.PictureAlt = firstPicture.PictureAlt;
                            product.PictureTitle = firstPicture.PictureTitle;

                            if (!Convert.IsDBNull(reader["p.Price"]))
                            {
                                product.IsInStock = reader.GetBoolean(reader.GetOrdinal("p.InStock"));
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

                            
                        }
                    }
                }
            }

            product.Comments =await GetCommentsByProductId(product.Id, cancellationToken);
            return product;
        }

        public async Task<List<ProductQueryModel>> GetLatestArrivals(CancellationToken cancellationToken)
        {
            //GetLastArrivals StoredProcedure in db:
            //            BEGIN
            //SELECT top 6 pc.Id AS 'pc.Id', pc.Name AS 'p.CategoryName', p.Id AS 'p.Id',  p.Name AS 'p.Name', picture.Picture AS 'p.Picture', Picture.PictureAlt AS 'p.PictureAlt', Picture.PictureTitle AS 'p.PictureTitle', inventory.UnitPrice As 'p.Price', cd.DiscountRate As 'p.DiscountRate'
            //FROM dbo.ProductCategories pc
            //INNER JOIN dbo.Products p ON pc.Id = p.CategoryId
            //INNER JOIN dbo.ProductPictures picture on picture.ProductId = p.Id
            //Left JOIN dbo.Inventory inventory on inventory.ProductId = p.Id
            //Left JOIN(Select cd.DiscountRate, cd.ProductId from dbo.CustomerDiscounts cd where cd.StartDate<GETDATE() and cd.EndDate > GETDATE()) cd on cd.ProductId = p.Id
            //ORDER BY p.Id DESC
            //End

            var products = new List<ProductQueryModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetLastestArrivals", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new ProductQueryModel()
                            {

                                Category = reader.GetString(reader.GetOrdinal("p.CategoryName")),
                                Id = reader.GetInt64(reader.GetOrdinal("p.Id")),
                                Name = reader.GetString(reader.GetOrdinal("p.Name")),
                              
                                CategorySlug = reader.GetString(reader.GetOrdinal("p.CategorySlug"))

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

                            var firstPicture = await GetFirstPictureByProductId(product.Id, cancellationToken);

                            product.Picture = firstPicture.Picture;
                            product.PictureAlt = firstPicture.PictureAlt;
                            product.PictureTitle = firstPicture.PictureTitle;

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public async Task<List<ProductQueryModel>> Search(string value, CancellationToken cancellationToken)
        {
            var products = new List<ProductQueryModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SearchProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@value", SqlDbType.NVarChar));
                    command.Parameters["@value"].Value = value;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new ProductQueryModel()
                            {

                                Category = reader.GetString(reader.GetOrdinal("p.CategoryName")),
                                Id = reader.GetInt64(reader.GetOrdinal("p.Id")),
                                Name = reader.GetString(reader.GetOrdinal("p.Name")),
                                Slug = reader.GetString(reader.GetOrdinal("p.Slug")),
                                ShortDescription = reader.GetString(reader.GetOrdinal("p.ShortDescription")),
                                CategorySlug = reader.GetString(reader.GetOrdinal("p.CategorySlug"))
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

                            var firstPicture = await GetFirstPictureByProductId(product.Id, cancellationToken);

                            product.Picture = firstPicture.Picture;
                            product.PictureAlt = firstPicture.PictureAlt;
                            product.PictureTitle = firstPicture.PictureTitle;

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public async Task<List<ProductPictureQueryModel>> GetPicturesByProductId(long id, CancellationToken cancellationToken)
        {
            var productPictures = new List<ProductPictureQueryModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetPicturesByProductId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar));
                    command.Parameters["@productId"].Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                       
                        while (reader.Read())
                        {
                            var picture = new ProductPictureQueryModel();

                            picture.Picture = reader.GetString(reader.GetOrdinal("p.Picture"));
                            picture.PictureAlt = reader.GetString(reader.GetOrdinal("p.PictureAlt"));
                            picture.PictureTitle = reader.GetString(reader.GetOrdinal("p.PictureTitle"));
                          picture.ProductId = reader.GetInt64(reader.GetOrdinal("p.Id"));

                            productPictures.Add(picture);
                        }
                    }
                }
            }

            return productPictures;
        }


        public async Task<ProductPictureQueryModel> GetFirstPictureByProductId(long id, CancellationToken cancellationToken)
        {
            var picture = new ProductPictureQueryModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetFirstPictureByProductId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar));
                    command.Parameters["@productId"].Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                           

                            picture.Picture = reader.GetString(reader.GetOrdinal("p.Picture"));
                            picture.PictureAlt = reader.GetString(reader.GetOrdinal("p.PictureAlt"));
                            picture.PictureTitle = reader.GetString(reader.GetOrdinal("p.PictureTitle"));
                            picture.ProductId = reader.GetInt64(reader.GetOrdinal("p.Id"));

                    
                        }
                    }
                }
            }

            return picture;
        }

        private async Task<List<CommentQueryModel>> GetCommentsByProductId(long productId, CancellationToken cancellationToken)
        {
            var Comments = new List<CommentQueryModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetCommentsByProductId ", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@productId", SqlDbType.NVarChar));
                    command.Parameters["@productId"].Value = productId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var comment = new CommentQueryModel();

                            comment.Id = reader.GetInt64(reader.GetOrdinal("c.Id"));
                            comment.Name = reader.GetString(reader.GetOrdinal("c.Name"));
                            comment.Message = reader.GetString(reader.GetOrdinal("c.Message"));
                            comment.CreationDate = reader.GetDateTime(reader.GetOrdinal("c.CreationDate")).ToFarsi();
                            comment.Name = reader.GetString(reader.GetOrdinal("c.Name"));

                            if (!Convert.IsDBNull(reader["c.ParentId"]))
                            {
                                comment.ParentId = reader.GetInt64(reader.GetOrdinal("c.ParentId"));
                                comment.parentName = await GetCommentNameById(comment.Id, cancellationToken);
                            }


                            Comments.Add(comment);
                        }
                    }
                }
            }

            return Comments;
        }

        private async Task<string> GetCommentNameById(long id, CancellationToken cancellationToken)
        {
            var name = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetCommentNameById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar));
                    command.Parameters["@id"].Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           name = reader.GetString(reader.GetOrdinal("c.Name"));
                        }
                    }
                }
            }
            return name;
        }
    }
}
