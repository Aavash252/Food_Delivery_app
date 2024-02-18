using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePizza.Repositories.Interfaces;
using ePizzaHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace ePizza.Repositories.Implementation
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDbContext appContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public CartRepository(DbContext context) : base(context) 
        {
            
        }

        public Cart GetCart(Guid CartId)
        {
            return appContext.Carts.Include("Items").Where(c=>c.Id == CartId && c.IsActive == true).FirstOrDefault();
        }

        public int DeleteItem(Guid CartId, int itemId)
        {
            var item = appContext.cartItems.Where(x=>x.Equals(CartId) && x.Id==itemId).FirstOrDefault();
            if (item != null)
            {
                appContext.cartItems.Remove(item);
                return appContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int UpdateQuantity(Guid CartId, int itemId, int Quantity)
        {
            bool flag=false;
            var cart = GetCart(CartId);
            if(cart != null)
            {
                for(int i=0; i<cart.Items.Count; i++)
                {
                    flag=true;
                    if(Quantity <0 && cart.Items[i].Quantity > 1)
                        cart.Items[i].Quantity += Quantity;
                    else if (Quantity >0)
                        cart.Items[i].Quantity += Quantity;
                    break;
                }
                if (flag)
                    return appContext.SaveChanges();
            }
            return 0;
        }

        public int UpdateCart(Guid CartId, int userId)
        {
            Cart cart = GetCart(CartId);
            cart.UserId = userId;
            return appContext.SaveChanges();    
        }
    }
}
