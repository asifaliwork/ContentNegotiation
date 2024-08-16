using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContentNegotiation.Helper;

public static class Helper
{
    public static string Format = "text/html";
    public static string Format1 = "text/plain";
    public static string Format2 = "application/json";
    public static string Format3 = "application/xml";
    public static List<SelectListItem> GetFormatForDropDown()
    {
        return new List<SelectListItem>
        {
            new SelectListItem{Value = Helper.Format , Text=Helper.Format },
            new SelectListItem{Value = Helper.Format1 , Text=Helper.Format1 },
            new SelectListItem{Value = Helper.Format2 , Text=Helper.Format2 },
            new SelectListItem{Value = Helper.Format3 , Text=Helper.Format3 },
        };
    }
}
