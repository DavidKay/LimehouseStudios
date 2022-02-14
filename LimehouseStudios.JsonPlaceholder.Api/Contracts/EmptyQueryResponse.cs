namespace LimehouseStudios.JsonPlaceholder.Api.Contracts
{
    public class EmptyQueryResponse<T> : QueryResponse<T> where T : class
    {
        public EmptyQueryResponse(string errorMessage)
            : base(null, false, errorMessage)
        {
        }
    }
}
