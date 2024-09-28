﻿using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
