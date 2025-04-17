using Microsoft.AspNetCore.Mvc.Rendering;



namespace ECommerceWebsite.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; } = new Product();
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
