﻿using EducationalPlatform.Core.Features.Question.Commands.Models;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Core.Mapping.Question
{
    public partial class QuestionProfile
    {

        public void AddChooseQuestionWithAnswerMapping()
        {
            CreateMap<AddChooseQuestionWithAnswerCommand, ChooseQuestion>().ForMember(destnation => destnation.QuestionText, opt => opt.MapFrom(src => src.QuestionText)).ForMember(destnation => destnation.QuestionImage, opt => opt.MapFrom(src => src.QuestionImage));

            CreateMap<AddChooseQuestionWithAnswerCommand, ChooseQuestion>()
           .ForMember(dest => dest.ChoiceList, opt => opt.Ignore());
        }
    }
}
