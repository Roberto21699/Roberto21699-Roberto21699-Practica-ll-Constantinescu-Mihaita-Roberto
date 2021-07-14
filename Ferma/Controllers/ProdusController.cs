using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ferma.Models;
using Ferma.Services;

namespace Ferma.Controllers
{
    public class ProdusController : Controller
    {
        private readonly ProdusService _produsService;

        public ProdusController(ProdusService produsService)
        {
            _produsService = produsService;
        }

        // GET: Produs
        public IActionResult Index()
        {
            var produse = _produsService.GetProduse();
            return View(produse);
        }

        // GET: Produs/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs = _produsService.GetProduse().FirstOrDefault(m => m.ProdusId == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProdusId,Denumire,Pret")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                _produsService.AddProdus(produs);
                _produsService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(produs);
        }

        // GET: Produs/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs= _produsService.GetProduse().FirstOrDefault(m => m.ProdusId == id);
            if (produs == null)
            {
                return NotFound();
            }
            return View(produs);
        }

        // POST: Produs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProdusId,Denumire,Pret")] Produs produs)
        {
            if (id != produs.ProdusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _produsService.UpdateProdus(produs);
                    _produsService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdusExists(produs.ProdusId))
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
            return View(produs);
        }

        // GET: Produs/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produs = _produsService.GetProduse().FirstOrDefault(m => m.ProdusId == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        // POST: Produs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produs = _produsService.GetProduseByCondition(b => b.ProdusId == id).FirstOrDefault();
            _produsService.DeleteProdus(produs);
            _produsService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdusExists(int id)
        {
            return _produsService.GetProduse().Any(e => e.ProdusId == id);
        }
    }
}
