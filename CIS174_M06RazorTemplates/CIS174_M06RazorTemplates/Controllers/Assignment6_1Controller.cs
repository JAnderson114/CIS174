using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CIS174_M06RazorTemplates.Models;

namespace CIS174_M06RazorTemplates.Controllers
{
    public class Assignment6_1Controller : Controller
    {
        [Route("Assignment6_1/{accessLevel:int}")]
        public IActionResult Index(int accessLevel)
        {
            if(accessLevel < 1 || accessLevel > 10)
            {
                return BadRequest();
            }

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Grade = 92
                },
                new Student
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Grade = 85
                },
                new Student
                {
                    FirstName = "Michael",
                    LastName = "Johnson",
                    Grade = 78
                },
                new Student
                {
                    FirstName = "Emily",
                    LastName = "Davis",
                    Grade = 95
                }
            };

            var model = new StudentViewModel
            {
                Students = students,
                AccessLevel = accessLevel
            };

            return View(model);
        }
    }
}
