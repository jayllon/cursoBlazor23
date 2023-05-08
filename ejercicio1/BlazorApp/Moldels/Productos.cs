namespace BlazorApp.Moldels
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public RateDTO rating { get; set; }
    }

public class RateDTO
    {
        public decimal rate { get; set; }
        public int count { get; set; }
    }
}
