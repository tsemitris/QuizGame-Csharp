
using QuizGame;

public class UsersService
{
    List<User> users = new List<User>();

    public void AddUser(string userName)
    {
        users.Add(new User(userName));
    }

    public List<User> OrderByDescending()
    {
        return users.OrderByDescending(u => u.Score).ToList();
    }
}
