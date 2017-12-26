using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        //public int CostNum { get; set; }

        //[ForeignKey("FK_CostType")]
        public virtual TypeModel CostType { get; set; }
        public DateTime CostDate { get; set; }
        public decimal Cost { get; set; }
    }

    public class TypeModel
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}