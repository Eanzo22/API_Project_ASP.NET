namespace ECommerce.BL.DTOS.CartItems
{
    public class ReadCartItemDto
    {
        public int Id { get; set; } // Unique identifier for the cart item
        public int Quantity { get; set; } // Quantity of the product in the cart
        public required int CartId { get; set; } // Identifier of the user who owns the cart item
        public int ProductId { get; set; } // Identifier of the product in the cart item

    }
}