using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroProject.Data;
using SuperheroProject.Models;

namespace SuperheroProject.Controllers
{
    public class SuperheroController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Superhero
        public ActionResult Index()
        {
            return View(_context.Superheroes.ToList());
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int Id)
        {
            return View(_context.Superheroes.Find(Id));
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Create(superhero);
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Superheroes.Find(id));
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                _context.Superheroes.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Edit(id);
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Superheroes.Find(id));
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            _context.Superheroes.Remove(superhero);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}