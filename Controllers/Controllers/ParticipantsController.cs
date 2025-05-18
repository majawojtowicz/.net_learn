using EventsReg.Data;
using EventsReg.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsReg.Controllers
{
    public class ParticipantsController : Controller
    {
        public IActionResult Create(int eventId)
        {
            ViewBag.EventId = eventId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Participant participant)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EventId = participant.EventId;
                return View(participant);
            }

            participant.Id = InMemoryDatabase.Participants.Count + 1;
            InMemoryDatabase.Participants.Add(participant);
            return RedirectToAction("ListByEvent", new { eventId = participant.EventId });
        }

        public IActionResult ListByEvent(int eventId)
        {
            var participants = InMemoryDatabase.Participants
                .Where(p => p.EventId == eventId)
                .ToList();

            ViewBag.Event = InMemoryDatabase.Events.FirstOrDefault(e => e.Id == eventId);
            return View(participants);
        }

    }
}
