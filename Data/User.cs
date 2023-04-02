namespace FlashcardLibrary.Data
{
    public class User : Base
    {
        public User(string username, string password) 
        {
            this.ObjectName = username;
            this.Password = password;
        }
        public string Password { get; set; }
    }
}
