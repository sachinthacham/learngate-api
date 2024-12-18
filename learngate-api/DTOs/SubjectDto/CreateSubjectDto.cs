namespace learngate_api.DTOs.SubjectDto
{
    public class CreateSubjectDto
    {
        public string Name { get; set; }
        public List<int> TeacherIds { get; set; } = new List<int>();
        
    }
}
