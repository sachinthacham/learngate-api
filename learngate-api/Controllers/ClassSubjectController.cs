using learngate_api.Contracts;
using learngate_api.DTOs.ClassDto;
using learngate_api.DTOs.ClassSubjectDto;
using learngate_api.Mappers;
using learngate_api.Models;
using learngate_api.Repositories;
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

        [HttpGet]
        [Route("getBy/{classSubjectId}")]
        public async Task<IActionResult> GetClassSubjectById([FromRoute] int classSubjectId)
        {
            try
            {
                var subject = await _classSubjectrepository.GetClassSubjectById(classSubjectId);
                if (subject == null)
                {
                    return NotFound();
                }
                return Ok(subject.ToClassSubjectsDto());
            }
            catch (Exception ex)
            {
                return BadRequest(" found the error");
            }
        }

        [HttpPost]
        [Route("create")] 

        public async Task<IActionResult> CreateClass([FromBody] CreateClassSubjectDto classSubject)
        {
            try
            {
                var newClassSubject = await _classSubjectrepository.CreateClassSubject(classSubject.ToClassSubjectModel());
                var ClassSubjectDto = newClassSubject.ToClassSubjectsDto();


                
                return CreatedAtAction(nameof(GetClassSubjectById), new { ClassSubjectId = newClassSubject.ClassSubjectId }, ClassSubjectDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
