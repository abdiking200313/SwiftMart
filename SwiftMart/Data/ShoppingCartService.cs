using Blazored.Toast.Services;
using SwiftMart.Models;

namespace SwiftMart.Data
{
    public class ShoppingCartService
    {
        private readonly SWdbcontext _dbContext;
        IToastService toastService;
        public List<CartItem> ShoppingCart { get; private set; } = new List<CartItem>();

        public event Action OnCartUpdated;

        public ShoppingCartService(SWdbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddToCart(int productId, int quantity)
        {
            var existingCartItem = ShoppingCart.FirstOrDefault(item => item.ProductId == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
                // Retrieve product details from the database and create a new CartItem
                var product = _dbContext.Products.Find(productId);

                if (product != null)
                {
                    ShoppingCart.Add(new CartItem { ProductId = product.Id, Quantity = quantity, Product = product });
                }
            }

            NotifyCartUpdated();
        }

        public void RemoveFromCart(int productId)
        {
            var itemToRemove = ShoppingCart.FirstOrDefault(item => item.ProductId == productId);

            if (itemToRemove != null)
            {
                var product = itemToRemove.Product;

                if (itemToRemove.Quantity > 1)
                {
                    itemToRemove.Quantity -= 1;

                }
                else
                {
                    ShoppingCart.Remove(itemToRemove);
                }

            }
        }

        public List<CartItem> GetCartItems()
        {
            return ShoppingCart;
        }

        public decimal GetTotalPrice()
        {
            return (decimal)ShoppingCart.Sum(item => item.Product.Price * item.Quantity);
        }

        private void NotifyCartUpdated()
        {
            OnCartUpdated?.Invoke();
        }
    }
}
