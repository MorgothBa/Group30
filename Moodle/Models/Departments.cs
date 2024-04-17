using System.ComponentModel.DataAnnotations;

namespace Moodle.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Course_id { get; set; }

        public Departments() {}
    }
}
