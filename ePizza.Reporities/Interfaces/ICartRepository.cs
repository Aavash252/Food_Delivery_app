using ePizzaHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Repositories.Interfaces
{
    public interface ICartRepository:IRepository<Cart>
    {
        Cart GetCart(Guid CartId);

        int DeleteItem(Guid CartId , int itemId);
        int UpdateQuantity(Guid CartId , int itemId ,int Quantity);
        int UpdateCart(Guid CartId , int userId);
    }
}
