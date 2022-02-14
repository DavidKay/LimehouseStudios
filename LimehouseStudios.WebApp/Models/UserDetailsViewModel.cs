using LimehouseStudios.Application.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace LimehouseStudios.WebApp.Models
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(UserDto userDto)
        {
            this.Id = userDto.Id;
            this.Name = userDto.Name;
            this.Username = userDto.Username;
            this.PhoneNumber = userDto.PhoneNumber;
            this.Email = userDto.Email;

            var postViewModels = userDto.Posts.Select(x => new PostViewModel(
                x.Id,
                x.Title,
                x.Body));

            this.Posts = postViewModels;
        }

        public int Id { get; }

        public string Name { get; }

        public string Username { get; }

        public string PhoneNumber { get; }

        public string Email { get; }

        public IEnumerable<PostViewModel> Posts { get; }
    }
}
