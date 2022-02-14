﻿using System.Collections.Generic;

namespace LimehouseStudios.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<PostDto> Posts { get; set; }
    }
}

