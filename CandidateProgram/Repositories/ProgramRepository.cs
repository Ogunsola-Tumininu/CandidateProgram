using CandidateProgram.DataContext;
using CandidateProgram.Interfaces;
using CandidateProgram.Models;

namespace CandidateProgram.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly CosmosDbContext _dbContext;

        public ProgramRepository(CosmosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Programs program)
        {
            _dbContext.Add(program);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Programs?> GetById(Guid programId)
        {
            var program = await LoadProgramInfoWithReferences(programId);

            return program;
        }

        public async Task<Programs?> Update(Programs program)
        {
            var existingProgramInfo = await LoadProgramInfoWithReferences(program.ProgramId);

            if (existingProgramInfo == null) return null;

            existingProgramInfo.ProgramDescription = program.ProgramDescription;
            existingProgramInfo.ProgramName = program.ProgramName;
            existingProgramInfo.Questions = program.Questions;

            await _dbContext.SaveChangesAsync();

            return program;
        }

        public async Task<bool> Delete(Guid personalId)
        {

            var personalInfo = await LoadProgramInfoWithReferences(personalId);

            if (personalInfo == null) return false;

            _dbContext.Programs.Remove(personalInfo);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        private async Task<Programs?> LoadProgramInfoWithReferences(Guid programId)
        {
            var programInfo = await _dbContext
                .Programs
                .FindAsync(programId);

            if (programInfo == null) return null;

            var programInfoEntry = _dbContext.Programs.Entry(programInfo);
            await programInfoEntry
                .Collection(personal => personal.Questions)
                .LoadAsync();


            await programInfoEntry
                .Reference(personal => personal.PersonalInfoField)
                .LoadAsync();

           


            


            return programInfo;
        }

        public async Task<Question?> UpdateQuestion(Question question)
        {
            var existingQuestion = await LoadQuestionInfoWithReferences(question.QuestionID);

            if (existingQuestion == null) return null;

            existingQuestion.Type = question.Type;
            existingQuestion.Description = question.Description;
            existingQuestion.Choices = question.Choices;
            existingQuestion.MaxChoice = question.MaxChoice;


            await _dbContext.SaveChangesAsync();

            return question;
        }

        private async Task<Question?> LoadQuestionInfoWithReferences(Guid questionId)
        {
            var questionInfo = await _dbContext
                .Question
                .FindAsync(questionId);

            if (questionInfo == null) return null;


            return questionInfo;
        }

        public async Task AddCandidateResponse(CandidateResponse program)
        {
            _dbContext.Add(program);

            await _dbContext.SaveChangesAsync();
        }





    }
}
