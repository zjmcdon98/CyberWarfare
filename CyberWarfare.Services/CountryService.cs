using ClassWarfare.Models;
using CyberWarfare.Data;
using CyberWarfare.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberWarfare.Services
{
    public class CountryService
    {
        private readonly Guid _userId;


        public CountryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCountry(CountryCreate model)
        {
            var entity =
                new Country()
                {
                    OwnerId = _userId,
                    CountryName = model.CountryName,
                    CountryTech = model.CountryTech,
                    DipRelations = model.DipRelations,
                    StaffAmount = model.StaffAmount,
                    CountryBudget = model.CountryBudget
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Countries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CountryListItem> GetCountries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Countries
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new CountryListItem
                            {
                                CountryId = e.CountryId,
                                CountryName = e.CountryName,
                                CountryTech = e.CountryTech,
                                DipRelations = e.DipRelations,
                                StaffAmount = e.StaffAmount,
                                CountryBudget = e.CountryBudget

                            }
                        );
                return query.ToArray();
            }
        }

        public CountryDetail GetCountryById(int countryid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Countries
                        .Single(e => e.CountryId == countryid && e.OwnerId == _userId);
                return
                    new CountryDetail
                    {
                        CountryId = entity.CountryId,
                        CountryName = entity.CountryName,
                        CountryTech = entity.CountryTech,
                        DipRelations = entity.DipRelations,
                        StaffAmount = entity.StaffAmount,
                        CountryBudget = entity.CountryBudget
                    };
            }
        }

        public bool UpdateCountry(CountryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Countries
                        .Single(e => e.CountryId == model.CountryId && e.OwnerId == _userId);

                entity.CountryName = model.CountryName;
                entity.CountryTech = model.CountryTech;
                entity.DipRelations = model.DipRelations;
                entity.StaffAmount = model.StaffAmount;
                entity.CountryBudget = model.CountryBudget;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCountry(int countryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Countries
                        .Single(e => e.CountryId == countryId && e.OwnerId == _userId);

                ctx.Countries.Remove(entity);
                    
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
