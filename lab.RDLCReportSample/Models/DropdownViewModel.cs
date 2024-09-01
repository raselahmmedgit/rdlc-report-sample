using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab.RDLCReportSample.Models
{
    public class DropdownViewModel
    {
        public DropdownViewModel()
        {
            IsReadOnly = false;
            IsRequiredCascad = false;
            IsRequired = false;
            IsMultiple = false;
            IsChkMultiple = false;
            IsChkMultipleCascad = false;
        }
        public string? KeyId { get; set; }
        public string? KeyName { get; set; }
        public string? KeyIdTwo { get; set; }
        public string? KeyNameTwo { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsRequired { get; set; }
        public string? RequiredMessage { get; set; }

        public bool IsRequiredCascad { get; set; }
        public string? RequiredCascadMessage { get; set; }

        //Parent Key Need for Fillter Child Drop Down 
        public int? ParentKey { get; set; }

        public int? SelectedValue { get; set; }
        public string? SelectedText { get; set; }

        public bool IsMultiple { get; set; }
        public int[]? SelectedValueList { get; set; }
        public string[]? SelectedTextList { get; set; }

        public bool IsChkMultiple { get; set; }

        public string? KeyIdCascad { get; set; }
        public string? KeyNameCascad { get; set; }
        public bool IsChkMultipleCascad { get; set; }
        public string ChkMultipleCascadUrl { get; set; }

        public List<SelectListItem> SelectList { get; set; }
    }
}
