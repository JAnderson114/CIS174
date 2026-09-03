using System.ComponentModel.DataAnnotations;

namespace FirstResponsiveWebAppLastName.Models
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int BirthYear { get; set; }

        public int AgeThisYear()
        {
            return AppConstants.CurrentYear - BirthYear;
        }
    }
}