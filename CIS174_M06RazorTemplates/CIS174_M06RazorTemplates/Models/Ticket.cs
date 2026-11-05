using System.ComponentModel.DataAnnotations;

namespace CIS174_M06RazorTemplates.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a ticket name.")]
        [StringLength(50, ErrorMessage = "Ticket name must be 50 characters or less.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(250, ErrorMessage = "Description must be 250 characters or less.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a sprint number.")]
        [Range(1, 100, ErrorMessage = "Sprint number must be between 1 and 100.")]
        public int SprintNumber { get; set; } = 1;

        [Required(ErrorMessage = "Please enter a point value.")]
        [Range(1, 100, ErrorMessage = "Points must be between 1 and 100.")]
        public int PointValue { get; set; } = 1;

        [Required(ErrorMessage = "Please select a status.")]
        public string Status { get; set; } = "To Do";
    }
}