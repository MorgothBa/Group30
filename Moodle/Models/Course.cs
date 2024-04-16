namespace Moodle.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }

        // Navigation properties
        public ICollection<Event> Events { get; set; }
        public ICollection<MyCourse> MyCourses { get; set; }
        public ICollection<ApprovedDegree> ApprovedDegrees { get; set; }

        public Course()
        {
                
        }
    }
}
