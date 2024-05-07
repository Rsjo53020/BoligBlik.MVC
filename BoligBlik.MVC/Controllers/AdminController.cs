using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Claims()
        {
            return View();
        }
        public IActionResult Management()
        {
            return View();
        }

        public IActionResult CreateMember()
        {
            
           return View();
        }
        public string CreatedABoardMember()
        {
            string personensNavn = "Ny Bestyrelsesmedlem";
            string rolle = "Bestyrelsesmedlemmets rolle";
            string path = "PO.jpg";

            // Lav HTML-koden for det nye bestyrelsesmedlem
            string nytBestyrelsesmedlemHTML = $@"
            <div class=""rounded team-item"" align=""center"">
                <div class=""team-content"">
                    <div class=""team-img-icon"">
                        <div class=""team-img rounded-circle"">
                            <img src=""/img/{path}"" class=""img-fluid w-50 rounded-circle"" alt=""Billede af den nye Bestyrelsesmedlem"">
                        </div>
                        <div class=""team-name text-center py-3"">
                            <h4 class="""">{personensNavn}</h4>
                            <p class=""m-0"">{rolle}</p>
                        </div>
                    </div>
                </div>
            </div>";

            return nytBestyrelsesmedlemHTML;

        }
    }
}
