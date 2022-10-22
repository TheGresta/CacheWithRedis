using Core.Repositories;
using Persistence.Context;
using Persistence.Entities;

namespace Persistence.Repositories;

public class CountryRepository : EfRepositoryBase<Country, BaseDbContext>, ICountryRepository
{
    public CountryRepository(BaseDbContext context) : base(context)
    {

    }
}

