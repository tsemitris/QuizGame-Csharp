using System.Drawing;

namespace QuizGame;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Lives { get; set; } = 3;
    public double Points { get; set; } = 0;
    public DateOnly LastTimePlayed { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        LastTimePlayed = DateOnly.FromDateTime(DateTime.Now);
    }
}
