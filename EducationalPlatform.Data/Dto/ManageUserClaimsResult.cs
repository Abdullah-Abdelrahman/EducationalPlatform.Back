﻿namespace EducationalPlatform.Data.Dto
{
    public class ManageUserClaimsResult
    {
        public string UserId { get; set; }
        public List<UserClaim> userClaims { get; set; }
    }

    public class UserClaim
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}