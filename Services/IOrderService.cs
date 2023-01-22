using Bookstore.Data.DataObjects;

namespace Bookstore.Services
{
    public interface IOrderService
    {
        public void SaveOrder(Order order, ShoppingCart cart);
    }
}
