namespace LimehouseStudios.WebApp.Models
{
    public class PostViewModel
    {
        public PostViewModel(
            int id,
            string title,
            string body)
        {
            Id = id;
            Title = title;
            Body = body;
        }

        public int Id { get; }

        public string Title { get; }

        public string Body { get; }
    }
}
