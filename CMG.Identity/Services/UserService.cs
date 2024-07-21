using CMH.Application.Contracts.Identity;
using CMH.Application.Models;
using CMH.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CMH.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<User> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

        public async Task<Owner> GetOwner(string userId)
        {
            var owner = await _userManager.FindByIdAsync(userId);
            return new Owner
            {
                Email = owner.Email,
                Id = owner.Id,
                Name = owner.Name
            };
        }

        public async Task<List<Owner>> GetOwners()
        {
            var owners = await _userManager.GetUsersInRoleAsync("Owner");
            return owners.Select(q => new Owner
            {
                Id = q.Id,
                Email = q.Email,
                Name = q.Name
            }).ToList();
        }
    }
}

