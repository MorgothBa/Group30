using Moodle.Models;

namespace Moodle.WebSocketManager
{
    public class Event
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property
        public Course Course { get; set; }

        public Event()
        {

        }
    }
}
