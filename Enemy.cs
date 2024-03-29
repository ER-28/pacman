using Pacman.utils;

namespace Pacman;

public class Enemy
{
    public Position Position { get; set; }
    public Position SpawnPosition { get; set; }
    public int EnemyDirection { get; set; }
    public int EnemyWantDirection { get; set; }
    public int EnemyIndex { get; set; }
    public bool IsAfraid { get; set; }
    public int AfraidTime { get; set; }
    
    public Enemy(Position position, int index)
    {
        Position = position;
        SpawnPosition = new Position(position.X, position.Y);
        EnemyDirection = 0;
        EnemyIndex = index;
    }
    
    public void CheckAfraidTime()
    {
        if (!IsAfraid) return;
        
        if (AfraidTime <= 0)
        {
            IsAfraid = false;
        }
        
        AfraidTime--;
    }
    
    public void Draw()
    {
        Console.SetCursorPosition(Position.X, Position.Y + 1);
        
        CheckAfraidTime();
        if (IsAfraid)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('M');
            Console.ResetColor();
            return;
        }
        
        Console.ForegroundColor = EnemyIndex switch
        {
            0 => ConsoleColor.Magenta,
            1 => ConsoleColor.Green,
            2 => ConsoleColor.Blue,
            3 => ConsoleColor.Red,
            _ => Console.ForegroundColor
        };
        Console.Write('M');
        Console.ResetColor();
    }
    
    public void CheckCollision()
    {
        if (Position.X == Game.Player.Position.X && Position.Y == Game.Player.Position.Y)
        {
            if (IsAfraid)
            {
                Game.Score += 100;
                Position = SpawnPosition;
                IsAfraid = false;
            }
            Game.Player.Respawn();
        }
    }

    public void Move()
    {
        EnemyWantDirection = new Random().Next(1, 150) switch
        {
            <= 25 => Direction.Down,
            <= 50 => Direction.Up,
            <= 75 => Direction.Left,
            <= 100 => Direction.Right,
            _ => EnemyWantDirection
        };
        checkDirection();
        switch (EnemyDirection)
        {
            case Direction.Up:
                if (Map.EnemyWalkable.Contains(Game.Map.MapData[Position.Y - 1][Position.X]))
                {
                    Position.Y--;
                    Game.Updated = true;
                }
                break;
            case Direction.Down:
                if (Map.EnemyWalkable.Contains(Game.Map.MapData[Position.Y + 1][Position.X]))
                {
                    Position.Y++;
                    Game.Updated = true;
                }
                break;
            case Direction.Left:
                if (Map.EnemyWalkable.Contains(Game.Map.MapData[Position.Y][Position.X - 2]))
                {
                    Position.X -= 2;
                    Game.Updated = true;
                }
                break;
            case Direction.Right:
                if (Map.EnemyWalkable.Contains(Game.Map.MapData[Position.Y][Position.X + 2]))
                {
                    Position.X += 2;
                    Game.Updated = true;
                }
                break;
        }
    }

    private void checkDirection()
    {
        switch (EnemyWantDirection)
        {
            case Direction.Up:
                if (CanMove(EnemyWantDirection))
                {
                    EnemyDirection = Direction.Up;
                }
                break;
            case Direction.Down:
                if (CanMove(EnemyWantDirection))
                {
                    EnemyDirection = Direction.Down;
                }
                break;
            case Direction.Left:
                if (CanMove(EnemyWantDirection))
                {
                    EnemyDirection = Direction.Left;
                }
                break;
            case Direction.Right:
                if (CanMove(EnemyWantDirection))
                {
                    EnemyDirection = Direction.Right;
                }
                break;
        }
    }

    private bool CanMove(int direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Map.EnemyWalkable.Contains(Game.Map.MapData[Position.Y - 1][Position.X]);
            case Direction.Down:
                return Map.EnemyWalkable.Contains(Game.Map.MapData[Position.Y + 1][Position.X]);
            case Direction.Left:
                return Map.EnemyWalkable.Contains(Game.Map.MapData[Position.Y][Position.X - 2]);
            case Direction.Right:
                return Map.EnemyWalkable.Contains(Game.Map.MapData[Position.Y][Position.X + 2]);
        }
        return false;
    }
    
    
}