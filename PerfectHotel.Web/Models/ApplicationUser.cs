using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PerfectHotel.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(10)]
        public string TenantId { get; set; }

        [StringLength(32)]
        public string TenantName { get; set; }
    }
}
