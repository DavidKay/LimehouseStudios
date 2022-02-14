using LimehouseStudios.Domain;
using LimehouseStudios.JsonPlaceholder.Api.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LimehouseStudios.JsonPlaceholder.Api.Services
{
    public interface IPostSearchService
    {
        Task<QueryResponse<IEnumerable<Post>>> GetUserPostsAsync(GetUserPostsQuery getUserPostsQuery);
    }
}
