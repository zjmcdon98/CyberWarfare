using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberWarfare.Models
{
    public class DataCollectCreate
    {
        public int AttackId { get; set; }

        public int CountryId { get; set; }

        public string AttackName { get; set; }

        public string CountryName { get; set; }

        public string Success { get; set; }

        public string AttackType { get; set; }

        public string AttackingCountry { get; set; }
    }
}
