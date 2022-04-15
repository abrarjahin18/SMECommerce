using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.App.Models.Auth
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
