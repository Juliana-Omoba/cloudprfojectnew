namespace StInternships.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Location { get; set; }
        public string ContactEmail { get; set; }
        public List<Internship> Internships { get; set; } = new();

    }
}
