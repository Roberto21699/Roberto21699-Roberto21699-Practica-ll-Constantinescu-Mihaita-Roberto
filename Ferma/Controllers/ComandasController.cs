using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ferma.Models;
using Ferma.Repository;
using Ferma.Services;



namespace Ferma.Controllers
{
    public class ComandasController : Controller
    {
        private readonly ComandaService _comandaService;

        public ComandasController(ComandaService comandaService)
        {
            _comandaService = comandaService;
        }

        // GET: Comandas
        public IActionResult Index()
        {
            var comenzi = _comandaService.GetComenzi();
            return View(comenzi);
        }

        // GET: Comandas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = _comandaService.GetComenzi().FirstOrDefault(m => m.ComandaId == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // GET: Comandas/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            // ViewData["UserId"] = new SelectList(_repo.Users, "UserId", "UserId");
            return View();
        }

        // POST: Comandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ComandaId,Data,UserId")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                _comandaService.AddComanda(comanda);
                _comandaService.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(comanda);
        }

        // GET: Comandas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = _comandaService.GetComenzi().FirstOrDefault(m => m.ComandaId == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // POST: Comandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ComandaId,Data,UserId")] Comanda comanda)
        {
            if (id != comanda.ComandaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _comandaService.UpdateComanda(comanda);
                    _comandaService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComandaExists(comanda.ComandaId))
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

            return View(comanda);
        }

        // GET: Comandas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = _comandaService.GetComenzi().FirstOrDefault(m => m.ComandaId == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // POST: Comandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var comanda = _comandaService.GetComenziByCondition(b => b.ComandaId == id).FirstOrDefault();
            _comandaService.DeleteComanda(comanda);
            _comandaService.Save();
            return RedirectToAction(nameof(Index));

        }

        private bool ComandaExists(int id)
        {
            return _comandaService.GetComenzi().Any(e => e.ComandaId == id);
        }
    }
}
