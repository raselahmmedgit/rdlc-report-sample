using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lab.RDLCReportSample.Models
{
    public class CategoryViewModel
    {
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name is required")]
        public string? ProductName { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Product Price is required")]
        public decimal ProductPrice { get; set; }


        public List<SelectListItem> CategoryList { get; set; }

        [Display(Name = "Product")]
        [Required(ErrorMessage = "Product is required")]
        public string SelectProductIds { get; set; }
        public string SelectProductNames { get; set; }
        public List<ProductViewModel> SelectProductViewModelList { get; set; }
        public List<ProductViewModel> ProductViewModelList { get; set; }
    }
}
