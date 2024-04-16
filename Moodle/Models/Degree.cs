namespace Moodle.Models
{
    public class Degree
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<User> Users { get; set; }
        public ICollection<ApprovedDegree> ApprovedDegrees { get; set; }

        public Degree()
        {
                
        }
    }
}
