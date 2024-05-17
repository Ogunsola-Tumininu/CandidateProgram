using CandidateProgram.Models;

namespace CandidateProgram.Interfaces
{
    public interface IProgramRepository
    {
        Task Add(Programs program);
        Task<Programs?> GetById(Guid programId);
        Task<Programs?> Update(Programs program);
        Task<bool> Delete(Guid programId);

        Task<Question?> UpdateQuestion(Question question);

        Task AddCandidateResponse(CandidateResponse res);
    }
}
