using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webUniversity.Controllers
{
    public class StudentRedactorController : Controller
    {
        // GET: StudentRedactorController
        public ActionResult Index()
        {
            return View();
        }
    }
}
