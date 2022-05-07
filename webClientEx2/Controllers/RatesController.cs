using Microsoft.AspNetCore.Mvc;
using webClientEx2.Models;
using webClientEx2.Services;
namespace webClientEx2.Controllers
{
    public class RatesController : Controller
    {
        private IRateService service;
        public RatesController()
        {
            service = new RateService();
           
        }

        public IActionResult RList()
        {
            return View(service.GetAll());
        }
        public IActionResult Details(int id)
        {
            return View(service.Get(id));
        }
        public IActionResult CreateRate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string text, string name, int number)
        {

            service.Create(text, name, number);
            return RedirectToAction("RList");
        }
        public IActionResult Edit(int id)
        {
            return View(service.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(int id, string text, string name, int number)
        {
           service.Edit(id, text, name, number);
            return RedirectToAction("RList");
        }
        public IActionResult Delete(int id)
        {
            return View(service.Get(id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteForReal(int id)
        {
            service.Delete(id);
            return RedirectToAction("RList");
        }
    }
   
}
