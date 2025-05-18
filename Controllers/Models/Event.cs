using System.ComponentModel.DataAnnotations;
using EventsReg.Models;

namespace EventsReg.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Data musi być w przyszłości")]
        public DateTime Date { get; set; }

        public string? Description { get; set; }
    }

}