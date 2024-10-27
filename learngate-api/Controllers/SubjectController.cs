using learngate_api.Contracts;
using learngate_api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpGet]
        [Route("getAllSubjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            try
            {
                var subjects = await _subjectRepository.GetAllSubjectsAsync();
                var subjectsDto = subjects.Select(s => s.ToSubjectDto());
                return Ok(subjectsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
