using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectHotel.Web.Services
{
    public class DefaultTenantProvider : ITenantProvider
    {
        public string GetTenantId()
        {
            return "101";
        }
    }
}
