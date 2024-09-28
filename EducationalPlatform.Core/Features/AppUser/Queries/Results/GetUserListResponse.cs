﻿namespace EducationalPlatform.Core.Features.AppUser.Queries.Results
{
    public class GetUserListResponse
    {
        public string UserId { get; set; }
        public string? Name { get; set; }

        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

    }
}