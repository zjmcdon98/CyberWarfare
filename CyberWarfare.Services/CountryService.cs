using ClassWarfare.Models;
using CyberWarfare.Data;
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
                    OwnerTwoId = _userId,
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
                        .Where(e => e.OwnerTwoId == _userId)
                        .Select(
                        e =>
                            new CountryListItem
                            {
                                CountryId = e.CountryId,
                                CountryName = e.CountryName
                            }
                        );
                return query.ToArray();
            }
        }

        public CountryDetail GetCountryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Countries
                        .Single(e => e.CountryId == countryId && e.OwnerTwoId == _userId);
                return
                    new CountryDetail
                    {
                        CountryId = entity.CountryId,
                        CountryName = entity.CountryName,
                        CountryTech = entity.CountryTech,
                        DipRelations = entity.DipRelations,
                        StaffAmount = entity.StaffAmount,
                        CountryBudget = CountryBudget
                    };​
            }
        }
    }
