namespace QuizGame;

public class User
{
    public string Name { get; set; }
    public int Score { get; set; }
    public DateOnly LastTimePlayed { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public User(string name, int score)
    {
        Name = name;
        Score = score;
        LastTimePlayed = DateOnly.FromDateTime(DateTime.Now);
    }

    public User(string name)
    {
        Name = name;
    }
}
