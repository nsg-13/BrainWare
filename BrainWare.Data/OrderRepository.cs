using System.Collections.Generic;
using System.Linq;

using BrainWare.Data.Entities;

namespace BrainWare.Data
{
    /// <summary>
    /// Repository class for Orders
    /// </summary>
    public class OrderRepository
    {
        private BrainWareContext context = new BrainWareContext();

        public OrderRepository()
        {
        }

        /// <summary>
        /// Get orders for company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetOrdersForCompany(int companyId)
        {
            var orders = context.Orders.Where(o => o.CompanyID == companyId).ToList();

            return orders.ToList();
        }
    }
}
