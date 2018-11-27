using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfectHotel.Web.Data;
using PerfectHotel.Web.Models;

namespace PerfectHotel.Web.Repositories
{
    public class PlayerRepository: GenericAsyncRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext context) : base(context)
        {
        }
        //        private readonly ApplicationDbContext _context;
        //
        //        public PlayerRepository(ApplicationDbContext context)
        //        {
        //            _context = context;
        //        }
        //
        //        public async Task<IEnumerable<Player>> FindAllAsync()
        //        {
        //            return await _context.Players.ToListAsync();
        //        }
        //
        //        public async Task<Player> FindByIdAsync(int id)
        //        {
        //            return await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
        //        }
        //
        //        public void Create(Player player)
        //        {
        //            _context.Players.Add(player);
        //        }
        //
        //        public void Delete(Player player)
        //        {
        //            _context.Players.Remove(player);
        //        }
        //
        //        public void Update(Player player)
        //        {
        //            _context.Players.Update(player);
        //        }
        //
        //        public async Task SaveChangesAsync()
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //
        //        public void Dispose()
        //        {
        //            Dispose(true);
        //            GC.SuppressFinalize(this);
        //        }
        //
        //        private bool disposed = false;
        //
        //        protected void Dispose(bool disposing)
        //        {
        //            if (!this.disposed)
        //            {
        //                if (disposing)
        //                {
        //                    _context.Dispose();
        //                }                
        //            }
        //            this.disposed = true;
        //        }

    }
}
