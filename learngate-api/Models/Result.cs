namespace learngate_api.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int ExamId { get; set; }
      
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public int ClassId { get; set; }
        public Exam Exam { get; set; }
       
        public Student Student { get; set; }
        public Class Class { get; set; }
        public Subject Subject { get; set; }




    }
}
