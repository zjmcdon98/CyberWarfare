using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberWarfare.Data
{
    public class Attack
    {
        [Key]
        public Guid AttackId { get; set; }

        [Required]
        public string AttackName { get; set; }

        [Required]
        public string Success { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string AttackType { get; set; }


    }
}

