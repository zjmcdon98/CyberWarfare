using ClassWarfare.Models;
using CyberWarfare.Data;
using CyberWarfare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberWarfare.Services
{
    public class DataCollectService
    {
        private readonly Guid _userId;

        public DataCollectService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDataCollectItem(DataCollectCreate model)
        {
            var entity =
                new DataCollect()
                {
                    OwnerId = _userId,
                    AttackId = model.AttackId,
                    CountryId = model.CountryId,
                    AttackName = model.AttackName,
                    CountryName = model.CountryName,
                    Success = model.Success,
                    AttackType = model.AttackType,
                    AttackingCountry = model.AttackingCountry
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.DataCollection.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public DataCollectDetail GetDataCollectById(int dataCollectItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                  ctx
                      .DataCollection
                      .Single(e => e.DataCollectItemId == dataCollectItemId && e.OwnerId == _userId);
                return
                  new DataCollectDetail
                  {
                      DataCollectItemId = entity.DataCollectItemId,
                      AttackId = entity.AttackId,
                      CountryId = entity.CountryId,
                      AttackName = entity.AttackName,
                      CountryName = entity.CountryName,
                      Success = entity.Success,
                      AttackType = entity.AttackType,
                      AttackingCountry = entity.AttackingCountry
                  };
            }
        }

        public bool UpdateDataCollectItem(DataCollectEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DataCollection
                        .Single(e => e.DataCollectItemId == model.DataCollectItemId && e.OwnerId == _userId );
                entity.AttackId = model.AttackId;
                entity.CountryId = model.CountryId;
                entity.AttackName = model.AttackName;
                entity.CountryName = model.CountryName;
                entity.Success = model.Success;
                entity.AttackType = model.AttackType;
                entity.AttackingCountry = model.AttackingCountry;
                
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDataCollectItem(int dataCollectItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DataCollection
                        .Single(e => e.DataCollectItemId == dataCollectItemId && e.OwnerId == _userId);

                ctx.DataCollection.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DataCollectList> GetDataCollection()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .DataCollection
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new DataCollectList
                            {
                                DataCollectItemId = e.DataCollectItemId,
                                AttackId = e.AttackId,
                                CountryId = e.CountryId,
                                AttackName = e.AttackName,
                                CountryName = e.CountryName,
                                Success = e.Success,
                                AttackType = e.AttackType,
                                AttackingCountry = e.AttackingCountry
                            }
                        );
                return query.ToArray();
            }
        }
    }
}
