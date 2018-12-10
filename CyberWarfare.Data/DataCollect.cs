using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberWarfare.Data
{
    public class DataCollect
    {
        [Key]
        public int DataCollectItemId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int AttackId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public string AttackName { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public string AttackType { get; set; }

        [Required]
        public string Success { get; set; }

        [Required]
        public string AttackingCountry { get; set; }

        public virtual Attack Attack { get; set; }
        public virtual Country Country { get; set; }
    }
}
