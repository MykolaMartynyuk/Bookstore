using Bookstore.Data.DataObjects;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bookstore.Models.OrderWM
{
    public class CheckoutWM
    {
        ShoppingCart _shopingCart = new ShoppingCart();
        public CheckoutWM(ShoppingCart shopingCart)
        {
            _shopingCart = shopingCart;
            ShoppingCart = _shopingCart;
            NewOrder = new Order();
        }

        public CheckoutWM()
        {

        }

        [ValidateNever]
        public Order NewOrder { get ; set; }

        //public OrderLines NewOrderLines { get; set; }

        //public List<OrderLines> NewOrderLinesToList;

        [ValidateNever]
        public ShoppingCart ShoppingCart { get;set; }
    }
}
