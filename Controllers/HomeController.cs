using BowlerFun.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlerFun.Controllers
{
    public class HomeController : Controller
    {

        private IBowlersRepository _repo { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.Teams = _repo.Teams.ToList();
            var balh = _repo.Bowlers.Include(x => x.Team).Distinct();

            return View(balh);
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {

            ViewBag.Teams = _repo.Teams.ToList();

           string teamIDString =form["teamName"];


             

            if (teamIDString != "")
            {
                int team = Int16.Parse(teamIDString);
               
                var balh = _repo.Bowlers.Where(x => x.TeamID == team);
                ViewBag.teamid = team;
                return View(balh);
            }
            else
            {
                var balh = _repo.Bowlers;
                return View(balh);
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowler = _repo.Bowlers.Where(x => x.BowlerId == id).FirstOrDefault();
            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler bowler)
        {
            _repo.DeleteBowler(bowler.BowlerId);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Teams = _repo.Teams.ToList();
            var blah = _repo.Bowlers.Where(x => x.BowlerId == id).FirstOrDefault();

            return View("create", blah);
        }

        [HttpGet]
        public IActionResult EditPost(Bowler bowler)
        {

            if (ModelState.IsValid)
            {
                _repo.EditBowler(bowler);
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Teams = _repo.Teams.ToList();
            return View("create");
        }

        [HttpPost]
        public IActionResult Create(Bowler bowler)
        {

            if (ModelState.IsValid)
            {
                if (bowler.BowlerId != 0)
                {
                  
                    return RedirectToAction("EditPost", bowler);
                }
                else {
                    var max = _repo.Bowlers.ToList().Last();
                    bowler.BowlerId = max.BowlerId + 1;

                    _repo.SaveBowler(bowler);
                return RedirectToAction("Index");
                }
                
            }

            ViewBag.Teams = _repo.Teams.ToList();
            return View("create");
        }

    }
}
