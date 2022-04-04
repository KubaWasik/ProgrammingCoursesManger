using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProgrammingCoursesManger.Database;
using ProgrammingCoursesManger.Database.Models;
using ProgrammingCoursesManger.ViewModels;

namespace ProgrammingCoursesManger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetCourses()
        {
            return await _context
                .Courses
                .Include(c => c.Topics)
                .Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Topics = c.Topics.Select(c => new TopicViewModel { Id = c.Id, Name = c.Name, Number = c.Number }).ToList()
                })
                .ToListAsync();
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<CourseViewModel>> GetCourse(int courseId)
        {
            var course = await _context
                .Courses
                .Include(c => c.Topics)
                .Where(c => c.Id == courseId)
                .Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Topics = c.Topics
                        .Select(c => new TopicViewModel { Id = c.Id, Name = c.Name, Number = c.Number })
                        .OrderBy(c => c.Number)
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(CourseViewModel course)
        {
            try
            {
                var dbCourse = _context
                    .Courses
                    .Include(c => c.Topics)
                    .FirstOrDefault(c => c.Id == course.Id);

                if (dbCourse == null)
                {
                    return NotFound();
                }

                dbCourse.Name = course.Name;
                dbCourse.Description = course.Description;

                var ids = course.Topics.Select(t => t.Id).ToList();
                var dbIds = dbCourse.Topics.Select(t => t.Id).ToList();

                var toDelete = dbCourse.Topics.Where(t => !ids.Contains(t.Id)).ToList();
                var toAdd = course.Topics.Where(t => !dbIds.Contains(t.Id)).ToList();

                _context.Topics.RemoveRange(toDelete);

                _context.Topics.AddRange(toAdd.ConvertAll(c => new Topic { Name = c.Name, Number = c.Number, CourseId = course.Id }));

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!CourseExists(course.Id))
            {
                return NotFound();
            }

            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CourseViewModel course)
        {
            var newCourse = new Course
            {
                Id = course.Id,
                Description = course.Description,
                Name = course.Name
            };

            _context.Courses.Add(newCourse);

            await _context.SaveChangesAsync();

            if (course.Topics.Any())
            {
                List<Topic> topics = course.Topics.Select(t => new Topic { Name = t.Name, Number = t.Number, CourseId = newCourse.Id }).ToList();

                _context.Topics.AddRange(topics);

                await _context.SaveChangesAsync();
            }

            return Ok(true);
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);

            if (course == null)
            {
                return NotFound();
            }

            var topics = await _context.Topics.Where(t => t.CourseId == course.Id).ToListAsync();

            _context.Topics.RemoveRange(topics);
            _context.Courses.Remove(course);

            await _context.SaveChangesAsync();

            return Ok(true);
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}