using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace BookStore.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
