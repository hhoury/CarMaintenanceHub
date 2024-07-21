using CMH.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Owner>> GetOwners();
        Task<Owner> GetOwner(string userId);
        public string UserId { get; }
    }
}
