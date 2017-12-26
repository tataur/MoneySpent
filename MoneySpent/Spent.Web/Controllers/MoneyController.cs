using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Spent.DAL;
using AutoMapper;
using Spent.Web.Models;
using NLog;
using System;

namespace Spent.Web.Controllers
{
    public class MoneyController : Controller
    {
        Repository repository;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public MoneyController()
        {
            repository = new Repository();
        }

        // GET: Money
        public ActionResult Index()
        {
            List<MoneyModel> moneyList = new List<MoneyModel>();
            List<TypeModel> typesList = new List<TypeModel>();

            var types = repository.GetTypes().ToList();
            foreach (var item in types)
            {
                var type = Mapper.Map<TypeEntity, TypeModel>(item);
                typesList.Add(type);
            }

            typesList.Insert(0, new TypeModel { TypeId = 0, TypeName = "все" });

            var entities = repository.GetAll();
            
            foreach (var entity in entities)
            {
                var item = Mapper.Map<MoneyEntity, MoneyModel>(entity);
                moneyList.Add(item);
            }

            var model = new MoneyIndexModelView
            {
                MoneyList = moneyList,
                TypeSelectList = new SelectList(typesList, "TypeId", "TypeName")
            };

            return View(model);
        }

        public JsonResult AddCost(decimal cost, DateTime date, int type)
        {
            logger.Info(cost);
            logger.Info(date);
            logger.Info(type);

            return Json(new { });
        }
    }
}