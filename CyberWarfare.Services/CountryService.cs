using ClassWarfare.Models;
using CyberWarfare.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
