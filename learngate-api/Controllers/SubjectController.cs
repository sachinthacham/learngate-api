using learngate_api.Contracts;
using learngate_api.DTOs.AnnouncementDto;
using learngate_api.DTOs.SubjectDto;
using learngate_api.Mappers;
using learngate_api.Repositories;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Route("getby/{Id}")]

        public async Task<IActionResult> GetSubjectById(int Id)
        {
            try
            {
                var subject = await _subjectRepository.GetSubjectByIdAsync(Id);
                if(subject == null)
                {
                    return NotFound("There are no subjects");
                }
                return Ok(subject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectDto subjectDto)
        {
            try
            {
                var newSubject = await _subjectRepository.CreateSubjectAsync(subjectDto.ToSubjectModel(), subjectDto.TeacherIds);
                var newSubjectDto = newSubject.ToSubjectDto();
                return CreatedAtAction(nameof(GetSubjectById), new { id = newSubject.Id }, newSubjectDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task <IActionResult> UpdateSubject([FromRoute] int Id, [FromBody] UpdateSubjectDto updateDto)
        {
            try
            {
                var excistingModel = await _subjectRepository.GetSubjectByIdAsync(Id);
                if (excistingModel == null)
                {
                    return NotFound("There are no subject found");
                }
                excistingModel.Name = updateDto.Name;

                await _subjectRepository.UpdateSubjectAsync(excistingModel);
                var subjectDto = excistingModel.ToSubjectDto();
                return Ok(subjectDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteSubject([FromRoute] int Id)
        {
            try
            {

                var deletedSubject = await _subjectRepository.DeleteSubjectAsync(Id);
                var deletedSubjectDto = deletedSubject.ToSubjectDto();
                return Ok(deletedSubjectDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
