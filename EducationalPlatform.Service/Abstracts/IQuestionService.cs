﻿using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IQuestionService
    {
        public Task<string> AddQuestionWithAnswer(ChooseQuestion question, List<string> choices);
        public Task<string> AddQuestion(AddQuestionRequest request);

        public Task<string> DeleteQuestionById(int id);

        public Task<List<Question>> GetQuestionListAsync();

        public Task<List<Question>> GetQuestionWithAnswerListAsync();


        public Task<GetQuestionResult> GetQuestionByIdAsync(int id);


        public Task<string> UpdateQuestionAsync(EditQuestionResult question);

        public Task<bool> ExistByIdAsync(int id);

    }
}
