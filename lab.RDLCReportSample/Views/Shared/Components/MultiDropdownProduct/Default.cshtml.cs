using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab.RDLCReportSample.Managers;
using lab.RDLCReportSample.Models;

namespace lab.RDLCReportSample.Components
{
    public class MultiDropdownProductViewComponent : ViewComponent
    {
        private IDataManager _iDataManager { get; set; }

        public MultiDropdownProductViewComponent(IDataManager iDataManager)
        {
            _iDataManager = iDataManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(object param)
        {
            if (param is not null)
            {
                var productMultiDropdownViewModel = new ProductMultiDropdownViewModel();
                var productDropdownList = new List<SelectListItem>();

                var ddlViewModel = (DropdownViewModel)param;

                productMultiDropdownViewModel.KeyId = ddlViewModel.KeyId;
                productMultiDropdownViewModel.KeyName = ddlViewModel.KeyName;

                productMultiDropdownViewModel.IsReadOnly = ddlViewModel.IsReadOnly;
                productMultiDropdownViewModel.IsRequired = ddlViewModel.IsRequired;
                productMultiDropdownViewModel.IsMultiple = ddlViewModel.IsMultiple;

                if (ddlViewModel.SelectedValueList != null)
                {
                    productDropdownList = await _iDataManager.GetProductMultiDropdownAsync(true, ddlViewModel.SelectedValueList);
                    productMultiDropdownViewModel.ProductIdList = ddlViewModel.SelectedValueList;
                }
                else
                {
                    productDropdownList = await _iDataManager.GetProductMultiDropdownAsync();
                    productMultiDropdownViewModel.ProductIdList = null;
                }

                productMultiDropdownViewModel.SelectList = productDropdownList;

                return View(productMultiDropdownViewModel);
            }
            else
            {
                return View(null);
            }
        }
    }
}
