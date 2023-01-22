using Bookstore.Data.DataObjects;
using Bookstore.Services;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Bookstore.Models.OrderWM
{
    public class CartWM
    {
        private ShoppingCart? _shopingCart = new ShoppingCart();

        public CartWM(ShoppingCart cart)
        {
            _shopingCart = cart;
            ShoppingCart = _shopingCart;
            var test = ShoppingCart;
        }

        public ShoppingCart ShoppingCart { get => _shopingCart; set => _shopingCart = value; }

    }
}
