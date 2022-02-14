using LimehouseStudios.Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace LimehouseStudios.Application.Contracts
{
    public class GetAllUsersSummaryQuery : IRequest<QueryResponse<IEnumerable<UserDto>>>
    {
    }
}
