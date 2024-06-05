using Microsoft.AspNetCore.Http.HttpResults;

namespace vize.Models

{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Exam> Exams { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
