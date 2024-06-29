using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Infrastructure.DataAccess;
using Microsoft.Data.SqlClient;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;
using System.Data;

namespace SiteQuery_Ado.Queries
{
    public class CartCalculatorService : ICartCalculatorService
    {
        private readonly string _connectionString;

        public CartCalculatorService( string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<CartQueryModel> ComputeCart(List<CartItemQueryModel> cartItems, CancellationToken cancellationToken, IAuthHelper authHelper)
        {
            var cart = new CartQueryModel();
            var colleagueDiscounts = new List<DiscountQueryModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetColleagueDiscounts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var discount = new DiscountQueryModel()
                            {
                                DiscountRate = reader.GetInt32(reader.GetOrdinal("cd.DiscountRate")),
                                ProductId = reader.GetInt64(reader.GetOrdinal("cd.ProductId"))
                            };

                            colleagueDiscounts.Add(discount);
                        }


                    }
                }
            }
        

                var customerDiscounts = new List<DiscountQueryModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetCustomerDiscounts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var discount = new DiscountQueryModel()
                            {
                                DiscountRate = reader.GetInt32(reader.GetOrdinal("cd.DiscountRate")),
                                ProductId = reader.GetInt64(reader.GetOrdinal("cd.ProductId"))
                            };
                            customerDiscounts.Add(discount);
                        }


                    }
                }
            }


            var currentAccountRole =  authHelper.CurrentAccountRole();

                foreach (var cartItem in cartItems)
                {
                    if (currentAccountRole == Roles.ColleagueUser)
                    {
                        var colleagueDiscount = colleagueDiscounts.FirstOrDefault(x => x.ProductId == cartItem.Id);
                        if (colleagueDiscount != null)
                            cartItem.DiscountRate = colleagueDiscount.DiscountRate;
                    }
                    else
                    {
                        var customerDiscount = customerDiscounts.FirstOrDefault(x => x.ProductId == cartItem.Id);
                        if (customerDiscount != null)
                            cartItem.DiscountRate = customerDiscount.DiscountRate;
                    }

                    cartItem.DiscountAmount = ((cartItem.TotalItemPrice * cartItem.DiscountRate) / 100);
                    cartItem.ItemPayAmount = cartItem.TotalItemPrice - cartItem.DiscountAmount;
                    cart.Add(cartItem);
                }

                return cart;
            }
        }
    
}
