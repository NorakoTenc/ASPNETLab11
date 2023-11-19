using System.ComponentModel.DataAnnotations;

namespace ASPNETLab10.Models
{
    public class ConsultationModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Product { get; set; }
    }
}
