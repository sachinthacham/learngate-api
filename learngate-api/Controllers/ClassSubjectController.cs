using learngate_api.Contracts;
using learngate_api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    [Route("api/ClassSubjects")]
    [ApiController]
    public class ClassSubjectController : ControllerBase
    {
        private readonly IClassSubjectRepository _classSubjectrepository;
        public ClassSubjectController(IClassSubjectRepository classSubjectrepository)
        {
            _classSubjectrepository = classSubjectrepository;
        }

        [HttpGet]
        [Route("getSubjects/{classId}")]
        public async Task<IActionResult> GetSubjectsByClassId([FromRoute]int classId)
        {
            try
            {
                var subjects = await _classSubjectrepository.GetSubjectsByClassIdAsync(classId);
                if (subjects == null)
                {
                    return NotFound();
                }
                return Ok(subjects.Select(s => s.ToClassSubjectsDto()));
            }catch(Exception ex)
            {
                return BadRequest("i cant found the error");
            }
        }
    }
}
