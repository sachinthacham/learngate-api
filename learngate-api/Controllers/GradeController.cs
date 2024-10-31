using learngate_api.Contracts;
using learngate_api.DTOs.AnnouncementDto;
using learngate_api.DTOs.GradeDto;
using learngate_api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    [Route("api/grade")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _gradeRepository;
        public GradeController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        [HttpGet]
        [Route("getAll")]

        public async Task<IActionResult> GetAllGrades()
        {
            try
            {
                var allGrades = await _gradeRepository.GetAllGradesAsync();
                var gradeDto = allGrades.Select(s => s.ToGradeDto());
                return Ok(gradeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getby/{Id}")]

        public async Task<IActionResult> GetGradeById(int Id)
        {
            try
            {
                var grade = await _gradeRepository.GetGradeByIdAsync(Id);
                if(grade == null)
                {
                    return NotFound("There are no grades");
                }
                return Ok(grade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateGrade([FromBody] CreateGradeDto gradeDto)
        {
            try
            {
                var newGrade = await _gradeRepository.CreateGradeAsync(gradeDto.ToGradeModel());
                var newGradeDto = newGrade.ToGradeDto();
                return CreatedAtAction(nameof(GetGradeById), new { id = newGrade.Id }, newGradeDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateGrade([FromRoute] int Id, [FromBody] UpdateGradeDto updateDto)
        {
            try
            {
                var excistingModel = await _gradeRepository.GetGradeByIdAsync(Id);
                if (excistingModel == null)
                {
                    return NotFound("There are no Grade found");
                }
                excistingModel.Level = updateDto.Level;

                await _gradeRepository.UpdateGradeAsync(excistingModel);
                var gradeDto = excistingModel.ToGradeDto();
                return Ok(gradeDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteGrade([FromRoute] int Id)
        {
            try
            {

                var deletedGrade = await _gradeRepository.DeleteGradeAsync(Id);
                var deletedGradeDto = deletedGrade.ToGradeDto();
                return Ok(deletedGradeDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
