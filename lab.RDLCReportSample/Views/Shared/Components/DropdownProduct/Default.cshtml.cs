using lab.RDLCReportSample.Managers;
using lab.RDLCReportSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab.RDLCReportSample.Components
{
    public class DropdownProductViewComponent : ViewComponent
    {
        private IDataManager _iDataManager { get; set; }

        public DropdownProductViewComponent(IDataManager iDataManager)
        {
            _iDataManager = iDataManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(object param)
        {
            if (param is not null)
            {
                var productDropdownViewModel = new ProductDropdownViewModel();
                var productDropdownList = await _iDataManager.GetProductDropdownAsync();

                var ddlViewModel = (DropdownViewModel)param;

                productDropdownViewModel.KeyId = ddlViewModel.KeyId;
                productDropdownViewModel.KeyName = ddlViewModel.KeyName;

                productDropdownViewModel.IsReadOnly = ddlViewModel.IsReadOnly;
                productDropdownViewModel.IsRequired = ddlViewModel.IsRequired;
                

                if (ddlViewModel.SelectedValue != null) {
                    productDropdownViewModel.ProductId = ddlViewModel.SelectedValue;
                }
                else {
                    productDropdownViewModel.ProductId = 0;
                }

                if (!string.IsNullOrEmpty(ddlViewModel.SelectedText))
                {
                    productDropdownViewModel.ProductName = ddlViewModel.SelectedText;
                }

                productDropdownViewModel.SelectList = productDropdownList;

                return View(productDropdownViewModel);
            }
            else
            {
                return View(null);
            }
        }
    }
}
