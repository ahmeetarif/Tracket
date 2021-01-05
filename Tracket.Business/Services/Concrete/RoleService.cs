using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracket.Business.Services.Abstract;
using Tracket.Common;
using Tracket.Common.Exceptions;
using Tracket.Common.Helpers;
using Tracket.Contracts.V1.Responses.RoleManager;
using Tracket.Dto.Models;

namespace Tracket.Business.Services.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IStringLocalizer<RoleService> _localizer;
        private readonly IMapper _mapper;
        public RoleService(RoleManager<IdentityRole> roleManager,
                IStringLocalizer<RoleService> localizer,
                IMapper mapper)
        {
            this._roleManager = roleManager;
            this._localizer = localizer;
            this._mapper = mapper;
        }

        public async Task<RoleManagerResponseModel> CreateRoleAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName) || string.IsNullOrWhiteSpace(roleName))
            {
                throw new TracketBadRequestException(_localizer[Constants.LocalizedValueKeys.Messages.PleaseProvideRequiredInformationMessage]);
            }

            bool isRoleExist = await _roleManager.RoleExistsAsync(roleName);

            if (isRoleExist)
            {
                throw new TracketBusinessException(_localizer[Constants.LocalizedValueKeys.Messages.RoleAlreadyExistMessage]);
            }

            IdentityRole identityRole = new IdentityRole
            {
                Name = roleName
            };

            IdentityResult createRoleResult = await _roleManager.CreateAsync(identityRole);

            if (createRoleResult.Succeeded)
            {
                return new RoleManagerResponseModel
                {
                    Message = _localizer[Constants.LocalizedValueKeys.Messages.RoleAddedSuccessfullyMessage]
                };
            }

            throw new TracketInternalServerException();
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            List<IdentityRole> roles = _roleManager.Roles.ToList();
            List<RoleDto> roleDtos = _mapper.Map<List<RoleDto>>(roles);
            return roleDtos;
        }

        public async Task<RoleDto> GetRoleAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName) || string.IsNullOrWhiteSpace(roleName))
            {
                throw new TracketBadRequestException(_localizer[Constants.LocalizedValueKeys.Messages.PleaseProvideRequiredInformationMessage]);
            }

            IdentityRole role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                throw new TracketBusinessException(Constants.LocalizedValueKeys.Messages.RoleNotFoundMessage);
            }

            RoleDto roleDto = _mapper.Map<RoleDto>(role);

            return roleDto;
        }

        public async Task<RoleManagerResponseModel> DeleteRoleAsync(string roleName)
        {
            if (roleName.CheckStringNullWhitespaceAndEmpty())
            {
                throw new TracketBadRequestException(_localizer[Constants.LocalizedValueKeys.Messages.PleaseProvideRequiredInformationMessage]);
            }

            IdentityRole role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                throw new TracketBusinessException(_localizer[Constants.LocalizedValueKeys.Messages.RoleNotFoundMessage]);
            }

            IdentityResult deleteRoleResult = await _roleManager.DeleteAsync(role);

            if (deleteRoleResult.Succeeded)
            {
                return new RoleManagerResponseModel
                {
                    Message = _localizer[Constants.LocalizedValueKeys.Messages.RoleDeletedMessage]
                };
            }

            throw new TracketInternalServerException();
        }
    }
}