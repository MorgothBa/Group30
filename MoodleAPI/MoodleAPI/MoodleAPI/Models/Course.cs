using Microsoft.Extensions.Logging;

namespace MoodleAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }

        // Navigation properties
        public ICollection<MyCourse> MyCourses { get; set; } = new List<MyCourse>();
        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<ApprovedDegree> ApprovedDegrees { get; set; } = new List<ApprovedDegree>();
    }
}
