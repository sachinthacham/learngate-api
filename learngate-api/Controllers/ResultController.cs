using learngate_api.Contracts;
using learngate_api.DTOs.AnnouncementDto;
using learngate_api.DTOs.ResultDto;
using learngate_api.Mappers;
using learngate_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    [Route("api/result")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository _resultRepository;
        public ResultController(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        [HttpGet]
        [Route("getAll")]

        public async Task<IActionResult> GetAllResults()
        {
            try
            {
                var allResults = await _resultRepository.GetAllResultsAsync();
                var ResultDto = allResults.Select(s => s.ToResultDto());
                return Ok(ResultDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getby/{Id}")]

        public async Task<IActionResult> GetResultById(int Id)
        {
            try
            {
                var result = await _resultRepository.GetResultByIdAsync(Id);
                if(result == null)
                {
                    return NotFound("There is no results");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateResult([FromBody] CreateResultDto resultDto)
        {
            try
            {
                var newResult = await _resultRepository.CreateResultAsync(resultDto.ToResultModel());
                var newResultDto = newResult.ToResultDto();
                return CreatedAtAction(nameof(GetResultById), new { id = newResult.Id }, newResultDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateResult([FromRoute] int Id, [FromBody] UpdateResultDto updateDto)
        {
            try
            {
                var excistingModel = await _resultRepository.GetResultByIdAsync(Id);
                if (excistingModel == null)
                {
                    return NotFound("There are no result found");
                }
                excistingModel.Score = updateDto.Score;
                excistingModel.ExamId = updateDto.ExamId;
                excistingModel.AssignmentId = updateDto.AssignmentId;
                excistingModel.StudentId = updateDto.StudentId;

                await _resultRepository.UpdateResultAsync(excistingModel);
                var resultDto = excistingModel.ToResultDto();
                return Ok(resultDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteResult([FromRoute] int Id)
        {
            try
            {

                var deletedResult = await _resultRepository.DeleteResultAsync(Id);
                var deletedResultDto = deletedResult.ToResultDto();
                return Ok(deletedResultDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
