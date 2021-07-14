using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ferma.Models;
using Ferma.Services;

namespace Ferma.Controllers
{
    public class NotasController : Controller
    {
        private readonly NotaService _notaService;

        public NotasController(NotaService notaService)
        {
            _notaService = notaService;
        }

        // GET: Notas
        public IActionResult Index()
        {
            var nota = _notaService.GetNote();
            return View(nota);
        }

        // GET: Notas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = _notaService.GetNote().FirstOrDefault(m => m.NotaId == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("NotaId,Data,Total,UserId")] Nota nota)
        {
            if (ModelState.IsValid)
            {
                _notaService.AddNota(nota);
                _notaService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(nota);
        }

        // GET: Notas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = _notaService.GetNote().FirstOrDefault(m => m.NotaId == id);
            if (nota == null)
            {
                return NotFound();
            }
            
            return View(nota);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("NotaId,Data,Total,UserId")] Nota nota)
        {
            if (id != nota.NotaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _notaService.UpdateNota(nota);
                    _notaService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaExists(nota.NotaId))
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
           
            return View(nota);
        }

        // GET: Notas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = _notaService.GetNote().FirstOrDefault(m => m.NotaId == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var nota = _notaService.GetNoteByCondition(b => b.NotaId == id).FirstOrDefault();
            _notaService.DeleteNota(nota);
            _notaService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaExists(int id)
        {
            return _notaService.GetNote().Any(e => e.NotaId == id);
        }
    }
}
