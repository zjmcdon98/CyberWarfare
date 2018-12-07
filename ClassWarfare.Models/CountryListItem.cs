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
        
        public override string ToString() => CountryName;   
    }
}
