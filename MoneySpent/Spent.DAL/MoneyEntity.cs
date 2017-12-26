using System;
using System.ComponentModel.DataAnnotations;

namespace Spent.DAL
{
    public class MoneyEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual TypeEntity CostType { get; set; }
        public DateTime CostDate { get; set; }
        public decimal Cost { get; set; }
    }

    public class TypeEntity
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
