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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var entity = repository.Find(id);
            var model = Mapper.Map<MoneyEntity, MoneyModel>(entity);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MoneyModel model)
        {
            var entity = Mapper.Map<MoneyModel, MoneyEntity>(model);
            repository.Update(entity);
            repository.Save();
            return RedirectToAction("Index");
        }

        public JsonResult AddCost(int id, decimal cost, DateTime date, int type)
        {
            logger.Info(id);
            logger.Info(cost);
            logger.Info(date);
            logger.Info(type);

            var typeModel = repository.GetTypes().FirstOrDefault(t => t.TypeId == type);

            var entity = new MoneyEntity
            {
                Id = id,
                Cost = cost,
                CostDate = date,
                CostType = typeModel
            };
            repository.Create(entity);
            repository.Save();

            return Json(new { });
        }
    }
}