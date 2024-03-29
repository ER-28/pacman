using Pacman.utils;

namespace Pacman;

public class PacGomme
{
    
    public Position Position { get; set; }
    public bool IsEaten { get; set; }
    
    public PacGomme(int x, int y)
    {
        Position = new Position(x, y);
        IsEaten = false;
    }
    
    public void CheckCollision()
    {
        if (Game.Player.Position.X == Position.X && Game.Player.Position.Y == Position.Y)
        {
            if (IsEaten) return;
            IsEaten = true;
            foreach (var enemy in Game.Enemies)
            {
                enemy.IsAfraid = true;
                enemy.AfraidTime = 50;
            }
        }
    }

    public void Draw()
    {
        if (IsEaten) return;
        Console.SetCursorPosition(Position.X, Position.Y + 1);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write('o');
        Console.ResetColor();
    }
}