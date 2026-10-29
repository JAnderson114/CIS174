using System.ComponentModel.DataAnnotations;

namespace CIS174_M06RazorTemplates.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a ticket name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Sprint must be between 1 and 100.")]
        public int SprintNumber { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "Points must be between 1 and 100.")]
        public int PointValue { get; set; } = 1;

        [Required(ErrorMessage = "Please select a status.")]
        public string Status { get; set; } = "To Do";
    }
}