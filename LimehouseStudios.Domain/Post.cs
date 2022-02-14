using System;

namespace LimehouseStudios.Domain
{
    public class Post
    {
        public Post(
            int id,
            string title,
            string body)
        {
            if (id < 1)
            {
                throw new ArgumentException($"'{nameof(id)}' must be greater than 0.", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(body))
            {
                throw new ArgumentException($"'{nameof(body)}' cannot be null or whitespace.", nameof(body));
            }

            Id = id;
            Title = title;
            Body = body;
        }

        public int Id { get; }

        public string Title { get; }

        public string Body { get; }
    }
}
