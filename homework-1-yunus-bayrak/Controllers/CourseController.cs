using homework_1_yunus_bayrak.Domain.Entities;
using homework_1_yunus_bayrak.Infrastructure.Contexts;
using homework_1_yunus_bayrak.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_1_yunus_bayrak.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class CourseController : ControllerBase
    {
        private readonly LearningContext _context;

        private readonly ILogger<CourseController> _logger;

        public CourseController(LearningContext context, ILogger<CourseController> logger)
        {
            _logger = logger;
            _context = context;
            //TODO: seed not working ??
            if (!_context.Courses.Any())
            {
                _context.Courses.AddRange(new Course { Id = 1, Name = "C# deneme", CourseType = Domain.Enums.CourseType.DESKTOP, CreatedAt = DateTime.Now.AddDays(new Random().Next(-100, 100)), CreatedBy = "Me", Description = "Desc", Status = true },
                         new Course { Id = 2, Name = "C# deneme2", CourseType = Domain.Enums.CourseType.DESKTOP, CreatedAt = DateTime.Now.AddDays(new Random().Next(-100, 100)), CreatedBy = "Me", Description = "Desc", Status = true },
                         new Course { Id = 3, Name = "English", CourseType = Domain.Enums.CourseType.LANGUAGE, CreatedAt = DateTime.Now.AddDays(new Random().Next(-100, 100)), CreatedBy = "Me", Description = "Desc", Status = true },
                         new Course { Id = 4, Name = "Web Service", CourseType = Domain.Enums.CourseType.SERVICE, CreatedAt = DateTime.Now.AddDays(new Random().Next(-100, 100)), CreatedBy = "Me", Description = "Desc", Status = true },
                         new Course { Id = 5, Name = "How Machines Talk", CourseType = Domain.Enums.CourseType.AI, CreatedAt = DateTime.Now.AddDays(new Random().Next(-100, 100)), CreatedBy = "Me", Description = "Desc", Status = true });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _context.Courses.ToList(); ;
        }
        [HttpGet("{ColumnName}/{FilterValue}")]
        public IEnumerable<Course> Get(string ColumnName, string FilterValue)
        {
            var queryable = _context.Courses.AsNoTracking();

            queryable = queryable.FilterDynamic(ColumnName, new[] { FilterValue });
            return queryable.ToList();
        }

        [HttpPost]
        public Course Post([FromBody] Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }
        [HttpPut]
        public Course Put([FromBody] Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return course;
        }
        [HttpPatch("{Id}/{Name}")]
        public Course Patch(int id, string name)
        {
            var course = _context.Courses.Find(id);
            course.Name = name;
            _context.SaveChanges();
            return course;
        }
        [HttpDelete("{id}")]
        public Course Delete(int id)
        {
            var course = _context.Courses.Find(id);
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return course;
        }
    }
}
