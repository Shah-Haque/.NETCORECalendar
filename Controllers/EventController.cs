﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using dotnetcoreCalendar.Data;
//using dotnetcoreCalendar.Models;
//using dotnetcoreCalendar.Models.ViewModels;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Authorization;

//namespace dotnetcoreCalendar.Controllers
//{
//    [Authorize]
//    public class EventController : Controller
//    {
//        private readonly DAL _dal;

//        public EventController(DAL dal)
//        {
//            _dal = dal;
//        }

//        // GET: Event
//        public IActionResult Index()
//        {
//            if (TempData["Alert"] == null)
//            {
//                ViewData["Alert"] = TempData["Alert"];
//            }
//            return View(_dal.GetEvents());
//        }

//        // GET: Event/Details/5
//        public IActionResult Details(int? id) //Nullable int 
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var @event = _dal.GetEvent((int)id);
//            if (@event == null)
//            {
//                return NotFound();
//            }

//            return View(@event);
//        }

//        // GET: Event/Create
//        public IActionResult Create()
//        {

//            return View(new EventViewModel(_dal.GetLocations()));
//        }

//        // POST: Event/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task <IActionResult> Create(EventViewModel vm, IFormCollection form)
//        {
//            try
//            {
//                _dal.CreateEvent(form);
//                TempData["Alert"] = "Success! You have created a new event:" + form["Name"];
//                return RedirectToAction("Index");
//            }
//            catch (Exception ex)
//            {

//                ViewData["Alert"] = "An error has occured:" + ex.Message;
//                return View(vm);
//            }

//        }

//        // GET: Event/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var @event = _dal.GetEvent((int)id);
//            if (@event == null)
//            {
//                return NotFound();
//            }
//            return View(@event);
//        }

//        // POST: Event/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task <IActionResult> Edit(int id, EventViewModel vm, IFormCollection form)
//        {
//            if (id != vm.Event.Id)
//            {
//                return NotFound();
//            }

//            try
//            {
//                _dal.UpdateEvent(form);
//                TempData["Alert"]="You have sucessfully modifed a Event for:" + vm.Event.Name;
//                return RedirectToAction(nameof(Index));

//            }

//            catch (Exception ex)
//            {
//                ViewData["Alert"] = "An error has occured:" + ex.Message;
//                return View(vm);
//            }

//        }

//        // GET: Event/Delete/5
//        public IActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var @event = _dal.GetEvent((int)id);
//            if (@event == null)
//            {
//                return NotFound();
//            }

//            return View(@event);
//        }

//        // POST: Event/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {
//             _dal.DeleteEvent(id);
//            TempData["Alert"] = "You have deleted an event";
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using dotnetcoreCalendar.Data;
using dotnetcoreCalendar.Models.ViewModels;
//using DotNetCoreCalendar.Controllers.ActionFilters;

namespace DotNetCoreCalendar.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IDAL _dal;


        public EventController(IDAL dal)
        {
            _dal = dal;

        }

        // GET: Event
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dal.GetMyEvents(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        // GET: Event/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create

        public IActionResult Create()
        {

            return View(new EventViewModel(_dal.GetLocations()));
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(EventViewModel vm, IFormCollection form)
        {
            try
            {
                _dal.CreateEvent(form);
                TempData["Alert"] = "Success! You created a new event for: " + form["Event.Name"];
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                return View(vm);
            }
        }

        // GET: Event/Edit/5

        public IActionResult Edit(int? id)
        {
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var @event = _dal.GetEvent((int)id);
            //    if (@event == null)
            //    {
            //        return NotFound();
            //    }
            //    var vm = new EventViewModel(@event, _dal.GetLocations(), User.FindFirstValue(ClaimTypes.NameIdentifier));
            //    return View(vm);


            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);

        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       

        //public async Task<IActionResult> Edit(int id, IFormCollection form)
        //{
        //    try
        //    {
        //        _dal.UpdateEvent(form);
        //        TempData["Alert"] = "Success! You modified an event for: " + form["Event.Name"];
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewData["Alert"] = "An error occurred: " + ex.Message;
        //        var vm = new EventViewModel(_dal.GetEvent(id), _dal.GetLocations(), User.FindFirstValue(ClaimTypes.NameIdentifier));
        //        return View(vm);
        //    }
        //}
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EventViewModel vm, IFormCollection form)
        {
            if (id != vm.Event.Id)
            {
                return NotFound();
            }

            try
            {
                _dal.UpdateEvent(form);
                TempData["Alert"] = "You have sucessfully modifed a Event for:" + vm.Event.Name;
                return RedirectToAction(nameof(Index));

            }

            catch (Exception ex)
            {
                ViewData["Alert"] = "An error has occured:" + ex.Message;
                return View(vm);
            }

        }


        // GET: Event/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dal.DeleteEvent(id);
            TempData["Alert"] = "You deleted an event.";
            return RedirectToAction(nameof(Index));
        }
    }
}
