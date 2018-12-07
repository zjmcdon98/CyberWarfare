using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarfare.Models
{
    public class CountryCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string CountryName { get; set; }

        public string CountryTech { get; set; }

        public string DipRelations { get; set; }

        public int StaffAmount { get; set; }

        public int CountryBudget { get; set; }

        public override string ToString() => CountryName;
    }
}
