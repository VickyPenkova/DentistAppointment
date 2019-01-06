using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentistAppointment.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult index()
        {
            return View();
        }
        // TODO: This controller remains as for special cases.
    }
}
