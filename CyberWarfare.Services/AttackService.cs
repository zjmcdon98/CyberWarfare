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
                    AttackId = _userId,
                    AttackName = model.AttackName
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
                        .Where(e => e.AttackId == _userId)
                        .Select(
                        e =>
                            new AttackListItem
                            {
                                AttackId = e.NoteId,
                                AttackName = e.AttackName
                            }
                        );
                return query.ToArray();
            }
        }
    }
}
       

        
            

