using Pacman.utils;

namespace Pacman.Menu;

public class Menu
{
    protected bool Centered = true;
    protected string Title = "title";
    protected string Subtitle = "subtitle";
    protected List<MenuOption> Options = [];
    private const bool IsRunning = true;

    private void Display()
    {
        Console.Clear();
        if (Centered) Console.SetCursorPosition(Console.WindowWidth / 2 - ColorWrite.GetTextLength(Title) / 2, 1);
        ColorWrite.Parser(Title);
        
        if (Centered) Console.SetCursorPosition(Console.WindowWidth / 2 - ColorWrite.GetTextLength(Subtitle) / 2, 2);
        ColorWrite.Parser(Subtitle);
        
        foreach (var option in Options)
        {
            option.Display();
        }
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
            {
                var previous = Options.Find(option => option.Selected);
                previous!.Selected = false;
                var index = Options.IndexOf(previous);
                if (index == 0)
                {
                    Options.Last().Selected = true;
                }
                else
                {
                    Options[index - 1].Selected = true;
                }

                break;
            }
            case ConsoleKey.DownArrow:
            {
                var next = Options.Find(option => option.Selected);
                next!.Selected = false;
                var nextIndex = Options.IndexOf(next);
                if (nextIndex == Options.Count - 1)
                {
                    Options.First().Selected = true;
                }
                else
                {
                    Options[nextIndex + 1].Selected = true;
                }

                break;
            }
            case ConsoleKey.Enter:
            {
                var selected = Options.Find(option => option.Selected);
                selected?.Action();
                break;
            }
        }
    }

    public void Run()
    {
        Console.CursorVisible = false;
        
        Options.First().Selected = true;
        while (IsRunning)
        {
            Display();
            HandleInput();
            Thread.Sleep(200);
        }
    }
}