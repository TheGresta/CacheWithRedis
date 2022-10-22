using Core.Repositories;
using Persistence.Context;
using Persistence.Entities;

namespace Persistence.Repositories;

public class CityRepository : EfRepositoryBase<City, BaseDbContext>, ICityRepository
{
	public CityRepository(BaseDbContext context) : base(context)
	{

	}
}