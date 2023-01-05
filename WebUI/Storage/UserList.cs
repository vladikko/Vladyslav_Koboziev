namespace WebUI.Storage;

public class UserList
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public UserList(string username, string password)
    {
        this.UserName = username;
        this.Password = password;
    }
}