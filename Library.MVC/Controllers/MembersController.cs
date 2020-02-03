using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Application.Interfaces;
using Library.Domain;
using Library.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.MVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService memberService;


        public MembersController(IMemberService memberService)
        {
            this.memberService = memberService;

        }
        // GET: Members
        public ActionResult Index()
        {
            var vm = new IndexMemberViewModel();
            vm.Members = memberService.GetAllMembers();

            return View(vm);
        }

        // GET: Members/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Members/Create
        public ActionResult CreateMember()
        {
            var vm = new CreateMemberViewModel();
            return View(vm);
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMember(CreateMemberViewModel vm)
        {
            try
            {
                // TODO: Add insert logic here
                var member = new Member();
                member.Name = vm.Name;
                member.SSN = vm.SSN;

                memberService.AddMember(member);
                
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Members/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}