namespace LimehouseStudios.WebApp.Models
{
    public class UserPostSummaryViewModel
    {
        public UserPostSummaryViewModel(
            int userId,
            string name, 
            string username, 
            int numberOfPosts)
        {
            UserId = userId;
            Name = name;
            Username = username;
            NumberOfPosts = numberOfPosts;
        }

        public int UserId { get; }

        public string Name { get; }

        public string Username { get; }

        public int NumberOfPosts { get; }
    }
}
