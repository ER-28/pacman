using System.Text;
using Pacman.Menu;
using Pacman.utils;

namespace Pacman;

public class Game
{
    public static bool Running { get; set; } = true;
    public static List<Enemy> Enemies { get; set; } = [];
    public static Player Player { get; set; } = new ();
    public static Map Map { get; set; } = new ();
    public static int Score { get; set; } = 0;
    public static bool Updated { get; set; } = false;

    public Game()
    {
        Console.Clear();
        
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        
        Loop();
    }
    
    private void Loop()
    {
        while (Running)
        {
            Console.SetCursorPosition(0, 0);
            HandleInput();
            
            Player.Move();
            foreach (var enemy in Enemies) enemy.Move();
            Map.CheckCollision();
            Map.CheckWin();

            if (Updated)
            {
                Console.Clear();
            
                Map.Draw();
                Map.DrawObject();
                Player.Draw();
                foreach (var enemy in Enemies) enemy.Draw();
                
                Updated = false;
            }
            
            Thread.Sleep(500);
        }
        Console.Clear();
    }

    private void HandleInput()
    {
        if (!Console.KeyAvailable) return;
        
        var key = Console
            .ReadKey(intercept: true)
            .Key;
        
        switch (key)
        {
            case ConsoleKey.UpArrow:
                Player.WantedDirection = Direction.Up;
                break;
            case ConsoleKey.DownArrow:
                Player.WantedDirection = Direction.Down;
                break;
            case ConsoleKey.LeftArrow:
                Player.WantedDirection = Direction.Left;
                break;
            case ConsoleKey.RightArrow:
                Player.WantedDirection = Direction.Right;
                break;
            case ConsoleKey.Q:
                break;
        }
    }
    
}