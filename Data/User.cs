namespace FlashcardLibrary.Data
{
    public class User : Base
    {
        public User(string objectName, string password) 
        {
            this.ObjectName = objectName;
            this.Password = password;
        }
        public string Password { get; set; }
    }
}
