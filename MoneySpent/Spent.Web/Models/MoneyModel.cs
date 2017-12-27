using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Spent.Web.Models
{
    public class MoneyIndexModelView
    {
        public List<MoneyModel> MoneyList { get; set; }
        public SelectList TypeSelectList { get; set; }
    }

    public class MoneyModel
    {
        public int Id { get; set; }
        public virtual TypeModel CostType { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CostDate { get; set; }
        public decimal Cost { get; set; }
    }

    public class TypeModel
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}