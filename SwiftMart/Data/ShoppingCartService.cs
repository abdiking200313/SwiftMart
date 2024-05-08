
using SwiftMart.Models;

namespace SwiftMart.Data
{
    public class ShoppingCartService
    {
        private readonly SWdbcontext _dbContext;

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
            var itemToRemove = ShoppingCart.FirstOrDefault(item => item.Product.Id == productId);
            if (itemToRemove != null)
            {
                ShoppingCart.Remove(itemToRemove);
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

        public void DecreaseQuantity(int productId)
        {
            var itemToDecrease = ShoppingCart.FirstOrDefault(item => item.Product.Id == productId);

            if (itemToDecrease != null && itemToDecrease.Quantity > 1)
            {
                itemToDecrease.Quantity--;
            }
        }

        // Method to increase the quantity of an item in the cart
        public void IncreaseQuantity(int productId)
        {
            var itemToIncrease = ShoppingCart.FirstOrDefault(item => item.Product.Id == productId);

            if (itemToIncrease != null)
            {
                itemToIncrease.Quantity++;
            }
        }
    }
}
