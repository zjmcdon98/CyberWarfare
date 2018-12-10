using ClassWarfare.Models;
using CyberWarfare.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarfare.Services
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
                    AttackType = model.AttackType,
                    AttackingCountry = model.AttackingCountry
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attacks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public AttackDetail GetAttackById(int attackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                  ctx
                      .Attacks
                      .Single(e => e.AttackId == attackId && e.OwnerId == _userId);
                return
                  new AttackDetail
                  {
                      AttackId = entity.AttackId,
                      AttackName = entity.AttackName,
                      Success = entity.Success,
                      Date = entity.Date,
                      Time = entity.Time,
                      AttackType = entity.AttackType
                  };
            }
        }

        public bool UpdateAttack(AttackEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                     ctx
                        .Attacks
                        .Single(e => e.AttackId == model.AttackId && e.OwnerId == _userId);
                entity.AttackName = model.AttackName;
                entity.Success = model.Success;
                entity.Date = model.Date;
                entity.Time = model.Time;
                entity.AttackType = model.AttackType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAttack(int attackId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Attacks
                        .Single(e => e.AttackId == attackId && e.OwnerId == _userId);

                ctx.Attacks.Remove(entity);

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
       

        
            

