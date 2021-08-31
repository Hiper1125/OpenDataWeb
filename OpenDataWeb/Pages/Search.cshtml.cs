using OpenDataWeb.DAL;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenDataWeb.Pages
{
    public class SearchModel : PageModel
    {
        public List<Fermata> Fermate;

        public void OnGet()
        {
            string method = Request.Query["method"];
            string parameter = Request.Query["parameter"];

            SearchBy option = SearchBy.Default;

            switch (method)
            {
                case "Default": option = SearchBy.Default; break;
                case "Nome": option = SearchBy.Nome; break;
                case "Regione": option = SearchBy.Regione; break;
                case "Provincia": option = SearchBy.Provincia; break;
                case "Lettera": option = SearchBy.Lettera; break;
                default: option = SearchBy.Default; break;
            }

            this.Fermate = DBManager.OttieniFermate(option, parameter);
        }
    }
}