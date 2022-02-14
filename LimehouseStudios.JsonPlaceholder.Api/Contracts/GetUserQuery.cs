namespace LimehouseStudios.JsonPlaceholder.Api.Contracts
{
    public class GetUserQuery
    {
        public GetUserQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
