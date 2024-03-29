using Pacman.utils;

namespace Pacman;

public class Player
{
    public Position Position { get; set; }
    public int PlayerDirection { get; set; }
    public int WantedDirection { get; set; }
    public static int Life { get; set; } = 3;

    public Player()
    {
        Position = new Position(20, 18);
        PlayerDirection = Direction.Right;
    }

    public void Move()
    {
        checkDirection();
        switch (PlayerDirection)
        {
            case Direction.Up:
                if (Map.Walkable.Contains(Game.Map.MapData[Position.Y - 1][Position.X]))
                {
                    Game.Updated = true;
                    Position.Y--;
                }
                break;
            case Direction.Down:
                if (Map.Walkable.Contains(Game.Map.MapData[Position.Y + 1][Position.X]))
                {
                    Game.Updated = true;
                    Position.Y++;
                }
                break;
            case Direction.Left:
                if (Map.Walkable.Contains(Game.Map.MapData[Position.Y][Position.X - 2]))
                {
                    Game.Updated = true;
                    Position.X -= 2;
                }
                break;
            case Direction.Right:
                if (Map.Walkable.Contains(Game.Map.MapData[Position.Y][Position.X + 2]))
                {
                    Game.Updated = true;
                    Position.X += 2;
                }
                break;
        }
    }

    private void checkDirection()
    {
        switch (WantedDirection)
        {
            case Direction.Up:
                if (CanMove(WantedDirection))
                {
                    PlayerDirection = Direction.Up;
                }
                break;
            case Direction.Down:
                if (CanMove(WantedDirection))
                {
                    PlayerDirection = Direction.Down;
                }
                break;
            case Direction.Left:
                if (CanMove(WantedDirection))
                {
                    PlayerDirection = Direction.Left;
                }
                break;
            case Direction.Right:
                if (CanMove(WantedDirection))
                {
                    PlayerDirection = Direction.Right;
                }
                break;
        }
    }

    private bool CanMove(int direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Map.Walkable.Contains(Game.Map.MapData[Position.Y - 1][Position.X]);
            case Direction.Down:
                return Map.Walkable.Contains(Game.Map.MapData[Position.Y + 1][Position.X]);
            case Direction.Left:
                return Map.Walkable.Contains(Game.Map.MapData[Position.Y][Position.X - 2]);
            case Direction.Right:
                return Map.Walkable.Contains(Game.Map.MapData[Position.Y][Position.X + 2]);
        }
        return false;
    }
    
    public void Draw()
    {
        Console.SetCursorPosition(Position.X, Position.Y + 1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write('\u2588');
        Console.ResetColor();
    }

    public void Respawn()
    {
        Life--;
        Position = new Position(20, 17);
        PlayerDirection = Direction.Right;
    }
}