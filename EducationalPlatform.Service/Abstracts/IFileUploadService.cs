﻿using Microsoft.AspNetCore.Http;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IFileUploadService
    {

        public Task<string> UploadFile(IFormFile? file, string WebRootPath);
    }
}
