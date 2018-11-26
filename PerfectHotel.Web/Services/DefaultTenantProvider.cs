using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PerfectHotel.Web.Data.Migrations;

namespace PerfectHotel.Web.Services
{
    public class DefaultTenantProvider : ITenantProvider
    {
        private readonly string _tenantId;

        public DefaultTenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            //            var host = httpContextAccessor.HttpContext.Request.Host.Host;
            //            _tenantId = host == "localhost" ? "101" : "102";
            _tenantId = "101";
        }
        public string GetTenantId()
        {
            return _tenantId;
        }
    }
}
