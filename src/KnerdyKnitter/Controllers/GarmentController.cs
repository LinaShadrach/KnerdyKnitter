using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KnerdyKnitter.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KnerdyKnitter.Controllers
{
    public class GarmentController : Controller
    {
        private readonly KnerdyKnitterContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public GarmentController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, KnerdyKnitterContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Create()
        {
            Garment emptyGarment = new Garment();
            return View(emptyGarment);
        }
        [HttpPost]
        public IActionResult Create(Garment garment)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentKnitter = _db.Knitters.FirstOrDefault(k => k.UserId == userId);
            garment.KnitterId = currentKnitter.Id;
            garment.CreationDate = DateTime.Now;
            garment.Save(garment);
            return View();
        }
        public IActionResult Edit(int id)
        {
            Garment thisGarment = _db.Garments.FirstOrDefault(g => g.KnitterId == id);
            return View(thisGarment);
        }
        [HttpPost]
        public IActionResult Edit(Garment garment)
        {
            garment.Edit(garment);
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Garment thisGarment = _db.Garments.FirstOrDefault(g => g.KnitterId == id);
            thisGarment.Remove(thisGarment);
            return View();
        }
    }
}
