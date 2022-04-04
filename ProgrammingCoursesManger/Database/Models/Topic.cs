using System.ComponentModel.DataAnnotations;

namespace ProgrammingCoursesManger.Database.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        public int Number { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}