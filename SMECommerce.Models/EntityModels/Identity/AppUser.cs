using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SMECommerce.Models.EntityModels.Identity
{
    public class AppUser:IdentityUser<int>
    {
        public string Address { get; set; }
    }
}
