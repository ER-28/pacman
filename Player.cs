using Pacman.utils;

namespace Pacman;

public class Player
{
    public Position Position { get; set; }
    public int PlayerDirection { get; set; }
    
    public Player()
    {
        Position = new Position(20, 18);
        PlayerDirection = Direction.Right;
    }

    public void Move()
    {
        switch (PlayerDirection)
        {
            case Direction.Up:
                if (Map.walkable.Contains(Game.Map.MapData[Position.Y - 1][Position.X]))
                {
                    Position.Y--;
                }
                break;
            case Direction.Down:
                if (Map.walkable.Contains(Game.Map.MapData[Position.Y + 1][Position.X]))
                {
                    Position.Y++;
                }
                break;
            case Direction.Left:
                if (Map.walkable.Contains(Game.Map.MapData[Position.Y][Position.X - 2]))
                {
                    Position.X -= 2;
                }
                break;
            case Direction.Right:
                if (Map.walkable.Contains(Game.Map.MapData[Position.Y][Position.X + 2]))
                {
                    Position.X += 2;
                }
                break;
        }
    }
    
    public void Draw()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write('\u2588');
        Console.ResetColor();
    }
}