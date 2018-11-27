using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectHotel.Web.Repositories
{
    public interface IRepositoryWrapper
    {
        IPlayerRepository Players { get; }
    }
}
