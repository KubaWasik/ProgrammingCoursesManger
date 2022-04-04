using System.ComponentModel.DataAnnotations;

namespace ProgrammingCoursesManger.Database.Models
{
    public class Course
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}