using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spent.Data
{
    public class EarnCostEntity
    {
        public Guid spentGuid { get; set; }
        public DateTime spentDate { get; set; }
        public UserEntity userEntity { get; set; }
        public TypeEntity typeEntity { get; set; }
    }
}
