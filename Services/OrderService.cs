using Bookstore.Data;
using Bookstore.Data.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services
{
    public class OrderService : IOrderService
    {
        public void SaveOrder(Order order, ShoppingCart cart)
        {
            using(var context = new ApplicationDbContext())
            {
                context.Order.Add(order);
                context.SaveChanges();
                foreach (var book in cart)
                {
                    context.OrderLines.Add(new OrderLines
                    {
                        BookId = book.Id,
                        OrderId = context.Order.Max(x=> x.Id),
                        Price = book.Price,
                        Quantity = cart.Count(x => x == book)
                        });
                }
                //context.OrderLines.Add(orderLines);
                context.SaveChanges();
            }
        }
    }
}
