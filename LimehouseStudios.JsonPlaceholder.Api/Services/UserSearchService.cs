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
    public class UserSearchService : IUserSearchService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ApiConfiguration apiConfiguration;
        private readonly IPostSearchService postSearchService;

        public UserSearchService(
            IHttpClientFactory httpClientFactory,
            ApiConfiguration apiConfiguration,
            IPostSearchService postSearchService)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.apiConfiguration = apiConfiguration ?? throw new ArgumentNullException(nameof(apiConfiguration));
            this.postSearchService = postSearchService ?? throw new ArgumentNullException(nameof(postSearchService));
        }

        public async Task<QueryResponse<IEnumerable<User>>> GetAllUsersAsync()
        {
            var users = await this.GetAllUsers();

            foreach (var user in users)
            {
                var postsResponse = await this.postSearchService.GetUserPostsAsync(new GetUserPostsQuery(user.Id));

                if (postsResponse.IsSuccess)
                {
                    user.AssignPosts(postsResponse.Value);
                }
            }

            return new QueryResponse<IEnumerable<User>>(users, true);
        }

        private async Task<IEnumerable<User>> GetAllUsers()
        {
            var request = this.BuildGetAllUsersRequest();

            var response = await this.GetAllUsersResponse(request);

            if (response != null)
            {
                var users = response.Select(x => new User(
                    x.Id,
                    x.Name,
                    x.Username,
                    x.Email,
                    x.PhoneNumber)).ToList();

                return users;
            }

            return Enumerable.Empty<User>();
        }

        public async Task<QueryResponse<User>> GetUserAsync(GetUserQuery getUserQuery)
        {
            var user = await this.GetUser(getUserQuery.UserId);

            if (user != null)
            {
                var postsResponse = await this.postSearchService.GetUserPostsAsync(new GetUserPostsQuery(user.Id));

                if (postsResponse.IsSuccess)
                {
                    user.AssignPosts(postsResponse.Value);
                }

                return new QueryResponse<User>(user, true);
            }
            else
            {
                return new EmptyQueryResponse<User>($"Could not find a user for Id:{getUserQuery.UserId}");
            }
        }

        private async Task<User> GetUser(int userId)
        {
            var request = this.BuildGetUserRequest(userId);

            var response = await this.GetUserResponse(request);

            if (response != null)
            {
                var user = new User(
                    response.Id,
                    response.Name,
                    response.Username,
                    response.Email,
                    response.PhoneNumber);

                return user;
            }

            return null;
        }

        private async Task<IEnumerable<Responses.User>> GetAllUsersResponse(HttpRequestMessage request)
        {
            HttpClient client = this.httpClientFactory.CreateClient();

            HttpResponseMessage responseMessage = await client.SendAsync(request);

            string responseContent = await responseMessage.Content.ReadAsStringAsync();

            var allUsersResponse = JsonConvert.DeserializeObject<List<Responses.User>>(responseContent);

            return allUsersResponse;
        }

        private HttpRequestMessage BuildGetAllUsersRequest()
        {
            var requestUrl = $"{this.apiConfiguration.JsonPlaceholderUrl}/users/";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            return request;
        }

        private async Task<Responses.User> GetUserResponse(HttpRequestMessage request)
        {
            HttpClient client = this.httpClientFactory.CreateClient();

            HttpResponseMessage responseMessage = await client.SendAsync(request);

            string responseContent = await responseMessage.Content.ReadAsStringAsync();

            var userResponse = JsonConvert.DeserializeObject<Responses.User>(responseContent);

            return userResponse;
        }

        private HttpRequestMessage BuildGetUserRequest(int userId)
        {
            var requestUrl = $"{this.apiConfiguration.JsonPlaceholderUrl}/users/{userId}";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            return request;
        }
    }
}
