using System.ComponentModel.DataAnnotations;

namespace lab.RDLCReportSample.Models
{
    public class ProductDropdownViewModel : DropdownViewModel
    {
        [Display(Name = "Product:")]
        public int? ProductId { get; set; }

        [Display(Name = "Product:")]
        public string? ProductName { get; set; }
    }
}
