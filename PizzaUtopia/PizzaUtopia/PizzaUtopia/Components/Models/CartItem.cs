namespace PizzaUtopia.Components.Models
{
    public class CartItem
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl => $"{Name.ToLower().Replace(" ", "-")}-pizza.png";
        public int Quantity { get; set; }
    }
}
