namespace Building_a_User_s_and_Tasks_API.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ApiKey { get; set; }
    }
}
