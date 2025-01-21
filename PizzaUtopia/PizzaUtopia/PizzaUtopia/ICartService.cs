using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PizzaUtopia
{
    internal interface ICartService
    {
        void AddToCart(Pizza pizza);
        void RemoveFromCart(Pizza pizza);
        void ClearCart();
        List<Pizza> GetCart();
    }

    public class Pizza
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }

    public class CartService : ICartService
    {
        private List<Pizza> _cart = new List<Pizza>();
        public void AddToCart(Pizza pizza)
        {
            _cart.Add(pizza);
        }
        public void RemoveFromCart(Pizza pizza)
        {
            _cart.Remove(pizza);
        }
        public void ClearCart()
        {
            _cart.Clear();
        }
        public List<Pizza> GetCart()
        {
            return _cart;
        }
    }
}
