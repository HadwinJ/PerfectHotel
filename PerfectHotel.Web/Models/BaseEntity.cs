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

        private DateTime? _createdAt;
        private string _createdBy;
        private DateTime? _lastUpdatedAt;
        private string _lastUpdatedBy;

        public DateTime? CreatedAt => _createdAt;
        public string CreatedBy => _createdBy;
        public DateTime? LastUpdatedAt => _lastUpdatedAt;
        public string LastUpdatedBy => _lastUpdatedBy;
    }
}
