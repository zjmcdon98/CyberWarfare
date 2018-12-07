using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberWarfare.Data
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string CountryTech { get; set; }

        [Required]
        public string DipRelations { get; set; }

        [Required]
        public int StaffAmount { get; set; }

        [Required]
        public int CountryBudget { get; set; }
    }
}
