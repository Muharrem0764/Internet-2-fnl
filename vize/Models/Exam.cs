namespace vize.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int Time { get; set; }
        public bool IsActive { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
