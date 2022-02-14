using LimehouseStudios.Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace LimehouseStudios.Application.Contracts
{
    public class GetUserDetailsQuery : IRequest<QueryResponse<UserDto>>
    {
        public GetUserDetailsQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
