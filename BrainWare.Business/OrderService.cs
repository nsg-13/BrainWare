using System.Collections.Generic;
using System.Linq;

using BrainWare.Business.Entities;
using BrainWare.Data;

namespace BrainWare.Business
{
    public class OrderService
    {
        private OrderRepository context = new OrderRepository();

        /// <summary>
        /// Get list of orders for company.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<Order> GetOrdersForCompany(int companyId)
        {
            var orderResult = new List<Order>();

                var orders = context.GetOrdersForCompany(companyId);

                orderResult = orders.Select(o => new Order()
                {
                    Description = o.Description,
                    CompanyName = o.Company.Name,
                    OrderId = o.OrderID,
                    OrderProducts = o.OrderProducts.Select(op => new OrderProduct()
                    {
                        OrderId = op.OrderID,
                        Price = op.Price.HasValue ? op.Price.Value : 0.0m,
                        Quantity = op.Quantity,
                        Product = new Product()
                        {
                            Name = op.Product.Name,
                            Price = op.Product.Price ?? 0.0m
                        }
                    }).ToList(),
                    OrderTotal = o.OrderProducts.Sum(op => (op.Price ?? 0.0m) * op.Quantity)
                }).ToList();


            return orderResult;
        }
    }
}
