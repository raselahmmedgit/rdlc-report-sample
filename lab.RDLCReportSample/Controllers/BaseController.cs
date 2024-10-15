using Microsoft.AspNetCore.Mvc;
using lab.RDLCReportSample.Helpers;
using lab.RDLCReportSample.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Reporting.NETCore;
using lab.RDLCReportSample.Extensions;
using System.Collections;

namespace lab.RDLCReportSample.Controllers
{
    public class BaseController : Controller
    {
        private IHostEnvironment _webHostEnvironment;
        public IHostEnvironment WebHostEnvironment
        {
            get
            {
                if (_webHostEnvironment == null)
                {
                    _webHostEnvironment = (IWebHostEnvironment)HttpContext.RequestServices.GetService(typeof(IWebHostEnvironment));
                }
                return _webHostEnvironment;
            }
            private set
            {
                _webHostEnvironment = value;
            }
        }

        internal IActionResult ErrorView(Exception ex)
        {
            var errorViewModel = new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorType = MessageHelper.MessageTypeDanger, ErrorMessage = MessageHelper.Error };
            return View("~/Views/Shared/Error.cshtml", errorViewModel);
        }

        internal IActionResult ErrorPartialView(Exception ex)
        {
            var errorViewModel = new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,  ErrorType = MessageHelper.MessageTypeDanger, ErrorMessage = MessageHelper.Error };
            return PartialView("~/Views/Shared/_Error.cshtml", errorViewModel);
        }

        internal IActionResult ErrorNullView()
        {
            var errorViewModel = new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,  ErrorType = MessageHelper.Info, ErrorMessage = MessageHelper.NullError };
            return View("~/Views/Shared/Error.cshtml", errorViewModel);
        }

        internal IActionResult ErrorNullPartialView()
        {
            var errorViewModel = new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,  ErrorType = MessageHelper.Info, ErrorMessage = MessageHelper.NullError };
            return PartialView("~/Views/Shared/_Error.cshtml", errorViewModel);
        }

        #region Generate Raw Report

        //Start Generate Raw Report File
        public byte[] GetRawReport(IEnumerable dataSource, Dictionary<string, string> reportParams, string fileType, string fileName, string controllerName, string areaName)
        {
            if (fileType == AppEnums.ExportType.Pdf.ToDisplayAttr().Name)
            {
                return GetRawPdfReport(dataSource, reportParams, fileName, fileName, controllerName, areaName);
            }
            else if (fileType == AppEnums.ExportType.Excel.ToDisplayAttr().Name)
            {
                return GetRawExcelReport(dataSource, reportParams, fileName, fileName, controllerName, areaName);
            }
            else
            {
                return null;
            }
        }
        public byte[] GetRawReport(IEnumerable dataSource, string fileType, string fileName, string controllerName, string areaName)
        {
            if (fileType == AppEnums.ExportType.Pdf.ToDisplayAttr().Name)
            {
                return GetRawPdfReport(dataSource, fileName, fileName, controllerName, areaName);
            }
            else if (fileType == AppEnums.ExportType.Excel.ToDisplayAttr().Name)
            {
                return GetRawExcelReport(dataSource, fileName, fileName, controllerName, areaName);
            }
            else
            {
                return null;
            }
        }
        
        public byte[] GetRawExcelReport(IEnumerable dataSource, string fileName, string controllerName, string areaName)
        {
            return GetRawExcelReport(dataSource, fileName, fileName, controllerName, areaName);
        }

        public byte[] GetRawExcelReport(IEnumerable dataSource, string reportName, string fileName, string controllerName, string areaName)
        {

            string filePath = Path.Combine("wwwroot", "reprots", "lab.RDLCReportSample.Rdlc", $"{reportName}.rdl");
            filePath = Path.Combine(WebHostEnvironment.ContentRootPath, filePath);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using var reportDefinition = new FileStream(filePath, FileMode.Open);

                    using var report = new LocalReport();
                    report.LoadReportDefinition(reportDefinition);
                    var dsName = report.GetDataSourceNames();
                    report.DataSources.Add(new ReportDataSource(dsName[0], dataSource));
                    byte[] excel = report.Render("EXCELOPENXML");
                    return excel;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        public byte[] GetRawExcelReport(IEnumerable dataSource, Dictionary<string, string> reportParams, string reportName, string fileName, string controllerName, string areaName)
        {

            string filePath = Path.Combine("wwwroot", "reprots", "lab.RDLCReportSample.Rdlc", $"{reportName}.rdl");
            filePath = Path.Combine(WebHostEnvironment.ContentRootPath, filePath);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using var reportDefinition = new FileStream(filePath, FileMode.Open);

                    using var report = new LocalReport();
                    report.LoadReportDefinition(reportDefinition);
                    var dsName = report.GetDataSourceNames();
                    report.DataSources.Add(new ReportDataSource(dsName[0], dataSource));

                    if (reportParams != null)
                    {
                        List<ReportParameter> reportParameters = new();
                        foreach (KeyValuePair<string, string> item in reportParams)
                        {
                            reportParameters.Add(new ReportParameter(item.Key, item.Value));
                        }
                        report.SetParameters(reportParameters);
                    }

                    byte[] excel = report.Render("EXCELOPENXML");
                    return excel;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        public byte[] GetRawPdfReport(IEnumerable dataSource, string fileName, string controllerName, string areaName)
        {
            return GetRawPdfReport(dataSource, fileName, fileName, controllerName, areaName);
        }
        
        public byte[] GetRawPdfReport(IEnumerable dataSource, string reportName, string fileName, string controllerName, string areaName)
        {

            string filePath = Path.Combine("wwwroot", "reprots", "lab.RDLCReportSample.Rdlc", $"{reportName}.rdl");
            filePath = Path.Combine(WebHostEnvironment.ContentRootPath, filePath);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using var reportDefinition = new FileStream(filePath, FileMode.Open);

                    using var report = new LocalReport();
                    report.LoadReportDefinition(reportDefinition);
                    var dsName = report.GetDataSourceNames();
                    report.DataSources.Add(new ReportDataSource(dsName[0], dataSource));
                    byte[] pdf = report.Render("PDF");
                    return pdf;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
        
        public byte[] GetRawPdfReport(IEnumerable dataSource, Dictionary<string, string> reportParams, string reportName, string fileName, string controllerName, string areaName)
        {

            string filePath = Path.Combine("wwwroot", "reprots", "lab.RDLCReportSample.Rdlc", $"{reportName}.rdl");
            filePath = Path.Combine(WebHostEnvironment.ContentRootPath, filePath);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using var reportDefinition = new FileStream(filePath, FileMode.Open);

                    using var report = new LocalReport();
                    report.LoadReportDefinition(reportDefinition);
                    var dsName = report.GetDataSourceNames();
                    report.DataSources.Add(new ReportDataSource(dsName[0], dataSource));

                    if (reportParams != null)
                    {
                        List<ReportParameter> reportParameters = new();
                        foreach (KeyValuePair<string, string> item in reportParams)
                        {
                            reportParameters.Add(new ReportParameter(item.Key, item.Value));
                        }
                        report.SetParameters(reportParameters);
                    }

                    byte[] pdf = report.Render("PDF");
                    return pdf;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        //End Generate Raw Report File

        //Start Action
        #region Generic Report Multiple Datasource and Multiple Params
        [NonAction]
        public IActionResult GetReport(Dictionary<string, List<object>> dataSource, Dictionary<string, string> reportParams, string fileType, string fileName, string controllerName, string areaName)
        {
            if (fileType == AppEnums.ExportType.Pdf.ToDisplayAttr().Name)
            {
                return GetPdfReport(dataSource, reportParams, fileName, fileName, controllerName, areaName);
            }
            else if (fileType == AppEnums.ExportType.Excel.ToDisplayAttr().Name)
            {
                return GetExcelReport(dataSource, reportParams, fileName, fileName, controllerName, areaName);
            }
            else
            {
                return null;
            }
        }

        [NonAction]
        public IActionResult GetReport(IEnumerable dataSource, Dictionary<string, string> reportParams, string fileType, string fileName, string controllerName, string areaName)
        {
            if (fileType == AppEnums.ExportType.Pdf.ToDisplayAttr().Name)
            {
                return GetPdfReport(dataSource, reportParams, fileName, fileName, controllerName, areaName);
            }
            else if (fileType == AppEnums.ExportType.Excel.ToDisplayAttr().Name)
            {
                return GetExcelReport(dataSource, reportParams, fileName, fileName, controllerName, areaName);
            }
            else
            {
                return null;
            }
        }

        [NonAction]
        public IActionResult GetExcelReport(Dictionary<string, List<object>> dataSource, Dictionary<string, string> reportParams, string fileName, string controllerName, string areaName)
        {
            return GetExcelReport(dataSource, reportParams, fileName, fileName, controllerName, areaName);
        }

        [NonAction]
        public IActionResult GetExcelReport(Dictionary<string, List<object>> dataSource, Dictionary<string, string> reportParams, string reportName, string fileName, string controllerName, string areaName)
        {
            fileName = $"{fileName}_{DateTime.Now.ToFormatedDateTimeWithAmPmString("_", true)}";
            string filePath = Path.Combine("wwwroot", "reprots", "lab.RDLCReportSample.Rdlc", $"{reportName}.rdl");
            //Path.Combine("Areas", areaName, "Views", controllerName, $"{reportName}.rdl");
            string extension = ".xlsx";
            string mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            filePath = Path.Combine(WebHostEnvironment.ContentRootPath, filePath);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using var reportDefinition = new FileStream(filePath, FileMode.Open);

                    using var report = new LocalReport();
                    report.LoadReportDefinition(reportDefinition);
                    var dsName = report.GetDataSourceNames();

                    if (dataSource != null)
                    {
                        foreach (KeyValuePair<string, List<object>> item in dataSource)
                        {
                            report.DataSources.Add(new ReportDataSource(item.Key, item.Value));
                        }
                    }

                    if (reportParams != null)
                    {
                        List<ReportParameter> reportParameters = new();
                        foreach (KeyValuePair<string, string> item in reportParams)
                        {
                            reportParameters.Add(new ReportParameter(item.Key, item.Value));
                        }
                        report.SetParameters(reportParameters);
                    }

                    byte[] pdf = report.Render("EXCELOPENXML");
                    return File(pdf, mimeType, $"{fileName}{extension}");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        [NonAction]
        public IActionResult GetExcelReport(IEnumerable dataSource, Dictionary<string, string> reportParams, string reportName, string fileName, string controllerName, string areaName)
        {
            fileName = $"{fileName}_{DateTime.Now.ToFormatedDateTimeWithAmPmString("_", true)}";
            string filePath = Path.Combine("wwwroot", "reprots", "lab.RDLCReportSample.Rdlc", $"{reportName}.rdl");
            //Path.Combine("Areas", areaName, "Views", controllerName, $"{reportName}.rdl");
            string extension = ".xlsx";
            string mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            filePath = Path.Combine(WebHostEnvironment.ContentRootPath, filePath);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using var reportDefinition = new FileStream(filePath, FileMode.Open);

                    using var report = new LocalReport();
                    report.LoadReportDefinition(reportDefinition);
                    var dsName = report.GetDataSourceNames();
                    report.DataSources.Add(new ReportDataSource(dsName[0], dataSource));

                    if (reportParams != null)
                    {
                        List<ReportParameter> reportParameters = new();
                        foreach (KeyValuePair<string, string> item in reportParams)
                        {
                            reportParameters.Add(new ReportParameter(item.Key, item.Value));
                        }
                        report.SetParameters(reportParameters);
                    }

                    byte[] pdf = report.Render("EXCELOPENXML");
                    return File(pdf, mimeType, $"{fileName}{extension}");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        [NonAction]
        public IActionResult GetPdfReport(Dictionary<string, List<object>> dataSource, Dictionary<string, string> reportParams, string fileName, string controllerName, string areaName)
        {
            return GetPdfReport(dataSource, reportParams, fileName, fileName, controllerName, areaName);
        }
        
        [NonAction]
        public IActionResult GetPdfReport(Dictionary<string, List<object>> dataSource, Dictionary<string, string> reportParams, string reportName, string fileName, string controllerName, string areaName)
        {
            fileName = $"{fileName}_{DateTime.Now.ToFormatedDateTimeWithAmPmString("_", true)}";
            string filePath = Path.Combine("wwwroot", "reprots", "lab.RDLCReportSample.Rdlc", $"{reportName}.rdl");
            //Path.Combine("Areas", areaName, "Views", controllerName, $"{reportName}.rdl");
            string extension = ".pdf";
            string mimeType = "application/pdf";
            filePath = Path.Combine(WebHostEnvironment.ContentRootPath, filePath);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using var reportDefinition = new FileStream(filePath, FileMode.Open);

                    using var report = new LocalReport();
                    report.LoadReportDefinition(reportDefinition);
                    var dsName = report.GetDataSourceNames();

                    if (dataSource != null)
                    {
                        foreach (KeyValuePair<string, List<object>> item in dataSource)
                        {
                            report.DataSources.Add(new ReportDataSource(item.Key, item.Value));
                        }
                    }

                    if (reportParams != null)
                    {
                        List<ReportParameter> reportParameters = new();
                        foreach (KeyValuePair<string, string> item in reportParams)
                        {
                            reportParameters.Add(new ReportParameter(item.Key, item.Value));
                        }
                        report.SetParameters(reportParameters);
                    }

                    byte[] pdf = report.Render("PDF");
                    return File(pdf, mimeType, $"{fileName}{extension}");
                }
            }
            catch (Exception e)
            {
                throw new(e.Message);
            }

            return View();
        }

        [NonAction]
        public IActionResult GetPdfReport(IEnumerable dataSource, Dictionary<string, string> reportParams, string reportName, string fileName, string controllerName, string areaName)
        {
            fileName = $"{fileName}_{DateTime.Now.ToFormatedDateTimeWithAmPmString("_", true)}";
            string filePath = Path.Combine("wwwroot", "reprots", "lab.RDLCReportSample.Rdlc", $"{reportName}.rdl");
            //Path.Combine("Areas", areaName, "Views", controllerName, $"{reportName}.rdl");
            string extension = ".pdf";
            string mimeType = "application/pdf";
            filePath = Path.Combine(WebHostEnvironment.ContentRootPath, filePath);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using var reportDefinition = new FileStream(filePath, FileMode.Open);

                    using var report = new LocalReport();
                    report.LoadReportDefinition(reportDefinition);
                    var dsName = report.GetDataSourceNames();
                    report.DataSources.Add(new ReportDataSource(dsName[0], dataSource));

                    if (reportParams != null)
                    {
                        List<ReportParameter> reportParameters = new();
                        foreach (KeyValuePair<string, string> item in reportParams)
                        {
                            reportParameters.Add(new ReportParameter(item.Key, item.Value));
                        }
                        report.SetParameters(reportParameters);
                    }

                    byte[] pdf = report.Render("PDF");
                    return File(pdf, mimeType, $"{fileName}{extension}");
                }
            }
            catch (Exception e)
            {
                throw new(e.Message);
            }

            return View();
        }
        #endregion
        //End Action

        #endregion

        [NonAction]
        public IActionResult GetReport(IEnumerable dataSource, string fileType, string fileName, string controllerName, string areaName)
        {
            if (fileType == AppEnums.ExportType.Pdf.ToDisplayAttr().Name)
            {
                return GetPdfReport(dataSource, fileName, fileName, controllerName, areaName);
            }
            else if (fileType == AppEnums.ExportType.Excel.ToDisplayAttr().Name)
            {
                return GetExcelReport(dataSource, fileName, fileName, controllerName, areaName);
            }
            else
            {
                return null;
            }
        }
        
        [NonAction]
        public IActionResult GetExcelReport(IEnumerable dataSource, string fileName, string controllerName, string areaName)
        {
            return GetExcelReport(dataSource, fileName, fileName, controllerName, areaName);
        }

        [NonAction]
        public IActionResult GetExcelReport(IEnumerable dataSource, string reportName, string fileName, string controllerName, string areaName)
        {
            fileName = $"{fileName}_{DateTime.Now.ToFormatedDateTimeWithAmPmString("_", true)}";
            string filePath = Path.Combine("wwwroot", "reprots", "lab.RDLCReportSample.Rdlc", $"{reportName}.rdl");
            //Path.Combine("Areas", areaName, "Views", controllerName, $"{reportName}.rdl");
            string extension = ".xlsx";
            string mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            filePath = Path.Combine(WebHostEnvironment.ContentRootPath, filePath);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using var reportDefinition = new FileStream(filePath, FileMode.Open);

                    using var report = new LocalReport();
                    report.LoadReportDefinition(reportDefinition);
                    var dsName = report.GetDataSourceNames();
                    report.DataSources.Add(new ReportDataSource(dsName[0], dataSource));
                    byte[] pdf = report.Render("EXCELOPENXML");
                    return File(pdf, mimeType, $"{fileName}{extension}");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        [NonAction]
        public IActionResult GetPdfReport(IEnumerable dataSource, string fileName, string controllerName, string areaName)
        {
            return GetPdfReport(dataSource, fileName, fileName, controllerName, areaName);
        }
        
        [NonAction]
        public IActionResult GetPdfReport(IEnumerable dataSource, string reportName, string fileName, string controllerName, string areaName)
        {
            fileName = $"{fileName}_{DateTime.Now.ToFormatedDateTimeWithAmPmString("_", true)}";
            string filePath = Path.Combine("wwwroot", "reprots", "lab.RDLCReportSample.Rdlc", $"{reportName}.rdl");
            //Path.Combine("Areas", areaName, "Views", controllerName, $"{reportName}.rdl");
            string extension = ".pdf";
            string mimeType = "application/pdf";
            filePath = Path.Combine(WebHostEnvironment.ContentRootPath, filePath);
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using var reportDefinition = new FileStream(filePath, FileMode.Open);

                    using var report = new LocalReport();
                    report.LoadReportDefinition(reportDefinition);
                    var dsName = report.GetDataSourceNames();
                    report.DataSources.Add(new ReportDataSource(dsName[0], dataSource));
                    byte[] pdf = report.Render("PDF");
                    return File(pdf, mimeType, $"{fileName}{extension}");
                }
            }
            catch (Exception e)
            {
                throw new(e.Message);
            }

            return View();
        }

    }
}
