using Microsoft.AspNetCore.Mvc;

namespace WebBookStore.Controllers
{
    public class HomeController : ControllerBase
    {
        public string Index()
        {
            return "WebGentle";
        }
    }
}