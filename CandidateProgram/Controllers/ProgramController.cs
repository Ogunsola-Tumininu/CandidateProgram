using CandidateProgram.Interfaces;
using CandidateProgram.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(Programs programInfo)
        {

            programInfo.ProgramId = Guid.NewGuid();
            programInfo.PersonalInfoField.PersonalID = Guid.NewGuid();
            if (programInfo.Questions.Count > 0)
            {
                foreach (var question in programInfo.Questions)
                {
                    question.QuestionID = Guid.NewGuid();
                }
            }

            var result = await _programService.Add(programInfo);
            return Ok(result);
        }

        [HttpGet("{programId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid programId)
        {
            if (programId == Guid.Empty) return BadRequest($"{nameof(programId)} is required.");

            var personalInfo = await _programService.GetById(programId);

            if (personalInfo == null) return NotFound();

            return Ok(personalInfo);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Programs programInfo)
        {
            var result = await _programService.Update(programInfo);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{programId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid programId)
        {
            if (programId == Guid.Empty) return BadRequest($"{nameof(programId)} is required.");

            var result = await _programService.Delete(programId);

            if (!result) return BadRequest();

            return Ok();
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("EditQuestion")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditQuestion(Question question)
        {
            var result = await _programService.UpdateQuestion(question);

            if (result == null) return BadRequest();

            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Candidate")]
        public async Task<IActionResult> Candidate(CandidateResponse data)
        {

            data.ResponseID = Guid.NewGuid();
            if (data.Answers.Count > 0)
            {
                foreach (var ans in data.Answers)
                {
                    ans.AnswerID = Guid.NewGuid();
                }
            }
            var result = await _programService.AddCandidateResponse(data);

            return Ok(result);
        }

    }
}
