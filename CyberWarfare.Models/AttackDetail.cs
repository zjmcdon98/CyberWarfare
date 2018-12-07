using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarfare.Models
{
    public class AttackDetail
    {
        public int AttackId { get; set; }
        public string AttackName { get; set; }
        public string Success { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string AttackType { get; set; }
    }
}
