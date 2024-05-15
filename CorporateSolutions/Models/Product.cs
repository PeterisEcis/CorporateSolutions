using Microsoft.Extensions.Options;

namespace CorporateSolutions.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithVat => this.Quantity * this.Price * (decimal)(1 + VatOptions.Rate);

    }

    public static class VatOptions
    {
        public static double Rate => 0.21;
    }
}
