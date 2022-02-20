using BekoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BekoMVC.Controllers
{
    public class ProductController : Controller
    {
        FinalProjectContext db = new FinalProjectContext();
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}
