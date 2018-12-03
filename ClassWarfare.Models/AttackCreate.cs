using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarfare.Models
{
    public class AttackCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string AttackName { get; set; }

        public string Success { get; set; }

        public string Time { get; set; }

        public string Date { get; set; }

        public string AttackType { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
