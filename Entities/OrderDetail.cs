namespace Entities
{
    public class OrderDetail : BaseEntity
    {
        public decimal ItemPrice { get; set; }
        public ushort Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Orders { get; set; }
    }
}
