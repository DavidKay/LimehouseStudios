using System;

namespace LimehouseStudios.Application.Contracts
{
    public class QueryResponse<T>
    {
        public QueryResponse(T entity, bool isSuccess, string errorMessage = null)
        {
            this.Value = entity;
            this.IsSuccess = isSuccess;
            this.ErrorMessage = errorMessage;
        }

        public T Value { get; }

        public bool IsSuccess { get; }

        public string ErrorMessage { get; }

        public bool HasValue => this.Value != null;
    }
}
