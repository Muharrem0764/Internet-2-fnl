using vize.Models;

namespace vize.Dtos
{
    public class ExamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Time { get; set; }
        public bool IsActive { get; set; }

        public int LessonId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
