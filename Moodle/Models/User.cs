namespace Moodle.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int DegreeId { get; set; }

        // Navigation property
        public Degree Degree { get; set; }
        public User()
        {
                
        }
    }
}
