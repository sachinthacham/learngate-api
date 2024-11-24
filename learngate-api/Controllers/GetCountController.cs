using learngate_api.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    [Route("api/getCount")]
    [ApiController]
    public class GetCountController : ControllerBase
    {   private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IParentRepository _parentRepository;
        public GetCountController(IStudentRepository studentRepository, ITeacherRepository teacherRepository, IParentRepository  parentRepository)
        {
            _parentRepository = parentRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        [Route("getTotalCount")]

        public async Task<IActionResult> getTotalStudentCount()
        {
            try
            {
                var studentCount = await _studentRepository.TotalStudentCountAsync();
                var teacherCount = await _teacherRepository.GetTeacherCountAsync();
                var parentCount = await _parentRepository.GetParentCountAsync();
                var BoyCount = await _studentRepository.TotalBoyCountAsync();
                var GirlCount = await _studentRepository.TotalGirlCountAsync();
                return Ok(new { StudentCount = studentCount, TeacherCount = teacherCount, ParentCount = parentCount,BoyCount = BoyCount,GirlCount = GirlCount
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
