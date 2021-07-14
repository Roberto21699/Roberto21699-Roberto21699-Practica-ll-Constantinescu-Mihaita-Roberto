using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ferma.Services;
using Ferma.Models;

namespace Ferma.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService=userService;
        }

        // GET: Users
        public IActionResult Index()
        {
            var user =_userService.GetUsers();
            return View(user);
        }

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.GetUsers().FirstOrDefault(m => m.UserId == id);
     
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create(int? id)
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId,Nume,Prenume,Email,Username,Parola,RolId")] User user)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                _userService.Save();
                return RedirectToAction(nameof(Index));
            }
         
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.GetUsers().FirstOrDefault(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
           
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UserId,Nume,Prenume,Email,Username,Parola,RolId")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _userService.UpdateUser(user);
                    _userService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
           
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.GetUsers().FirstOrDefault(m => m.UserId == id); 
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _userService.GetUsersByCondition(b => b.UserId == id).FirstOrDefault();
            _userService.DeleteUser(user);
            _userService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _userService.GetUsers().Any(e => e.UserId == id);
        }
    }
}
