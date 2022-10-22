using Core.Repositories;
using Persistence.Entities;

namespace Application.Services;

public interface ICountryRepository : IAsyncRepository<Country>, IRepository<Country>
{
}