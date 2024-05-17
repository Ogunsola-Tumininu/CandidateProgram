using CandidateProgram.Interfaces;
using CandidateProgram.Models;

namespace CandidateProgram.Services
{
   
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;

        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<Programs?> GetById(Guid programId)
        {
            var programInfo = await _programRepository.GetById(programId);

            return programInfo;
        }

        public async Task<Programs> Add(Programs personalInfo)
        {
            await _programRepository.Add(personalInfo);

            return personalInfo;
        }

        public async Task<Programs?> Update(Programs personalInfo)
        {
            var result = await _programRepository.Update(personalInfo);

            return result;
        }

        public async Task<bool> Delete(Guid programId)
        {
            var result = await _programRepository.Delete(programId);

            return result;
        }

        public async Task<Question?> UpdateQuestion(Question question)
        {
            var result = await _programRepository.UpdateQuestion(question);

            return result;
        }

        public async Task<CandidateResponse> AddCandidateResponse(CandidateResponse res)
        {
            await _programRepository.AddCandidateResponse(res);

            return res;
        }
    }
}
