using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spent.Logic;
using Spent.Data;

namespace Spent.Web.Controllers
{
    public class UserController : Controller
    {
        private static CommonRepository<UserEntity> _context = new CommonRepository<UserEntity>();

        //public UserController(CommonRepository<UserEntity> context)
        //{
        //    _context = context;
        //}

        //public UserController() : this (new CommonRepository<UserEntity>()) { }

        // GET: User
        public ActionResult Index()
        {
            IEnumerable<UserEntity> model;
            if (_context == null)
            {
                model = null;
            }
            else
            {
                model = _context.Queryable();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserEntity model)
        {
            var userEntity = new UserEntity()
            {
                userId = Guid.NewGuid(),
                userName = model.userName
            };

            _context.AddItem(userEntity);
            _context.SubmitChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var userEntity = _context.Queryable().FirstOrDefault(u => u.userId == id);
            
            return View(userEntity);
        }

        [HttpPost]
        public ActionResult Delete(UserEntity model)
        {
            
            return RedirectToAction("Index");
        }
    }
}