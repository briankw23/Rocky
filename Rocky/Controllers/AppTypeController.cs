using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{
    public class AppTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AppTypeController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<AppType> appList = _db.AppTypes;
            return View(appList);
        }

        //Get Create
        public IActionResult Create()
        {
            return View();
        }
        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppType obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Edit - Get

        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            AppType obj = _db.AppTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //Edit Post

        [HttpPost]
        public IActionResult Edit(AppType obj)
        {
            if (ModelState.IsValid)
            {
                _db.AppTypes.Update(obj);
                _db.SaveChanges();
                return (RedirectToAction("Index"));
            }
            return View(obj);
        }
        //Delete get
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            AppType obj = _db.AppTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Delete Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAppType(int? id)
        {
            var obj = _db.AppTypes.Find(id);

            if(obj == null)
            {
                return NotFound();
            }
            _db.AppTypes.Remove(obj);
            _db.SaveChanges();
            return (RedirectToAction("Index"));

        }
    }
}
