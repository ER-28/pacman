using System.Text;
using Pacman.Menu;
using Pacman.utils;

namespace Pacman;

public class Game
{
    public static bool Running { get; set; } = true;
    public static bool Updated { get; set; } = true;
    public static Map Map { get; set; } = new Map();
    public static Player Player { get; set; } = new Player();
    
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
            
            Map.Draw();
            Player.Draw();
            
            Thread.Sleep(300);
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
                Player.PlayerDirection = Direction.Up;
                break;
            case ConsoleKey.DownArrow:
                Player.PlayerDirection = Direction.Down;
                break;
            case ConsoleKey.LeftArrow:
                Player.PlayerDirection = Direction.Left;
                break;
            case ConsoleKey.RightArrow:
                Player.PlayerDirection = Direction.Right;
                break;
            case ConsoleKey.Q:
                break;
        }
    }
    
}