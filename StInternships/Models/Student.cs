using System.ComponentModel.DataAnnotations;

namespace StInternships.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string DegreeProgram { get; set; }

        public int YearOfStudy { get; set; }
        public List<Internship> Internships { get; set; } = new();
    }
}
