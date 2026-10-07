using System.Collections.Generic;

namespace CIS174_M06RazorTemplates.Models
{
    public class StudentViewModel
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public int AccessLevel { get; set; }
    }
}
