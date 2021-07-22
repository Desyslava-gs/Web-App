using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Repairs
{
    public class AddRepairFormModel
    {  
        public string TypeOfRepair { get; set; }
        
        public decimal Price { get; set; }
        
        public string StartDate { get; set; }
        
        public string EndDate { get; set; }
    }
}
