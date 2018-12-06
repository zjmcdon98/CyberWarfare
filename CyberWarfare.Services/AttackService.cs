using ClassWarfare.Models;
using CyberWarfare.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberWarfare.Services
{
    public class AttackService
    {
        private readonly Guid _userId;

        public AttackService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAttack(AttackCreate model)
        {
            var entity =
                new Attack()
                {
                    OwnerId = _userId,
                    AttackName = model.AttackName,
                    Success = model.Success,
                    Time = model.Time,
                    Date = model.Date,
                    AttackType = model.AttackType
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attacks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AttackListItem> GetAttacks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Attacks
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new AttackListItem
                            {
                                AttackId = e.AttackId,
                                AttackName = e.AttackName
                            }
                        );
                return query.ToArray();
            }
        }
    }
}
       

        
            

