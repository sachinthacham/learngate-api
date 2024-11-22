namespace learngate_api.DTOs.ClassDto
{
    public class UpdateClassDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int SupervisorId { get; set; }
        public int GradeId { get; set; }
    }
}
