﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BetEtMechant.Data;
using BetEtMechant.Models;

namespace BetEtMechant.Areas.Administration.Controllers
{
    public class TeamsController : BaseAdminController
    {

        public TeamsController(BetDbContext context) : base(context)
        {
        }

        // GET: Administration/Teams
        public async Task<IActionResult> Index()
        {
            var betDbContext = _context.Teams.Include(t => t.Championship);
            return View(await betDbContext.ToListAsync());
        }

        // GET: Administration/Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.Championship)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Administration/Teams/Create
        public IActionResult Create()
        {
            ViewData["ChampionshipID"] = new SelectList(_context.Championships, "ID", "Name");
            return View();
        }

        // POST: Administration/Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Score,Logo,ChampionshipID,ID")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();

                DisplayMessage("Equipe créée", "success");

                return RedirectToAction(nameof(Index));
            }
            ViewData["ChampionshipID"] = new SelectList(_context.Championships, "ID", "Name", team.ChampionshipID);
            return View(team);
        }

        // GET: Administration/Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            ViewData["ChampionshipID"] = new SelectList(_context.Championships, "ID", "Name", team.ChampionshipID);
            return View(team);
        }

        // POST: Administration/Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Score,Logo,ChampionshipID,ID")] Team team)
        {
            if (id != team.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();

                    DisplayMessage("Equipe update", "warning");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.ID))
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
            ViewData["ChampionshipID"] = new SelectList(_context.Championships, "ID", "Name", team.ChampionshipID);
            return View(team);
        }

        // GET: Administration/Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.Championship)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Administration/Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            DisplayMessage("Equipe delete", "danger");
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.ID == id);
        }
    }
}