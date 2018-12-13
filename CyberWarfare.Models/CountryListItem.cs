using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarfare.Models
{
    public class CountryListItem
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryTech { get; set; }
        public string DipRelations { get; set; }
        public int StaffAmount { get; set; }
        public int CountryBudget { get; set; }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
