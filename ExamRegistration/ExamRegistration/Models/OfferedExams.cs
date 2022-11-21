namespace StudentSystem.Models
{
    public class OfferedExams
    {
        public int id { get; set; }
        //FK:Course table
        public int course_id { get; set; }
        public string session { get; set; }
        public string slot { get; set; }
        public string language { get; set; }
        public string centre { get; set; }
        public DateTime examDate { get; set; }

    }
}
