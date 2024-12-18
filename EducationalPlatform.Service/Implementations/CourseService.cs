﻿using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Service.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        private readonly ICourseContentRepository _courseContentRepository;

        private readonly IContentService _contentService;

        private readonly IFileService _FileService;

        public CourseService(ICourseRepository courseRepository, ICourseContentRepository courseContentRepository, IContentService contentService, IFileService FileService)
        {
            _courseContentRepository = courseContentRepository;
            _courseRepository = courseRepository;
            _contentService = contentService;
            _FileService = FileService;
        }

        public async Task<string> AddCourse(Course course, List<int>? contentDto, IFormFile? ImageFile, string? webRootPath)
        {
            //Check if there is a Course with the same Name in the DB

            bool exist = _courseRepository.GetTableAsTracking().Where(c => c.Name == course.Name).Any();

            if (exist)
            {

                return "Exist";
            }
            else
            {
                course.ImagePath = (await _FileService.UploadFile(ImageFile, webRootPath));
                var newCourse = await _courseRepository.AddAsync(course);

                if (newCourse != null)
                {
                    if (contentDto != null)
                    {
                        foreach (var contentId in contentDto)
                        {
                            if ((await _contentService.ExistByIdAsync(contentId)))
                            {
                                await _courseContentRepository.AddAsync(new CourseContent()
                                {
                                    CourseId = newCourse.CourseId,
                                    ContentId = contentId,

                                });
                            }

                        }
                    }

                }


                return "Success";
            }


        }

        public async Task<string> DeleteAsync(Course course)
        {
            await _courseRepository.DeleteAsync(course);
            return "Success";
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            var course = _courseRepository.GetTableNoTracking().Where(x => x.CourseId == id).Include(x => x.Contents).Include(c => c.CourseContents).SingleOrDefault();
            course.ImageFile = await _FileService.GetFileAsync(course.ImagePath);
            return course;
        }

        public async Task<List<Course>> GetCoursesListAsync()
        {
            var Courses = await _courseRepository.GetCoursesListAsync();
            foreach (var course in Courses)
            {
                course.ImageFile = await _FileService.GetFileAsync(course.ImagePath);
            }
            return Courses;
        }

        public async Task<string> UpdateAsync(Course course)
        {

            var transact = _courseRepository.BeginTransaction();
            try
            {
                await _courseRepository.UpdateAsync(course);

                await transact.CommitAsync();
                return "Success";

            }
            catch
            {
                await transact.RollbackAsync();
                return "Falied";
            }

        }
    }
}
