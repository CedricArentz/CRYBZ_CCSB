using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRYBZ_CCSB.Utility
{
    public static class Helper
    {
        public static readonly string Admin = "Beheerder";
        public static readonly string Medewerker = "Medewerker";
        public static readonly string Klant = "Klant";

        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem{ Value=Helper.Admin , Text = Helper.Admin},
                new SelectListItem{ Value=Helper.Medewerker , Text = Helper.Medewerker},
                new SelectListItem{ Value=Helper.Klant , Text = Helper.Klant},
            };
            return items.OrderBy(s => s.Text).ToList();
        }
    }
}
