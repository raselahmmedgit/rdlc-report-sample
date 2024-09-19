using System.ComponentModel.DataAnnotations;

namespace lab.RDLCReportSample.Models
{
    public class ProductMultiDropdownViewModel : DropdownViewModel
    {
        [Display(Name = "Product:")]
        public int[]? ProductIdList { get; set; }

        [Display(Name = "Product:")]
        public string[]? ProductNameList { get; set; }

        //[Display(Name = "Product:")]
        //public string ProductNameList
        //{
        //    get
        //    {
        //        if (SelectedValueList != null)
        //        {
        //            return string.Join(",", SelectedValueList);
        //        }
        //        else
        //        {
        //            return string.Empty;
        //        }
        //    }
        //}

    }
}
