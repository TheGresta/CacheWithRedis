using Core.Repositories;
using Persistence.Entities;

namespace Application.Services;

public interface ICityRepository : IAsyncRepository<City>, IRepository<City>
{
}