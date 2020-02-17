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

        public ActionResult Details(int Id)
        {
            return View(_context.Superheroes.Find(Id));
        }
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

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

        public ActionResult Edit(int id)
        {
            return View(_context.Superheroes.Find(id));
        }

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

        public ActionResult Delete(int id)
        {
            return View(_context.Superheroes.Find(id));
        }

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