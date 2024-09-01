namespace lab.RDLCReportSample.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}