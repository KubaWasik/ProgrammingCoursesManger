namespace ProgrammingCoursesManger.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<TopicViewModel> Topics { get; set; }
    }
}