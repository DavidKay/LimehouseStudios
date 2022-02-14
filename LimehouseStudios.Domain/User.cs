using System;
using System.Collections.Generic;

namespace LimehouseStudios.Domain
{
    public class User
    {
        public User(
            int id,
            string name,
            string username,
            string email,
            string phoneNumber)
        {
            if (id < 1)
            {
                throw new ArgumentException($"'{nameof(id)}' must be greater than 0.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or whitespace.", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException($"'{nameof(phoneNumber)}' cannot be null or whitespace.", nameof(phoneNumber));
            }

            this.Id = id;
            this.Name = name;
            this.Username = username;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }

        public void AssignPosts(IEnumerable<Post> posts)
        {
            if (this.Posts != null)
            {
                throw new Exception("Unable to assign posts to this user as posts have already been assigned once already.");
            }

            this.Posts = posts;
        }

        public int Id { get; }

        public string Name { get; }

        public string Username { get; }

        public string Email { get; }

        public string PhoneNumber { get; }

        public IEnumerable<Post> Posts { get; private set; }
    }
}
