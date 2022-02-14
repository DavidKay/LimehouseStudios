using LimehouseStudios.Application.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace LimehouseStudios.WebApp.Models
{
    public class SummaryViewModel
    {
        public SummaryViewModel(IEnumerable<UserDto> users)
        {
            this.UserPostSummaries = users.Select(x => new UserPostSummaryViewModel(
                x.Id,
                x.Name, 
                x.Username, 
                x.Posts.Count()));
        }

        public IEnumerable<UserPostSummaryViewModel> UserPostSummaries { get; }
    }
}
