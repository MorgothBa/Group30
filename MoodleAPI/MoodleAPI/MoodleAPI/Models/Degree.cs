namespace MoodleAPI.Models
{
    public class Degree
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<ApprovedDegree> ApprovedDegrees { get; set; } = new List<ApprovedDegree>();
    }
}
