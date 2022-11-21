using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models.RequestModels
{
    public class Request
    {
        [Required]
        public int studentID { get; set; }
        [Required]
        public string session { get; set; }
        [Required]
        public string course { get; set; }
        [Required]
        public string language { get; set; }
        [Required]
        public string centre { get; set; }

    }
}
