﻿using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Authorization.Quaries.Models;
using EducationalPlatform.Core.Features.Authorization.Quaries.Results;
using EducationalPlatform.Data.Dto;
using EducationalPlatform.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

using US = EducationalPlatform.Data.Entities;


namespace EducationalPlatform.Core.Features.Authorization.Quaries.Handlers
{
    public class RoleQueryHandler : ResponseHandler,
        IRequestHandler<GetRoleListQuery, Response<List<GetRoleListResponse>>>,
         IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResponse>>,
        IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResult>>
    {

        #region

        private readonly IMapper _mapper;

        private readonly IAuthorizationService _authorizationService;

        private readonly UserManager<US.AppUser> _userManager;
        #endregion

        public RoleQueryHandler(IMapper mapper,
            IAuthorizationService authorizationService,
            UserManager<US.AppUser> userManager)
        {
            _userManager = userManager;
            _authorizationService = authorizationService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetRoleListResponse>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRolesList();

            var result = _mapper.Map<List<GetRoleListResponse>>(roles);
            return Success<List<GetRoleListResponse>>(result);
        }

        public async Task<Response<GetRoleByIdResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleById(request.RoleId);

            if (role == null)
            {
                return NotFound<GetRoleByIdResponse>($"there is no Role with id = {request.RoleId}");
            }
            else
            {
                var result = _mapper.Map<GetRoleByIdResponse>(role);
                return Success<GetRoleByIdResponse>(result);
            }
        }

        public async Task<Response<ManageUserRolesResult>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                return NotFound<ManageUserRolesResult>($"there is no user with id={request.UserId}");
            }
            else
            {
                var result = await _authorizationService.ManageUserRolesData(user);

                return Success<ManageUserRolesResult>(result);
            }

            throw new NotImplementedException();
        }
    }
}
