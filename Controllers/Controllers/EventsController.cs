
using EventsReg.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventsReg.Models
{
    public class EventsController : Controller
    {
        

        public IActionResult Index()
        {
            return View(InMemoryDatabase.Events);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event ev)
        {
            if (!ModelState.IsValid)
                return View(ev);

            ev.Id = InMemoryDatabase.Events.Count + 1;
            InMemoryDatabase.Events.Add(ev);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var ev = InMemoryDatabase.Events.FirstOrDefault(x => x.Id == id);
            if (ev == null) return NotFound();
            return View(ev);
        }
    }
}
