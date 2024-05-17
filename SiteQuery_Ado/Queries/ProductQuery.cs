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

        public List<ProductQueryModel> GetLatestArrivals()
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

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public List<ProductQueryModel> Search(string value)
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
                                Picture = reader.GetString(reader.GetOrdinal("p.Picture")),
                                PictureAlt = reader.GetString(reader.GetOrdinal("p.PictureAlt")),
                                PictureTitle = reader.GetString(reader.GetOrdinal("p.PictureTitle")),
                                Slug = reader.GetString(reader.GetOrdinal("p.Slug")),
                                ShortDescription = reader.GetString(reader.GetOrdinal("p.ShortDescription")),
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

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}
