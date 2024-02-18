using ePizza.Repositories.Interfaces;
using ePizzaHub.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Repositories.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDbContext appContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public OrderRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Order> GetUserOrders(int UserId)
        {
          return appContext.orders.Include(o=>o.OrderItems).Where(x=>x.UserId == UserId).ToList();
        }
    }
}
