namespace OnlineShop.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int CourseId { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }

        public virtual Course course { get; set; }
        public virtual Order order { get; set; }

    }
}