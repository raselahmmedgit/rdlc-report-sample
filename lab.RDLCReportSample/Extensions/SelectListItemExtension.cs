using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab.RDLCReportSample.Extensions
{
    public static class SelectListItemExtension
    {

        public static List<SelectListItem> PopulateDropdownList<T>(this List<T> objectList, string valueField, string textField, bool isEdit = false, string selectedValue = "", string selectText = "- Select One -")
        {
            try
            {
                if (string.IsNullOrEmpty(selectedValue))
                {
                    selectedValue = "";

                }
                var selectedList = new SelectList(objectList, valueField, textField);
                List<SelectListItem> items;
                IEnumerable<SelectListItem> listOfItems;
                if (isEdit)
                {
                    listOfItems = from obj in selectedList select new SelectListItem { Selected = (obj.Value == selectedValue), Text = obj.Text, Value = obj.Value };
                    items = listOfItems.ToList();
                    items.Add(selectedValue == ""
                                  ? new SelectListItem { Text = selectText, Value = "", Selected = true }
                                  : new SelectListItem { Text = selectText, Value = "", Selected = false });
                }
                else
                {
                    listOfItems = from obj in selectedList select new SelectListItem { Selected = false, Text = obj.Text, Value = obj.Value };

                    items = listOfItems.ToList();
                    items.Add(new SelectListItem { Text = selectText, Value = selectedValue, Selected = true });

                }

                return items.OrderBy(s => s.Value).ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public static List<SelectListItem> PopulateDropdownUnorderedList<T>(this List<T> objectList, string valueField, string textField, bool isEdit = false, string selectedValue = "", string selectText = "-- Select One --")
        {
            try
            {
                if (string.IsNullOrEmpty(selectedValue))
                {
                    selectedValue = "";

                }
                var selectedList = new SelectList(objectList, valueField, textField);
                List<SelectListItem> items;
                IEnumerable<SelectListItem> listOfItems;
                if (isEdit)
                {
                    listOfItems = from obj in selectedList select new SelectListItem { Selected = (obj.Value == selectedValue), Text = obj.Text, Value = obj.Value };
                    items = listOfItems.ToList();
                    items.Insert(0, selectedValue == ""
                                  ? new SelectListItem { Text = selectText, Value = "", Selected = true }
                                  : new SelectListItem { Text = selectText, Value = "", Selected = false });
                }
                else
                {
                    listOfItems = from obj in selectedList select new SelectListItem { Selected = false, Text = obj.Text, Value = obj.Value };

                    items = listOfItems.ToList();
                    items.Insert(0, new SelectListItem { Text = selectText, Value = selectedValue, Selected = true });

                }

                return items.ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public static List<SelectListItem> PopulateMultiDropdownList<T>(this List<T> objectList, string valueField, string textField, bool isEdit = false, int[]? selectedValueList = null)
        {
            try
            {
                if (selectedValueList == null)
                {
                    selectedValueList = null;
                }

                var selectedList = new SelectList(objectList, valueField, textField);
                List<SelectListItem> items;
                IEnumerable<SelectListItem> listOfItems;
                if (isEdit)
                {
                    listOfItems = from obj in selectedList select new SelectListItem { Selected = (selectedValueList?.Contains(Convert.ToInt32(obj.Value)) == true ? true : false), Text = obj.Text, Value = obj.Value };

                    items = listOfItems.ToList();
                }
                else
                {
                    listOfItems = from obj in selectedList select new SelectListItem { Selected = (selectedValueList?.Contains(Convert.ToInt32(obj.Value)) == true ? true : false), Text = obj.Text, Value = obj.Value };

                    items = listOfItems.ToList();

                }

                return items.OrderBy(s => s.Value).ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public static List<SelectListItem> PopulateMultiGroupDropdownList<T>(this List<T> objectList, string valueField, string textField, bool isEdit = false, int[]? selectedValueList = null)
        {
            try
            {
                if (selectedValueList == null)
                {
                    selectedValueList = null;
                }

                var selectedList = new SelectList(objectList, valueField, textField);
                List<SelectListItem> items;
                IEnumerable<SelectListItem> listOfItems;
                if (isEdit)
                {
                    listOfItems = from obj in selectedList select new SelectListItem { Selected = (selectedValueList?.Contains(Convert.ToInt32(obj.Value)) == true ? true : false), Text = obj.Text, Value = obj.Value };

                    items = listOfItems.ToList();
                }
                else
                {
                    listOfItems = from obj in selectedList select new SelectListItem { Selected = (selectedValueList?.Contains(Convert.ToInt32(obj.Value)) == true ? true : false), Text = obj.Text, Value = obj.Value };

                    items = listOfItems.ToList();

                }

                return items.OrderBy(s => s.Value).ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }


    }
}
