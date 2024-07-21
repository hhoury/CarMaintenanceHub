using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Password is limited to {2} to {1} characters", MinimumLength = 6)]

        public string Password { get; set; }
    }
}
