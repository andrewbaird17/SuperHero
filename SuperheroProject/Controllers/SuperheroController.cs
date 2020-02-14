using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Superhero superhero)
        {
            if(ModelState.IsValid)
            {
                _context.Superheroes.Add(superhero);
                _context.Savechanges();
                return View();
            }
            else
            {
                return View(superhero);
            }

        }
    }
}