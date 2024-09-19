using System.ComponentModel.DataAnnotations;

namespace lab.RDLCReportSample.Helpers
{
    public static class AppEnums
    {
        public enum ExportType
        {
            [Display(Name = "pdf")]
            Pdf = 1,
            [Display(Name = "excel")]
            Excel = 2

        }

    }
}
