using Microsoft.AspNetCore.Mvc;

namespace JapaneseCarpartsStore.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult Error404() => View();

        [Route("Error/500")]
        public IActionResult Error500() => View();
    }
}