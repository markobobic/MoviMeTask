using Dynamitey;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace MovieMe.ExtensionMethods
{
    public static class DropdownExtensionMethods
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DropdownExtensionMethods));

        public static async Task<IEnumerable<SelectListItem>> ToDropdown<T>(this DbSet<T> dbSet, [Optional] int? id) where T : class
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            try
            {
                dynamic[] dataForDropdown = await dbSet.SelectDynamic("x=> new {Id = x.Id.ToString(),Name = x.Name}")
               .ToArrayAsync();
                await Task.Run(() =>
                {
                    for (int i = 0; i < dataForDropdown.Length; i++)
                    {
                        selectListItems.Add(new SelectListItem
                        {
                            Value = Dynamic.InvokeGet(dataForDropdown[i], "Id"),
                            Text = Dynamic.InvokeGet(dataForDropdown[i], "Name"),
                            Selected = Dynamic.InvokeGet(dataForDropdown[i], "Id") == id.ToString() && id != null ? true : false
                        }
                        );
                    }
                });
                return selectListItems.OrderBy(x => x.Text);
            }
            catch (Exception e)
            {
                Log.Error("Error inside ToDropdown extension method", e);
                throw;
            }

        }

        public static SelectListItem CreateNoneForDropdown() => new SelectListItem() { Value = "None", Text = "None", Selected = true };

    }
}