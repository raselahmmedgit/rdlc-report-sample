using lab.RDLCReportSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab.RDLCReportSample.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                int[] categoryIdList = { 1 };
                string[] categoryNameList = { "Fruit" };

                int[] productIdList = { 1, 2, 3 };
                string[] productNameList = { "Apple", "Mango", "Orange" };

                var homeViewModel = new HomeViewModel()
                {
                    CategoryIdList = categoryIdList,
                    CategoryNameList = categoryNameList,
                    ProductIdList = productIdList,
                    ProductNameList = productNameList,
                };

                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "HomeController - Task<IActionResult> Index()");
                return ErrorView(ex);
            }
        }

        public IActionResult SlimSelect()
        {
            try
            {
                int[] categoryIdList = { 1 };
                string[] categoryNameList = { "Fruit" };

                int[] productIdList = { 1, 2, 3 };
                string[] productNameList = { "Apple", "Mango", "Orange" };

                var homeViewModel = new HomeViewModel()
                {
                    CategoryIdList = categoryIdList,
                    CategoryNameList = categoryNameList,
                    ProductIdList = productIdList,
                    ProductNameList = productNameList,
                };

                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "HomeController - Task<IActionResult> SlimSelect()");
                return ErrorView(ex);
            }
        }

        public IActionResult DynamicReport()
        {
            try
            {
                var dynamicReportViewModelList = new List<DynamicReportViewModel>() {
                    new DynamicReportViewModel()
                    {
                        HeaderName = "Header 1",
                        DataValue = "Header 1 Val"
                    },
                    new DynamicReportViewModel()
                    {
                        HeaderName = "Header 2",
                        DataValue = "Header 1 Val"
                    },
                    new DynamicReportViewModel()
                    {
                        HeaderName = "Header 3",
                        DataValue = "Header 3 Val"
                    },
                    new DynamicReportViewModel()
                    {
                        HeaderName = "Header 1",
                        DataValue = "Header 4 Val"
                    },
                    new DynamicReportViewModel()
                    {
                        HeaderName = "Header 2",
                        DataValue = "Header 5 Val"
                    }
                    ,new DynamicReportViewModel()
                    {
                        HeaderName = "Header 3",
                        DataValue = "Header 6 Val"
                    }
                };


                return View(dynamicReportViewModelList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "HomeController - Task<IActionResult> DynamicReport()");
                return ErrorView(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
