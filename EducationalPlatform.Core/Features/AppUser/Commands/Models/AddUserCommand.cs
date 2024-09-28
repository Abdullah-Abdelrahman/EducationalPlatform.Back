﻿using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.AppUser.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public string? Name { get; set; }

        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}