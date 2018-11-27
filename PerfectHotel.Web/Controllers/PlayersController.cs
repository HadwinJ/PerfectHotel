using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerfectHotel.Web.Data;
using PerfectHotel.Web.Models;
using PerfectHotel.Web.Repositories;

namespace PerfectHotel.Web.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PlayersController(IRepositoryWrapper repoWrapper)
        {
            _repositoryWrapper = repoWrapper;            
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            return View(await _repositoryWrapper.Players.FindAllAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _repositoryWrapper.Players.FindByIdAsync(id.Value);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Id,TenantId,IsDeleted")] Player player)
        {
            if (ModelState.IsValid)
            {
                _repositoryWrapper.Players.Create(player);
                await _repositoryWrapper.Players.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _repositoryWrapper.Players.FindByIdAsync(id.Value);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Id,TenantId,IsDeleted")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repositoryWrapper.Players.Update(player);
                    await _repositoryWrapper.Players.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PlayerExists(player.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _repositoryWrapper.Players.FindByIdAsync(id.Value);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _repositoryWrapper.Players.FindByIdAsync(id);
            _repositoryWrapper.Players.Delete(player);
            await _repositoryWrapper.Players.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PlayerExists(int id)
        {
            var player = await _repositoryWrapper.Players.FindByIdAsync(id);
            return (null != player);
        }
    }
}
