
using System.Runtime.CompilerServices;
using QuizGame;

public class UsersService
{
    List<User> users = new List<User>();

    public void AddUser(string userName)
    {
        users.Add(new User(userName));
    }

    public Guid GetUserId(string userName)
    {
        User userData = users.Find(u => u.Name == userName)!;
        return userData.Id;
    }

    public User GetUserById(Guid userId)
    {
        User userData = users.Find(u => u.Id == userId)!;
        return userData;
    }

    public void ResetUser(Guid userId)
    {
        User userData = GetUserById(userId);
        userData.Lifes = 3;
        userData.Points = 0;
    }

    public List<User> OrderByDescending()
    {
        return users.OrderByDescending(u => u.Points).ToList();
    }

    public int GetUserLifes(Guid userId)
    {
        return GetUserById(userId).Lifes;
    }

    public void UpdateUserLife(Guid userId)
    {
        GetUserById(userId).Lifes -= 1;
    }

    public double GetUserPoints(Guid userId)
    {
        return GetUserById(userId).Points;
    }

    public void UpdateUserPoints(Guid userId, double newPoints)
    {
        GetUserById(userId).Points += newPoints;
    }
}
