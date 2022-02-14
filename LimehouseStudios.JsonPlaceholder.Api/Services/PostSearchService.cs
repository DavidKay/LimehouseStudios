using LimehouseStudios.Domain;
using LimehouseStudios.JsonPlaceholder.Api.Configuration;
using LimehouseStudios.JsonPlaceholder.Api.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LimehouseStudios.JsonPlaceholder.Api.Services
{
    public class PostSearchService : IPostSearchService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApiConfiguration apiConfiguration;

        public PostSearchService(
            IHttpClientFactory httpClientFactory,
            ApiConfiguration apiConfiguration)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.apiConfiguration = apiConfiguration ?? throw new ArgumentNullException(nameof(apiConfiguration));
        }

        public async Task<QueryResponse<IEnumerable<Post>>> GetUserPostsAsync(GetUserPostsQuery getUserPostsQuery)
        {
            var posts = await this.GetUsersPosts(getUserPostsQuery.UserId);

            return new QueryResponse<IEnumerable<Post>>(posts, true);
        }

        private async Task<IEnumerable<Post>> GetUsersPosts(int userId)
        {
            var request = this.BuildGetUserPostsRequest(userId);

            var response = await this.GetPostsResponse(request);

            if (response != null)
            {
                var posts = response.Select(x => new Post(
                    x.Id,
                    x.Title,
                    x.Body));

                return posts;
            }

            return Enumerable.Empty<Post>();
        }

        private async Task<IEnumerable<Responses.Post>> GetPostsResponse(HttpRequestMessage request)
        {
            HttpClient client = this.httpClientFactory.CreateClient();

            HttpResponseMessage responseMessage = await client.SendAsync(request);

            string responseContent = await responseMessage.Content.ReadAsStringAsync();

            var postsResponse = JsonConvert.DeserializeObject<IEnumerable<Responses.Post>>(responseContent);

            return postsResponse;
        }

        private HttpRequestMessage BuildGetUserPostsRequest(int userId)
        {
            var requestUrl = $"{this.apiConfiguration.JsonPlaceholderUrl}/users/{userId}/posts";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            return request;
        }
    }
}
