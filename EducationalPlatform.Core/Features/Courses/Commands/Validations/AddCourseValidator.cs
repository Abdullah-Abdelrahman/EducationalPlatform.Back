﻿using EducationalPlatform.Core.Features.Courses.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Courses.Commands.Validations
{
    public class AddCourseValidator : AbstractValidator<AddCourseCommand>
    {

        #region
        public AddCourseValidator()
        {
            ValidationRules();
            CustomValidationRules();
        }
        #endregion
        private void CustomValidationRules()
        {

        }



        public void ValidationRules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must has value");


        }
    }
}