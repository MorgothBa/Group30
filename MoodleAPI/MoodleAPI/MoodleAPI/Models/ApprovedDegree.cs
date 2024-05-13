namespace MoodleAPI.Models
{
    public class ApprovedDegree
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int DegreeId { get; set; }

        // Navigation properties
        public Course Course { get; set; }
        public Degree Degree { get; set; }
    }
}
