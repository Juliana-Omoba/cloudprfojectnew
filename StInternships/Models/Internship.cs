namespace StInternships.Models
{
    public class Internship
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int HoursLogged { get; set; } = new();
        //public string SupervisorFeedback { get; set; } = new();
        public string SupervisorFeedback { get; set; } = "";

    }
}
