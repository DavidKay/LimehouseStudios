using AutoMapper;
using LimehouseStudios.Application.Contracts;
using LimehouseStudios.Application.Dtos;
using LimehouseStudios.JsonPlaceholder.Api.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LimehouseStudios.Application.Services
{
    public class UserService :
        IRequestHandler<GetAllUsersSummaryQuery, QueryResponse<IEnumerable<UserDto>>>,
        IRequestHandler<GetUserDetailsQuery, QueryResponse<UserDto>>
    {
        private readonly IMapper mapper;
        private readonly IUserSearchService userSearchService;

        public UserService(
            IMapper mapper,
            IUserSearchService userSearchService)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userSearchService = userSearchService ?? throw new ArgumentNullException(nameof(userSearchService));
        }

        public async Task<QueryResponse<IEnumerable<UserDto>>> Handle(GetAllUsersSummaryQuery request, CancellationToken cancellationToken)
        {
            var allUsersResponse = await this.userSearchService.GetAllUsersAsync();

            if (allUsersResponse.IsSuccess && allUsersResponse.HasValue)
            {
                var userDtos = this.mapper.Map<IEnumerable<UserDto>>(allUsersResponse.Value);

                return new QueryResponse<IEnumerable<UserDto>>(userDtos, true);
            }
            else
            {
                return new EmptyQueryResponse<IEnumerable<UserDto>>(allUsersResponse.ErrorMessage);
            }
        }

        public async Task<QueryResponse<UserDto>> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var userResponse = await this.userSearchService.GetUserAsync(new JsonPlaceholder.Api.Contracts.GetUserQuery(request.UserId));

            if (userResponse.IsSuccess && userResponse.HasValue)
            {
                var userDto = this.mapper.Map<UserDto>(userResponse.Value);
                return new QueryResponse<UserDto>(userDto, true);
            }
            else
            {
                return new EmptyQueryResponse<UserDto>(userResponse.ErrorMessage);
            }
        }
    }
}
