using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models.ResponseModels
{
    public class Response
    {
        public string session { get; set; }
        public string course { get; set; }
        public string language { get; set; }
        public string centre { get; set; }
        public DateTime examDate { get; set; }
        public string? mesaage { get; set; }
    }
}
