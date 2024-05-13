namespace MoodleAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int DegreeId { get; set; }

        // Navigation properties
        public Degree Degree { get; set; }
        public ICollection<MyCourse> MyCourses { get; set; } = new List<MyCourse>();
    }
}
