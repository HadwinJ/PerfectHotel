using System;
using System.Collections.Generic;

namespace PerfectHotel.Web.Services
{
    public interface IEntityTypeProvider
    {
        IEnumerable<Type> GetEntityTypes();
    }
}
