using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectHotel.Web.Data;

namespace PerfectHotel.Web.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IPlayerRepository _players;

        private readonly ApplicationDbContext _context;

        public IPlayerRepository Players => _players ?? (_players = new PlayerRepository(_context));

        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }
    }    
}
