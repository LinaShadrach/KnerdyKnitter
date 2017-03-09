using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KnerdyKnitter.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;


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
        //public IActionResult Create()
        //{
        //    Rules.MakeRules();
        //    Garment sampleGarment = new Garment();
        //    bool[] starterRow = new bool[] { true, true, true, true, false, true, true, true };
        //    sampleGarment.MakeGarment(starterRow, sampleGarment.RowDim);
        //    return View(sampleGarment);
        //}
        //[HttpPost]
        //public IActionResult Create(Garment garment, string primary, string secondary)
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var currentKnitter = _db.Knitters.FirstOrDefault(k => k.UserId == userId);
        //    garment.KnitterId = currentKnitter.Id;
        //    garment.CreationDate = DateTime.Now;
        //    garment.Save(garment);
        //    Color primaryColor = new Color(primary, "primary", garment.Id, currentKnitter.Id);
        //    Color secondaryColor = new Color(secondary, "secondary", garment.Id, currentKnitter.Id);
        //    primaryColor.Save(primaryColor);
        //    secondaryColor.Save(secondaryColor);
        //    return RedirectToAction("Edit", new { id = garment.Id });
        //}
        public IActionResult ChangeRule(string chosenRule, int rowDim, int colDim)
        {
            Garment thisGarment = new Garment();
            thisGarment.Rule = chosenRule;
            thisGarment.RowDim = rowDim;
            thisGarment.ColDim = colDim;
            bool[] starterRow = thisGarment.MakeStarterRow();
            thisGarment.MakeGarment(starterRow, rowDim);
            return Json(thisGarment);
        }
        public IActionResult Edit(int id)
        {
            Rules.MakeRules();
            Garment thisGarment = new Garment();
            bool[] starterRow = new bool[] { };
            if(id == 0)
            {
                starterRow = thisGarment.MakeStarterRow();
                Color primaryColor = new Color("#000000", "primary", thisGarment.Id, 0);
                Color secondaryColor = new Color("#ffffff", "secondary", thisGarment.Id, 0);
                thisGarment.Colors.Add(primaryColor);
                thisGarment.Colors.Add(secondaryColor);
            }
            else
            {
                thisGarment = _db.Garments.Include(g => g.Colors).FirstOrDefault(g => g.Id == id);
                starterRow = new bool[] { true, true, true, true, true, false, true, true, true, true };
            }
            thisGarment.MakeGarment(starterRow, thisGarment.RowDim);
            List<string[]> baseCombos = new List<string[]> () { };
            foreach(string rule in Rules.BaseCombos)
            {
                string[] ruleArr = rule.Split(new char[]{'e'}, 3);
                baseCombos.Add(ruleArr);
            }
            ViewBag.BaseCombos = baseCombos;
            return View(thisGarment);
        }
        [HttpPost]
        public IActionResult Edit(int garmentId, int rowDim, int colDim, string chosenRule, string primary, string secondary, string btnClicked, string[][] allAlters)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentKnitter = _db.Knitters.FirstOrDefault(k => k.UserId == userId);
            if(garmentId == 0)
            {
                Garment newGarment = new Garment();
                newGarment.KnitterId = currentKnitter.Id;
                newGarment.CreationDate = DateTime.Now;
                newGarment.RowDim = rowDim;
                newGarment.ColDim = colDim;
                newGarment.Rule = chosenRule;
                newGarment.Save(newGarment);
                Color primaryColor = new Color(primary, "primary", newGarment.Id, currentKnitter.Id);
                Color secondaryColor = new Color(secondary, "secondary", newGarment.Id, currentKnitter.Id);
                primaryColor.Save(primaryColor);
                secondaryColor.Save(secondaryColor);
                newGarment.Colors.Add(primaryColor);
                newGarment.Colors.Add(secondaryColor);
                return Json(newGarment.Id);
            }
            else
            {
                Garment garment = _db.Garments.FirstOrDefault(g => g.Id == garmentId);
                foreach(var alter in allAlters)
                {
                    Alter newAlter = new Alter(alter[0], alter[1], garment.Id);
                }
                garment.RowDim = rowDim;
                garment.ColDim = colDim;
                garment.Rule = chosenRule;
                Color primaryColor = _db.Colors.FirstOrDefault(c => c.Type == "primary" && c.GarmentId == garment.Id);
                primaryColor.Hex = primary;
                primaryColor.Edit(primaryColor);
                Color secondaryColor = _db.Colors.FirstOrDefault(c => c.Type == "secondary" && c.GarmentId == garment.Id);
                secondaryColor.Hex = secondary;
                secondaryColor.Edit(secondaryColor);
                bool[] starterRow = garment.MakeStarterRow();
                garment.Edit(garment);
                garment.Colors.RemoveAll(c => c.GarmentId == garmentId);
                garment.Colors.Add(primaryColor);
                garment.Colors.Add(secondaryColor);
                garment.MakeGarment(starterRow, garment.RowDim);
                return Json(garment.Id);

            }
            //if (btnClicked =="Try")
            //{
            //    Color primaryColor = new Color(primary, "primary", garment.Id, currentKnitter.Id);
            //    Color secondaryColor = new Color(secondary, "secondary", garment.Id, currentKnitter.Id);
            //    bool[] starterRow = new bool[] { true, true, true, true, false, true, true, true };
            //    garment.MakeGarment(starterRow, garment.RowDim);
            //}



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
