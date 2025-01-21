namespace StoresApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Product> Products { get; set; }  // Relación con los productos
    }
}
