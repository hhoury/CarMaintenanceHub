using CMH.Application.DTOs;
using CMH.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);

    }
}
