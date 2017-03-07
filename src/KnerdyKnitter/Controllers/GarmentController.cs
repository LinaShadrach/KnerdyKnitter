using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KnerdyKnitter.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

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
            Rules.MakeRules();
            Garment sampleGarment = new Garment();
            bool[] starterRow = new bool[] { true, true, true, true, false, true, true, true };
            sampleGarment.MakeGarment(starterRow, sampleGarment.RowDim);
            return View(sampleGarment);
        }
        [HttpPost]
        public IActionResult Create(Garment garment, string primary, string secondary)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentKnitter = _db.Knitters.FirstOrDefault(k => k.UserId == userId);
            garment.KnitterId = currentKnitter.Id;
            garment.CreationDate = DateTime.Now;
            garment.Save(garment);
            Color primaryColor = new Color(primary, "primary", garment.Id, currentKnitter.Id);
            Color secondaryColor = new Color(secondary, "secondary", garment.Id, currentKnitter.Id);
            primaryColor.Save(primaryColor);
            secondaryColor.Save(secondaryColor);
            return RedirectToAction("Edit", new { id = garment.Id });
        }
        public IActionResult Edit(int id)
        {
            Garment thisGarment = _db.Garments.Include(g => g.Colors).FirstOrDefault(g => g.Id == id);
            thisGarment.MakeGarment(new bool[] { true, true, true, true, true, false, true, true, true, true}, thisGarment.RowDim);
            return View(thisGarment);
        }
        [HttpPost]
        public IActionResult Edit(Garment garment, string primary, string secondary, string editBtn)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentKnitter = _db.Knitters.FirstOrDefault(k => k.UserId == userId);
            if (editBtn =="Try")
            {
                Color primaryColor = new Color(primary, "primary", garment.Id, currentKnitter.Id);
                Color secondaryColor = new Color(secondary, "secondary", garment.Id, currentKnitter.Id);
                bool[] starterRow = new bool[] { true, true, true, true, false, true, true, true };
                garment.MakeGarment(starterRow, garment.RowDim);
                return Json(garment);
            }
            else
            {
                Color primaryColor = _db.Colors.FirstOrDefault(c => c.Type == "primary" && c.KnitterId == currentKnitter.Id);
                primaryColor.Edit(primaryColor);
                Color secondaryColor = _db.Colors.FirstOrDefault(c => c.Type == "secondary" && c.KnitterId == currentKnitter.Id);
                secondaryColor.Edit(secondaryColor);
                bool[] starterRow = new bool[] { true, true, true, true, true, true, true, false, true, false, true, false, true, true, true, true, true, true };
                garment.MakeGarment(starterRow, garment.RowDim);
                garment.Colors.Add(primaryColor);
                garment.Colors.Add(secondaryColor);
                garment.Edit(garment);
                return Json(garment);
            }

        }
        [HttpPost]
        public IActionResult Delete(int garmentId)
        {
            Garment thisGarment = _db.Garments.FirstOrDefault(g => g.KnitterId == garmentId);
            thisGarment.Remove(thisGarment);
            return RedirectToAction("Index", "Knitter");
        }
    }
}
