using System.ComponentModel.DataAnnotations;

namespace lab.RDLCReportSample.Models
{
    public class ProductViewModel
    {
        [Display(Name = "Product")]
        [Required(ErrorMessage = "Product is required")]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public bool IsChecked { get; set; }
        public bool IsAdded { get; set; }
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }

    }
}
