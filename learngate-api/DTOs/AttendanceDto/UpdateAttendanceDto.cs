namespace learngate_api.DTOs.AttendanceDto
{
    public class UpdateAttendanceDto
    {
        public DateTime Date { get; set; }
        public bool Present { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
    }
}
