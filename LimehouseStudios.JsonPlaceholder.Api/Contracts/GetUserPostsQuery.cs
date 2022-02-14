namespace LimehouseStudios.JsonPlaceholder.Api.Contracts
{
    public class GetUserPostsQuery
    {
        public GetUserPostsQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
