using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectHotel.Web.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string TenantId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
