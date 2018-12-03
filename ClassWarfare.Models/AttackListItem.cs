using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarfare.Models
{
    public class AttackListItem
    {
        public int AttackId { get; set; }
        public string AttackName { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
