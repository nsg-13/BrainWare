using System.Collections.Generic;
using System.Web.Http;

using BrainWare.Business;
using BrainWare.Business.Entities;

namespace Web.Controllers
{
    /// <summary>
    /// Controller for the Orders.
    /// </summary>
    public class OrderController : ApiController
    {
        private OrderService orderService = new OrderService();

        /// <summary>
        /// Get orders for company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Order> GetOrders(int id = 1)
        {
            return orderService.GetOrdersForCompany(id);
        }
    }
}
