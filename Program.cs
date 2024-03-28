using Pacman.Menu;

namespace Pacman
{
    internal static class Pacman
    {
        private static void Main(string[] args)
        {
            var startMenu = new StartMenu();
            startMenu.Run();
        }
    }
}
