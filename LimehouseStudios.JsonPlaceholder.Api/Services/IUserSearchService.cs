using LimehouseStudios.Domain;
using LimehouseStudios.JsonPlaceholder.Api.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LimehouseStudios.JsonPlaceholder.Api.Services
{
    public interface IUserSearchService
    {
        Task<QueryResponse<IEnumerable<User>>> GetAllUsersAsync();

        Task<QueryResponse<User>> GetUserAsync(GetUserQuery getUserQuery);
    }
}
