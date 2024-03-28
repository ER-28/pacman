namespace Pacman.Menu;

public class StartMenu : Menu
{
    public StartMenu()
    {
        const string title = "#yellow#Pacman";
        
        Title = title;
        Subtitle = $"#cyan#Welcome to {title} !";
        Options = [
            new MenuOption("#green#Play", () =>
            {
                new Game();
            }, 1),
            new MenuOption("#darkred#Exit", () =>
            {
                Environment.Exit(0);
            }, 2)
        ];
        Centered = true;
    }
}