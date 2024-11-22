namespace learngate_api.DTOs.ClassDto
{
    public class CreateClassDto
    {
     
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int SupervisorId { get; set; }
        public int GradeId { get; set; }
    }
}
