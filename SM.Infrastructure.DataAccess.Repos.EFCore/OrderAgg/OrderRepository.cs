using AM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Base_Framework.Domain.General;
using Base_Framework.Infrastructure.DataAccess;
using SM.Domain.Core.OrderAgg.Data;
using SM.Domain.Core.OrderAgg.DTOs.Order;
using SM.Domain.Core.OrderAgg.Entities;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;

namespace SM.Infrastructure.DataAccess.Repos.EFCore.OrderAgg
{
    public class OrderRepository : BaseRepository_EFCore<Order>,  IOrderRepository
    {
        private readonly ShopContext _context;
        private readonly AccountContext _accountContext;

        public OrderRepository(ShopContext context, AccountContext accountContext) : base(context)
        {
            _context = context;
            _accountContext = accountContext;
        }

        public async Task AddItem(OrderItemDTO item, CancellationToken cancellationToken)
        {
            var orderItem = new OrderItem(item.ProductId, item.Count, item.UnitPrice, item.DiscountRate);
            var order = Get(item.OrderId);
            order.AddItem(orderItem);
        }

        public async Task Cancel(long id, CancellationToken cancellationToken)
        {
            var order = Get(id);
            order.Cancel();
        }

        public async Task<double> GetAmountBy(long id, CancellationToken cancellationToken)
        {
            var order = _context.Orders
               .Select(x => new { x.PayAmount, x.Id })
               .FirstOrDefault(x => x.Id == id);
            if (order != null)
                return order.PayAmount;
            return 0;
        }

        public async Task<List<OrderItemDTO>> GetItems(long orderId, CancellationToken cancellationToken)
        {
            var products = _context.Products.Select(x => new { x.Id, x.Name }).ToList();
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null)
                return new List<OrderItemDTO>();

            var items = order.Items.Select(x => new OrderItemDTO
            {
                Id = x.Id,
                Count = x.Count,
                DiscountRate = x.DiscountRate,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).ToList();

            foreach (var item in items)
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            }

            return items;
        }

        public async Task PaymentSucceeded(long orderId, long refId,string issueTrackingNo, CancellationToken cancellationToken)
        {
            var order = Get(orderId);
            order.PaymentSucceeded(refId);
            order.SetIssueTrackingNo(issueTrackingNo);
        }

        public async Task<long> PlaceOrder(OrderDTO order, CancellationToken cancellationToken)
        {
            var dbOrder = new Order(order.AccountId, order.PaymentMethodId, order.TotalAmount, order.DiscountAmount, order.PayAmount);
            _context.Orders.Add(dbOrder);
            Save();
            return dbOrder.Id;
        }


        public async Task<List<OrderDTO>> Search(SearchOrderDTO searchModel, CancellationToken cancellationToken)
        {
            var accounts = _accountContext.Accounts.Select(x => new { x.Id, x.Fullname }).ToList();
            var query = _context.Orders.Select(x => new OrderDTO
            {
                Id = x.Id,
                AccountId = x.AccountId,
                DiscountAmount = x.DiscountAmount,
                IsCanceled = x.IsCanceled,
                IsPaid = x.IsPaid,
                IssueTrackingNo = x.IssueTrackingNo,
                PayAmount = x.PayAmount,
                PaymentMethodId = x.PaymentMethod,
                RefId = x.RefId,
                TotalAmount = x.TotalAmount,
                CreationDate = x.CreationDate.ToFarsi()
            });

            query = query.Where(x => x.IsCanceled == searchModel.IsCanceled);

            if (searchModel.AccountId > 0) query = query.Where(x => x.AccountId == searchModel.AccountId);

            var orders = query.OrderByDescending(x => x.Id).ToList();
            foreach (var order in orders)
            {
                order.AccountFullName = accounts.FirstOrDefault(x => x.Id == order.AccountId)?.Fullname;
            }

            return orders;
        }
    }
}
