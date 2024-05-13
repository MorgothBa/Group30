namespace MoodleAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public Course Course { get; set; }

    }
}
