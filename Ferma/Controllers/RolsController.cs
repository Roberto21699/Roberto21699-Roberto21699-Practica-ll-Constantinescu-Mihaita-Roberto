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
    public class RolsController : Controller
    {
        private readonly RolService _rolService;

        public RolsController(RolService rolService)
        {
            _rolService = rolService;
        }

        // GET: Rols
        public IActionResult Index()
        {
            var rol = _rolService.GetRoluri();
            return View(rol);
        }

        // GET: Rols/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = _rolService.GetRoluri().FirstOrDefault(m => m.RolId == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // GET: Rols/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RolId,Tip")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                _rolService.AddRol(rol);
                _rolService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }

        // GET: Rols/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = _rolService.GetRoluri().FirstOrDefault(m => m.RolId == id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        // POST: Rols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RolId,Tip")] Rol rol)
        {
            if (id != rol.RolId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _rolService.UpdateRol(rol);
                    _rolService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolExists(rol.RolId))
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
            return View(rol);
        }

        // GET: Rols/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = _rolService.GetRoluri().FirstOrDefault(m => m.RolId == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: Rols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var rol = _rolService.GetRoluriByCondition(b => b.RolId == id).FirstOrDefault();
            _rolService.DeleteRol(rol);
            _rolService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool RolExists(int id)
        {
            return _rolService.GetRoluri().Any(e => e.RolId == id);
        }
    }
}
